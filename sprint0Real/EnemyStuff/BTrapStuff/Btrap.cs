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

        public ISprite2 mySprite;
        private Vector2 Location;
        private TimeSpan stunTimer = TimeSpan.Zero;
        public bool IsStunned => stunTimer > TimeSpan.Zero;
        public int speed {  get; set; }


        private int FPS = 6;
        private float timer = 0f;

        public BTrap(Vector2 start)
        {
            Location = start;
            stateMachine = new BTrapStateMachine(this);
            mySprite = EnemySpriteFactory.Instance.CreateBTrapSprite();
            speed = 2;
        }

        public void TakeDamage(int damage)
        {
            //doesn't take damage
        }

        public void ChangeDirection()
        {
            stateMachine.Returned();
        }

        public void hitWall()
        {
            stateMachine.hitWall();
        }
        public void Stun(TimeSpan duration)
        {
            stunTimer = duration;
        }

        public void Return()
        {
            stateMachine.Return();
        }

        public void Update(GameTime gameTime)
        {
            if (IsStunned)
            {
                stunTimer -= gameTime.ElapsedGameTime;
                return;
            }
            stateMachine.Update();

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
                return new Rectangle((int)location.X, (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
        }

        public Vector2 location
        {
            get { return Location; }
            set { Location = value; }
        }
    }
}
