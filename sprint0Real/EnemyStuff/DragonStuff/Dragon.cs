using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.Fireballs;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class Dragon : IEnemy
    {
        private DragonStateMachine stateMachine;
        private DragonBehavior behavior;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 2;
        public int health = 10;

        private int FPS = 6;
        private float timer = 0f;

        public Dragon(Vector2 placement)
        {
            location = placement;
            stateMachine = new DragonStateMachine(this);
            behavior = new DragonBehavior(this);
            mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
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

        public void hitWall()
        {
            //stateMachine.hitWall();
            stateMachine.ChangeDirection();
        }


        public void Attack()
        {
            DragonAttack attack = new DragonAttack(location, new Vector2(EnemySpriteFactory.Instance.myGame.Link.GetLocation().X, EnemySpriteFactory.Instance.myGame.Link.GetLocation().Y));
            attack.Attack();
            stateMachine.Attack();
        }

        public void Idle()
        {
            stateMachine.Idle();
        }

        public void Update(GameTime time)
        {
            // Updates the location
            stateMachine.Update();
            // Moves onto the next frame in animation
            timer += (float) time.ElapsedGameTime.TotalSeconds;
            if (timer >= ((float) 1 / FPS))
            {
                timer = 0f;
                mySprite.Update();
            }
            // Updates the state based on external states
            behavior.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }
    }
}
