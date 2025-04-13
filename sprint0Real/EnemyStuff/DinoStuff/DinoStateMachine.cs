using System;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

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
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoRightSprite();
                    myDino.Location = new Rectangle(myDino.Location.X, myDino.Location.Y, 28 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
                    break;
                case 1:
                    currentState = DinoStates.Left;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoLeftSprite();
                    myDino.Location = new Rectangle(myDino.Location.X, myDino.Location.Y, 28 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
                    break;
                case 2:
                    currentState = DinoStates.Up;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoUpSprite();
                    myDino.Location = new Rectangle(myDino.Location.X, myDino.Location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
                    break;
                case 3:
                    currentState = DinoStates.Down;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoDownSprite();
                    myDino.Location = new Rectangle(myDino.Location.X, myDino.Location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
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
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtLeftSprite();
                    break;
                case DinoStates.Up:
                    currentState = DinoStates.DamagedUp;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtUpSprite();
                    break;
                case DinoStates.Down:
                    currentState = DinoStates.DamagedDown;
                    myDino.mySprite = EnemySpriteFactory.Instance.CreateDinoHurtDownSprite();
                    break;
            }
        }
        private bool NotDamaged()
        {
            return (currentState != DinoStates.DamagedDown && currentState != DinoStates.DamagedUp && currentState != DinoStates.DamagedLeft && currentState != DinoStates.DamagedRight);
        }
        public void TakeDamage(int damage)
        {
            if (NotDamaged())
            {
                myDino.health -= damage;
                ChangeToDamageSprite();
            }
            
            if (myDino.health < 0)
            {
                // Add sound effects?
                CurrentMap.Instance.DeStage(myDino);
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
            Rectangle currentRect = myDino.Location;
            switch (currentState)
            {   
                case DinoStates.Right:
                    myDino.Location = new Rectangle(currentRect.X + myDino.speed, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;
                case DinoStates.Left:
                    myDino.Location = new Rectangle(currentRect.X - myDino.speed, currentRect.Y, currentRect.Width, currentRect.Height);
                    break;
                case DinoStates.Up:
                    myDino.Location = new Rectangle(currentRect.X, currentRect.Y - myDino.speed, currentRect.Width, currentRect.Height);
                    break;
                case DinoStates.Down:
                    myDino.Location = new Rectangle(currentRect.X, currentRect.Y + myDino.speed, currentRect.Width, currentRect.Height);
                    break;
            }
        }
    }
}
