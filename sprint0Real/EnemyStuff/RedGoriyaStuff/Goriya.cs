using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.BoomerangStuff;
using sprint0Real.EnemyStuff.GoriyaStuff;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.RedGoriya
{
    public class Goriya : IEnemy
    {
        private GoriyaStateMachine stateMachine;
        private GoriyaBehavior behavior;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 2;
        public int health = 10;
        public Boomerang boomerang;
        private int FPS = 6;
        private float timer = 0f;
        

        public Goriya(Vector2 placement)
        {
            location = placement;
            stateMachine = new GoriyaStateMachine(this);
            behavior = new GoriyaBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
            
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void TakeDamage()
        {
            behavior.TakeDamage();
            stateMachine.TakeDamage();
        }

        public void Attack()
        {
            stateMachine.Attack();
        }

        public void Idle()
        {
            stateMachine.Idle();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime time)
        {
            // Moves onto the next frame in animation
            timer += (float)time.ElapsedGameTime.TotalSeconds;
            
            if (timer >= ((float)1 / FPS))
            {
                timer = 0f;
                mySprite.Update();
            }

            behavior.Update(time);
            stateMachine.Update();
        }
    }
}
