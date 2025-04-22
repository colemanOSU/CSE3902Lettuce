using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DinoStuff
{
    public class Dino : IEnemy
    {
        private DinoStateMachine DinoStateMachine;
        private DinoBehavior DinoBehavior;
        public ISprite2 mySprite { get; set; }
        public int speed { get; set; }
        private TimeSpan stunTimer = TimeSpan.Zero;
        public bool IsStunned => stunTimer > TimeSpan.Zero;
        public Rectangle Location { get; set; }
        public int health { get; set; }

        private int FPS = 6;
        private float timer = 0f;


        public Dino(Vector2 location)
        { 
            DinoStateMachine = new DinoStateMachine(this);
            DinoBehavior = new DinoBehavior(this);
            Location = new Rectangle((int)location.X, (int)location.Y, 28 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            speed = 2;
            health = 10;
            mySprite = EnemySpriteFactory.Instance.CreateDinoRightSprite();
        }

        public void ChangeDirection()
        {
            DinoStateMachine.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /** 
                This is redundant in that directly inputting the location Rectangle would be better.
                However, due to how I originally set up the interface, which takes a vector, 
                this becomes necessary. While refactoring is best, time constraints warrant 
                this hack. 
            **/
            mySprite.Draw(spriteBatch, new Vector2(Location.X, Location.Y));
        }

        public void TakeDamage(int damage)
        {
            if (IsStunned)
            {
                return;
            }
            // Depends on amount of damage a bomb does
            if (damage > 0)
            {
                DinoBehavior.TakeDamage();
                DinoStateMachine.TakeDamage(damage);
            }
        }
        public void Stun(TimeSpan duration)
        {
            stunTimer = duration;
        }
        public void FinishDamage()
        {
            DinoStateMachine.FinishDamage();
        }

        public void Update(GameTime gameTime)
        {
            if (IsStunned)
            {
                stunTimer -= gameTime.ElapsedGameTime;
                return;
            }
            DinoBehavior.Update(gameTime);
            DinoStateMachine.Update();

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= ((float)1 / FPS))
            {
                timer = 0f;
                mySprite.Update();
            }
        }

        public Vector2 location
        {
            get { return new Vector2(Location.X, Location.Y); }
            set { Location = new Rectangle((int)value.X, (int)value.Y, Location.Width, Location.Height); }
        }
        public Rectangle Rect
        {
            get
            {
                return Location;
            }
        }
    }
}
