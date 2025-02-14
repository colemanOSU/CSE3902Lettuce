using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class DragonStateMachine : IStateMachine
    {
        public DragonStateMachine() { }

        private enum DragonState { Idle, Attack, Damaged };
        private DragonState currentState = DragonState.Idle;
        private Dragon myDragon;

        // All the transitions possible
        public DragonStateMachine(Dragon dragon)
        {
            myDragon = dragon;
        }

        public void ChangeDirection()
        {
            // Just make make the speed negative
            myDragon.speed *= -1;
        }

        public void TakeDamage()
        {
            myDragon.health -= 1;
            currentState = DragonState.Damaged;
            if (myDragon.health <= 0)
            {
                CurrentMap.Instance.DeStage(myDragon);
            }
            else
            {
                myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonDamagedSprite();
            }
        }

        public void Attack()
        {
            myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonAttackSprite();
        }

        public void Idle()
        {
            myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
        }

        public void Update()
        {
            switch (currentState)
            {
                case DragonState.Idle:
                    myDragon.location.X += myDragon.speed;
                    break;
                case DragonState.Attack:
                    myDragon.location.X += myDragon.speed;
                    break;
                case DragonState.Damaged:
                    myDragon.location.X += myDragon.speed;
                    break;
            }
        }
    }
}
