using System;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DinoStuff
{
    public class DinoStateMachine : IStateMachine
    {
        private Dino myDino;
        private Random random = new Random();
        public enum DinoStates { Left, Right, Up, Down, DamagedRight, DamagedLeft, DamagedUp, DamagedDown}
        public DinoStates currentState { get; set; }

        public DinoStateMachine(Dino dino)
        {
            myDino = dino;
            currentState = DinoStates.Right;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = DinoStates.Right;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtRightSprite();
                    break;
                case 1:
                    currentState = DinoStates.Left;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtLeftSprite();
                    break;
                case 2:
                    currentState = DinoStates.Up;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtUpSprite();
                    break;
                case 3:
                    currentState = DinoStates.Down;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtDownSprite();
                    break;
            }
        }

        private void ChangeToDamageSprite()
        {
            switch (currentState)
            {
                case DinoStates.Right:
                    currentState = DinoStates.DamagedRight;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtRightSprite();
                    break;
                case DinoStates.Left:
                    currentState = DinoStates.DamagedLeft;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtRightSprite();
                    break;
                case DinoStates.Up:
                    currentState = DinoStates.DamagedUp;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtRightSprite();
                    break;
                case DinoStates.Down:
                    currentState = DinoStates.DamagedDown;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtRightSprite();
                    break;
            }
        }

        public void TakeDamage(int damage)
        {
            myDino.health -= damage;
            if (myDino.health < 0)
            {
                //death
            }
            else
            {
                ChangeToDamageSprite();
            }
        }

        public void FinishDamage()
        {
            switch (currentState)
            {
                case DinoStates.DamagedRight:
                    currentState = DinoStates.Right;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoRightSprite();
                    break;
                case DinoStates.DamagedLeft:
                    currentState = DinoStates.Left;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoRightSprite();
                    break;
                case DinoStates.DamagedUp:
                    currentState = DinoStates.Up;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoRightSprite();
                    break;
                case DinoStates.DamagedDown:
                    currentState = DinoStates.Down;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoRightSprite();
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case DinoStates.Right:
                    myDino.location = new Vector2(myDino.location.X - myDino.speed, myDino.location.Y);
                    break;
                case DinoStates.Left:
                    myDino.location = new Vector2(myDino.location.X + myDino.speed, myDino.location.Y);
                    break;
                case DinoStates.Up:
                    myDino.location = new Vector2(myDino.location.X, myDino.location.Y - myDino.speed);
                    break;
                case DinoStates.Down:
                    myDino.location = new Vector2(myDino.location.X, myDino.location.Y + myDino.speed);
                    break;
            }
        }
    }
}
