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

        public HandSprite mySprite;
        private Vector2 Location;
        public int movementSpeed { get; }
        public Vector2 speed;

        private int FPS = 6;
        private float timer = 0f;
        private int health = 1;
        public bool YGreaterThanHalf { get; }

        public Hand(Vector2 start)
        {
            Location = start;
            stateMachine = new HandStateMachine(this);
            behavior = new HandBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateHandSprite();
            movementSpeed = 1;
            YGreaterThanHalf = location.Y < Game1.SCREENHEIGHT / 2;
            if (YGreaterThanHalf)
            {
                speed = new Vector2(0, movementSpeed);
            }
            else
            {
                speed = new Vector2(0, -movementSpeed);
            }
        }

        public void Stun()
        {
            stateMachine.Stun();
            behavior.Stun();
        }

        public void UnStun()
        {
            stateMachine.UnStun();
        }

        public void TakeDamage(int damage)
        {
            stateMachine.TakeDamage(damage);
        }

        public void MoveSideways()
        {
            stateMachine.MoveSideways();
            behavior.StartReturnTimer();
        }

        public void Return()
        {
            stateMachine.Return();
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
            if (YGreaterThanHalf)
            {
                mySprite.DrawUpsideDown(spriteBatch, location);
            }
            else
            {
                mySprite.Draw(spriteBatch, location);
            }
        }

        public void ChangeDirection()
        {
            // Doesn't change direction
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
