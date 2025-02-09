using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class Dragon : IEnemy
    {
        private DragonStateMachine stateMachine;
        private DragonBehavior behavior;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 3;
        public int health = 10;

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

        public void Update(GameTime time)
        {
            // Updates the location
            stateMachine.Update();
            // Moves onto the next frame in animation
            mySprite.Update();
            // Updates the state based on external states
            behavior.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }
    }
}
