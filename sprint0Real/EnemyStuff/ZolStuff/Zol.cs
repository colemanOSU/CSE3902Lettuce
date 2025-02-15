using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.GoriyaStuff;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.ZolStuff
{
    public class Zol : IEnemy
    {
        private ZolStateMachine stateMachine;
        private ZolBehavior behavior;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 1;

        private int FPS = 12;
        private float timer = 0f;

        public Zol(Vector2 start)
        {
            location = start;
            stateMachine = new ZolStateMachine(this);
            behavior = new ZolBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateZolSprite();
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
    }
}
