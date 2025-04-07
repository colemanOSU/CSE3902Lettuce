using System;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.BatStuff;
using sprint0Real.EnemyStuff.BoomerangStuff;
using sprint0Real.EnemyStuff.RedGoriya;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

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
        public void hitWall()
        {
            switch (currentState)
            {
                case GoriyaState.Right:
                    myGoriya.location = new Vector2(myGoriya.location.X + myGoriya.speed, myGoriya.location.Y);
                    break;
                case GoriyaState.Left:
                    myGoriya.location = new Vector2(myGoriya.location.X - myGoriya.speed, myGoriya.location.Y);
                    break;
                case GoriyaState.Up:
                    myGoriya.location = new Vector2(myGoriya.location.X, myGoriya.location.Y+ myGoriya.speed);
                    break;
                case GoriyaState.Down:
                    myGoriya.location = new Vector2(myGoriya.location.X, myGoriya.location.Y - myGoriya.speed);
                    break;
            }
        }
        public void TakeDamage(int damage)
        {
            myGoriya.Health -= damage;
            if (myGoriya.Health <= 0)
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
            myGoriya.boomerang = new Boomerang(myGoriya.location, currentState);
            CurrentMap.Instance.Stage(myGoriya.boomerang);
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
                        myGoriya.location = new Vector2(myGoriya.location.X - myGoriya.speed, myGoriya.location.Y);
                        break;
                    case GoriyaState.Left:
                        myGoriya.location = new Vector2(myGoriya.location.X + myGoriya.speed, myGoriya.location.Y);
                        break;
                    case GoriyaState.Up:
                        myGoriya.location = new Vector2(myGoriya.location.X, myGoriya.location.Y - myGoriya.speed);
                        break;
                    case GoriyaState.Down:
                        myGoriya.location = new Vector2(myGoriya.location.X, myGoriya.location.Y + myGoriya.speed);
                        break;
                }
            }
        }
    }
}