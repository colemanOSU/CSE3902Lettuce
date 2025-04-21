using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.GoriyaStuff;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real.EnemyStuff.SkeletonStuff
{
    public class Skeleton : IEnemy
    {
        private SkeletonStateMachine stateMachine;
        private SkeletonBehavior behavior;

        public ISprite2 mySprite;
        private Vector2 Location;
        public int speed = 2;

        private int FPS = 6;
        private float timer = 0f;
        private int health = 1;
        private TimeSpan stunTimer = TimeSpan.Zero;
        public bool IsStunned => stunTimer > TimeSpan.Zero;
        public ITreasureItems item { get; set; }

        public Skeleton(Vector2 start)
        {
            Location = start;
            stateMachine = new SkeletonStateMachine(this);
            behavior = new SkeletonBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateSkeletonSprite();
        }

        public Skeleton(Vector2 start, ITreasureItems item)
        {
            Location = start;
            stateMachine = new SkeletonStateMachine(this);
            behavior = new SkeletonBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateSkeletonSprite();
            this.item = item;
        }

        public void hitWall()
        {
            stateMachine.hitWall();
            stateMachine.ChangeDirection();
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

        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage);
        }
        public void Stun(TimeSpan duration)
        {
            stunTimer = duration;
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            if (IsStunned)
            {
                stunTimer -= gameTime.ElapsedGameTime;
                return;
            }
            stateMachine.Update();
            behavior.Update(gameTime);


            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= ((float)1 / FPS))
            {
                timer = 0f;
                mySprite.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (item != null)
            {
                // No way to change the location of an item, so this abomination is necessary. :/
                Type type = Type.GetType(item.GetType().ToString());
                item = (ITreasureItems)Activator.CreateInstance(type, location);
                item.Draw(spriteBatch);
            }
            mySprite.Draw(spriteBatch, location);
        }
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public Vector2 location
        {
            get { return Location; }
            set { Location = value; }
        }
    }
}
