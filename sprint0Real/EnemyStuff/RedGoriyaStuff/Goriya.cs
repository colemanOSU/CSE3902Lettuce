using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.BoomerangStuff;
using sprint0Real.EnemyStuff.GoriyaStuff;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real.EnemyStuff.RedGoriya
{
    public class Goriya : IEnemy
    {
        private GoriyaStateMachine stateMachine;
        private GoriyaBehavior behavior;

        public ISprite2 mySprite;
        private Vector2 Location;
        public int speed = 2;
        private int health = 2;
        private TimeSpan stunTimer = TimeSpan.Zero;
        public bool IsStunned => stunTimer > TimeSpan.Zero;
        public Boomerang boomerang;
        private int FPS = 6;
        private float timer = 0f;
        public ITreasureItems item { get; }

        public Goriya(Vector2 placement)
        {
            Location = placement;
            stateMachine = new GoriyaStateMachine(this);
            behavior = new GoriyaBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
            
        }

        public Goriya(Vector2 placement, ITreasureItems item)
        {
            Location = placement;
            stateMachine = new GoriyaStateMachine(this);
            behavior = new GoriyaBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
            this.item = item;
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
            stateMachine.hitWall();
            stateMachine.ChangeDirection();
        }
        public void hitLink()
        {
            Despawn();
        }

        public void Despawn()
        {
            CurrentMap.Instance.DeStage(this);
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void TakeDamage(int damage)
        {
            behavior.TakeDamage();
            stateMachine.TakeDamage(damage);
        }

        public void Attack()
        {
            stateMachine.Attack();
        }

        public void Idle()
        {
            stateMachine.Idle();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }

        public void FinishDamage()
        {
            stateMachine.FinishDamage();
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
            // Moves onto the next frame in animation
            timer += (float)time.ElapsedGameTime.TotalSeconds;

            if (timer >= ((float)1 / FPS))
            {
                timer = 0f;
                mySprite.Update();
            }

            behavior.Update(time);
            stateMachine.Update();
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
