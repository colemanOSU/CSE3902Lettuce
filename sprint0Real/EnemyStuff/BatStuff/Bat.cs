using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.BatStuff
{
    public class Bat : IEnemy
    {
        private BatStateMachine stateMachine;
        private BatBehavior behavior;
        private bool Perched = false;
        public ISprite2 mySprite;
        public Vector2 location;
        public float speed = 2f;
        private float FPS = 10;
        private float timer = 0f;
        private float stopTime = 1;

        public Bat(Vector2 start)
        {
            location = start;
            stateMachine = new BatStateMachine(this);
            behavior = new BatBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateBatSprite();
        }
        
        public void Slowdown(GameTime gameTime)
        {
            while (speed > 0)
            {
                speed = speed - speed / stopTime * (float)gameTime.ElapsedGameTime.TotalSeconds;
                FPS = FPS - FPS / stopTime * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        public void Perch(GameTime gameTime)
        {
            Slowdown(gameTime);
            stateMachine.Perched();
            Perched = true;
        }

        public void UnPerch()
        {
            speed = 2;
            FPS = 6;
            stateMachine.ChangeDirection();
            Perched = false;
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
    }
}
