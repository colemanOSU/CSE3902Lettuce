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

namespace sprint0Real.EnemyStuff.BTrapStuff
{
    public class BTrap : IEnemy
    {
        private BTrapStateMachine stateMachine;
        private BTrapBehavior behavior;

        public ISprite2 mySprite;
        private Vector2 Location;
        public int speed = 4;

        private int FPS = 6;
        private float timer = 0f;

        public BTrap(Vector2 start)
        {
            Location = start;
            stateMachine = new BTrapStateMachine(this);
            behavior = new BTrapBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateBTrapSprite();
        }

        public void TakeDamage(int damage)
        {
            //doesn't take damage
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void hitWall()
        {
            stateMachine.hitWall();
        }

        public void Return()
        {
            stateMachine.Return();
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
                return new Rectangle((int)location.X, (int)location.Y, 30, 30);
            }
        }

        public Vector2 location
        {
            get { return Location; }
            set { Location = value; }
        }
    }
}
