using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.EnemyStuff.BoomerangStuff;
using sprint0Real.EnemyStuff.RedGoriya;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.GoriyaStuff
{
    public class GoriyaStateMachine : IStateMachine
    {
        private enum AttackStates {Idle, Attack}
        private GoriyaState currentState = GoriyaState.Right;
        private AttackStates attackStatus = AttackStates.Idle;
        private Goriya myGoriya;
        private Random random = new Random();

        public GoriyaStateMachine(Goriya Goriya)
        {
            myGoriya = Goriya;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = GoriyaState.Right;
                    myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
                    break;
                case 1:
                    currentState = GoriyaState.Left;
                    myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
                    break;
                case 2:
                    currentState = GoriyaState.Up;
                    myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
                    break;
                case 3:
                    currentState = GoriyaState.Down;
                    myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
                    break;
            }
        }

        public void TakeDamage()
        {
            myGoriya.health -= 1;
            if (myGoriya.health <= 0)
            {
                CurrentMap.Instance.DeStage(myGoriya);
            }
            else
            {
                switch (currentState)
                {
                    case GoriyaState.Right:
                        myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaRightDamaged();
                        break;
                    case GoriyaState.Left:
                        myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaLeftDamaged();
                        break;
                    case GoriyaState.Up:
                        myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaUpDamaged();
                        break;
                    case GoriyaState.Down:
                        myGoriya.mySprite = EnemySpriteFactory.Instance.CreateGoriyaDownDamaged();
                        break;
                }
            }
        }

        public void Attack()
        {
            attackStatus = AttackStates.Attack;
            CurrentMap.Instance.Stage(new Boomerang(myGoriya.location, currentState));
        }

        public void Idle()
        {
            attackStatus = AttackStates.Idle;
        }

        public void Update()
        {
              if (attackStatus != AttackStates.Attack)
            {
                switch (currentState)
                {
                    case GoriyaState.Right:
                        myGoriya.location.X -= myGoriya.speed;
                        break;
                    case GoriyaState.Left:
                        myGoriya.location.X += myGoriya.speed;
                        break;
                    case GoriyaState.Up:
                        myGoriya.location.Y -= myGoriya.speed;
                        break;
                    case GoriyaState.Down:
                        myGoriya.location.Y += myGoriya.speed;
                        break;
                }
            }
        }
    }
}