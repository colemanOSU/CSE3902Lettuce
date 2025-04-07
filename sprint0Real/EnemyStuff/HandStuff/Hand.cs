using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.EnemyStuff.HandStuff
{
    public class Hand : IEnemy
    {
        private HandStateMachine stateMachine;
        private HandBehavior behavior;

        public ISprite2 mySprite;
        private Vector2 Location;
        public int speed = 2;

        private int FPS = 6;
        private float timer = 0f;
        private int health = 1;

        public Hand(Vector2 start)
        {
            Location = start;
            stateMachine = new HandStateMachine(this);
            behavior = new HandBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateHandSprite();
        }

        public void ChangeDirection()
        {
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
        public void Despawn()
        {
            CurrentMap.Instance.DeStage(this);
        }

        public void Update(GameTime gameTime)
        {
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
            mySprite.Draw(spriteBatch, location);
        }
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, 15 * Game1.RENDERSCALE, 15 * Game1.RENDERSCALE);
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
