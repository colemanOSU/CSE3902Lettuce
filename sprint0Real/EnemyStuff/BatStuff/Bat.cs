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

        private ISprite2 sprite;
        private Vector2 Location;

        public float speed = 2f;
        public float FPS = 10;
        private float timer = 0f;
        

        public Bat(Vector2 start)
        {
            Location = start;
            stateMachine = new BatStateMachine(this);
            behavior = new BatBehavior(this);
            sprite = EnemySpriteFactory.Instance.CreateBatSprite();
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
