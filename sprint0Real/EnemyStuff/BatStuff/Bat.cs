using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.EnemyStuff.BatStuff
{
    public class Bat : IEnemy
    {
        private BatStateMachine stateMachine;
        private BatBehavior behavior;
        private bool Perched = false;
        private int health = 1;

        public ISprite2 mySprite;
        public Vector2 location;
        public float speed = 2f;
        public float FPS = 10;
        private float timer = 0f;
        

        public Bat(Vector2 start)
        {
            location = start;
            stateMachine = new BatStateMachine(this);
            behavior = new BatBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateBatSprite();
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
            stateMachine.TakeDamage(damage);
        }
        public void hitLink()
        {
            Despawn();
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
                //30x30 is size of sprite, change if sprite size is different
                return new Rectangle((int)location.X, (int)location.Y, 30, 30);
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
    }
}
