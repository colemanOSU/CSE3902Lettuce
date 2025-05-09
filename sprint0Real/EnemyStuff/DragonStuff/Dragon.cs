﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.Fireballs;
using sprint0Real.EnemyStuff.SkeletonStuff;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class Dragon : IEnemy
    {
        private DragonStateMachine stateMachine;
        private DragonBehavior behavior;

        public ISprite2 sprite;
        private Vector2 Location;
        public int speed = 2;
        private int health = 0;
        private TimeSpan stunTimer = TimeSpan.Zero;
        public bool IsStunned => stunTimer > TimeSpan.Zero;

        private int FPS = 6;
        private float timer = 0f;
        public ITreasureItems item { get; }

        public Dragon(Vector2 placement)
        {
            Location = placement;
            stateMachine = new DragonStateMachine(this);
            behavior = new DragonBehavior(this);
            sprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
        }

        public Dragon(Vector2 start, ITreasureItems item)
        {
            Location = start;
            stateMachine = new DragonStateMachine(this);
            behavior = new DragonBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
            this.item = item;
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void TakeDamage(int damage)
        {
            if (IsStunned)
            {
                return;
            }
            behavior.TakeDamage();
            stateMachine.TakeDamage(damage);
        }
        public void StageItem()
        {
            if (item != null)
            {
                CurrentMap.Instance.Stage(item);
            }
            else
            {
                DropManager.Instance.OnDeath(location);
            }
        }

        public void hitWall()
        {
            //stateMachine.hitWall();
            stateMachine.ChangeDirection();
        }

        public void Attack()
        {
            // This is quite the hack to access link's location
            DragonAttack attack = new DragonAttack(location, new Vector2(EnemySpriteFactory.Instance.myGame.Link.GetLocation().X, EnemySpriteFactory.Instance.myGame.Link.GetLocation().Y));
            attack.Attack();
            stateMachine.Attack();
        }

        public void Idle()
        {
            stateMachine.Idle();
        }
        public void Stun(TimeSpan duration)
        {
            stunTimer = duration;
        }
        public void Update(GameTime time)
        {
            if (IsStunned)
            {
                stunTimer -= time.ElapsedGameTime;
                return;
            }
            // Updates the location
            stateMachine.Update();

            // Moves onto the next frame in animation
            timer += (float) time.ElapsedGameTime.TotalSeconds;
            if (timer >= ((float) 1 / FPS))
            {
                timer = 0f;
                mySprite.Update();
            }
            // Updates the state based on external states
            behavior.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, 24 * Game1.RENDERSCALE, 32 * Game1.RENDERSCALE);
            }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public ISprite2 mySprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
        public Vector2 location
        {
            get { return Location; }
            set { Location = value; }
        }
    }
}
