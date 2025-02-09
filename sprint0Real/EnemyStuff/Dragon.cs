using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.EnemyStuff
{
    public class Dragon
    {
        private DragonStateMachine stateMachine;
        private DragonBehavior behavior;
        
        public GameTime time;
        public ISprite mySprite;
        public Vector2 location;
        public int speed = 10;
        public int health = 10;

        public Dragon(GameTime gameTime)
        {
            time = gameTime;
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
            stateMachine.TakeDamage();
        }

        public void Attack()
        {
            stateMachine.Attack();
        }

        public void Update(GameTime time)
        {
            // Updates the location
            stateMachine.Update();
            // Moves onto the next frame in animation
            mySprite.Update(Game1.Instance._spriteBatch, Game1.Instance.linkSheet);
            // Draws the new frame
            mySprite.Draw(Game1.Instance._spriteBatch, location);
            // Updates the state based on external states
            behavior.Update(time);
        }
    }
}
