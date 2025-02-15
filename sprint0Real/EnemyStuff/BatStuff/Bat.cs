using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.BatStuff
{
    public class Bat : IEnemy
    {
        private BatStateMachine stateMachine;
        private BatBehavior behavior;
        private bool Perched = true;
        public ISprite2 mySprite;
        public Vector2 location;
        public float speed = 2f;
        private float FPS = 6;
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
            if (FPS >= 3f)
            {
                FPS = FPS - 1/60f;
            }
            if (FPS < 3f)
            {
                Perched = true;
            }
        }

        public void UnPerch()
        {
            if (FPS <= 6f)
            {
                FPS = FPS + 1/60f;
            }
            if (FPS > 0)
            {
                Perched = false;
            }
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
            behavior.Update(gameTime);
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= (1 / FPS) && !Perched)
            {
                timer = 0f;
                stateMachine.Update();
                mySprite.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }
    }
}
