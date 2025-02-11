using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class OctoStateMachine : IStateMachine
    {
        public OctoStateMachine() { }

        private enum DragonState { Idle, Attack, Damaged };
        private DragonState currentState = DragonState.Idle;
        private Octo myOcto;
        private int state=1;
        private int CD= 50;

        // All the transitions possible
        public OctoStateMachine(Octo octo)
        {
            myOcto = octo;
        }

        public void ChangeDirectionL()
        {
            // Just make make the speed negative
            myOcto.state = 4;
        }
        public void ChangeDirectionR()
        {
            // Just make make the speed negative
            myOcto.state = 2;
        }
        public void ChangeDirectionU()
        {
            // Just make make the speed negative
            myOcto.state = 1;
        }
        public void ChangeDirectionD()
        {
            // Just make make the speed negative
            myOcto.state = 3;
        }
        public int GetState()
        {
            // Just make make the speed negative
            return state;
        }
        public void TakeDamage()
        {
            myOcto.health -= 1;
            currentState = DragonState.Damaged;
            myOcto.mySprite = EnemySpriteFactory.Instance.CreateDragonDamagedSprite();
            EnemyPage.Instance.enemyList.Remove(myOcto);
        }

        public void Attack()
        {
            myOcto.mySprite = EnemySpriteFactory.Instance.CreateDragonAttackSprite();
        }

        public void Idle()
        {
            myOcto.mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
        }

        public void Update()
        {
            switch (currentState)
            {
                case DragonState.Idle:
                    if (CD <= 0)
                    {
                        Random rnd = new Random();
                        state = rnd.Next(1, 5);//5 is exclusive
                    }
                    if (state == 1)
                    {
                        myOcto.location.Y -= 1;
                    }
                    if (state == 2)
                    {
                        myOcto.location.X += 1;
                    }
                    if (state == 3)
                    {
                        myOcto.location.Y -= 1;
                    }
                    if (state == 4)
                    {
                        myOcto.location.X -= 1;
                    }
                    CD--;
                    break;
            }
        }
    }
}
