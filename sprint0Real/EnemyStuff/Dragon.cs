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
        public ISprite mySprite;
        public Vector2 location;
        public int speed = 10;
        public int health = 10;

        public Dragon()
        {
            stateMachine = new DragonStateMachine(this);
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

        public void Update()
        {
            mySprite.Update(Game1.Instance._spriteBatch, location);
            mySprite.Draw(Game1.Instance._spriteBatch, location);
        }
    }
}
