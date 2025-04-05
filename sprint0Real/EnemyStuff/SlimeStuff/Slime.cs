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

namespace sprint0Real.EnemyStuff.SlimeStuff
{
    public class Slime : IEnemy
    {
        private SlimeStateMachine stateMachine;
        private SlimeBehavior behavior;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 2;

        private int FPS = 6;
        private float timer = 0f;
        private int health = 1;

        public Slime(Vector2 start)
        {
            location = start;
            stateMachine = new SlimeStateMachine(this);
            behavior = new SlimeBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateSlimeSprite();
        }
        public void hitWall()
        {
            stateMachine.hitWall();
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
                return new Rectangle((int)location.X, (int)location.Y, 7 * Game1.RENDERSCALE, 10 * Game1.RENDERSCALE);
            }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}
