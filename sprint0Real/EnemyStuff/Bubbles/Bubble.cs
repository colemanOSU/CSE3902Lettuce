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
using sprint0Real.Levels;

namespace sprint0Real.EnemyStuff.BubbleStuff
{
    public class Bubble : IEnemy
    {
        private BubbleStateMachine stateMachine;
        private BubbleBehavior behavior;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 3;

        private int FPS = 12;
        private float timer = 0f;

        public Bubble(Vector2 start)
        {
            location = start;
            stateMachine = new BubbleStateMachine(this);
            behavior = new BubbleBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateBubbleSprite();
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
