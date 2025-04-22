using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real.EnemyStuff.BatStuff
{
    public class Bat : IEnemy
    {
        private BatStateMachine stateMachine;
        private BatBehavior behavior;
        private bool Perched = false;
        private int health = 1;

        private TimeSpan stunTimer = TimeSpan.Zero;
        public bool IsStunned => stunTimer > TimeSpan.Zero;

        private ISprite2 sprite;
        private Vector2 Location;

        public float speed = 2f;
        public float FPS = 10;
        private float timer = 0f;
        public ITreasureItems item { get; }

        public Bat(Vector2 start)
        {
            Location = start;
            stateMachine = new BatStateMachine(this);
            behavior = new BatBehavior(this);
            sprite = EnemySpriteFactory.Instance.CreateBatSprite();
        }

        public Bat(Vector2 start, ITreasureItems item)
        {
            Location = start;
            stateMachine = new BatStateMachine(this);
            behavior = new BatBehavior(this);
            sprite = EnemySpriteFactory.Instance.CreateBatSprite();
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
        public void Stun(TimeSpan duration)
        {
            stunTimer = duration;
        }
        public void Perch()
        {
            Perched = true;
            stateMachine.Perched();
        }

        public void UnPerch()
        {
            FPS = 10;
            speed = 2f;
            Perched = false;
            stateMachine.ChangeDirection();
        }
        
        public void TakeDamage(int damage)
        {
            if (IsStunned)
            {
                return;
            }
            stateMachine.TakeDamage(damage);
        }
        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Despawn()
        {
            CurrentMap.Instance.DeStage(this);
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
            if (timer >= (1 / FPS) && !Perched)
            {
                timer = 0f;
                mySprite.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
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
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public ISprite2 mySprite
        {
            get {  return sprite; }
            set { sprite = value; }
        }
        public Vector2 location
        {
            get { return Location; }
            set { Location = value; }
        }
    }
}
