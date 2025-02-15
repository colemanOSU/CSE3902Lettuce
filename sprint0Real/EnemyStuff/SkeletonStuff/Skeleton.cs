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

namespace sprint0Real.EnemyStuff.SkeletonStuff
{
    public class Skeleton : IEnemy
    {
        private SkeletonStateMachine stateMachine;
        private SkeletonBehavior behavior;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 2;

        private int FPS = 6;
        private float timer = 0f;

        public Skeleton(Vector2 start)
        {
            location = start;
            stateMachine = new SkeletonStateMachine(this);
            behavior = new SkeletonBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateSkeletonSprite();
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
