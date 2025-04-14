using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using sprint0Real.EnemyStuff.SkeletonStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.TreasureItemStuff.TreasureItemSprites
{
    public class FairyStateMachine : IStateMachine
    {
        private enum FairyStates { LeftDiagonalDown, RightDiagonalDown, RightDiagonalUp, LeftDiagonalUp, Up, Down }
        private FairyStates currentState = FairyStates.Up;
        private Fairy myFairy;
        private Random random = new Random();

        public FairyStateMachine(Fairy fairy)
        {
            myFairy = fairy;
        }
        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 6);
            switch (nextDirection)
            {
                case 0:
                    currentState = FairyStates.Up;
                    break;
                case 1:
                    currentState = FairyStates.Down;
                    break;
                case 2:
                    currentState = FairyStates.LeftDiagonalDown;
                    break;
                case 3:
                    currentState = FairyStates.RightDiagonalDown;
                    break;
                case 4:
                    currentState = FairyStates.LeftDiagonalUp;
                    break;
                case 5:
                    currentState = FairyStates.RightDiagonalUp;
                    break;
            }
        }
        public void Update()
        {
            switch (currentState)
            {
                case FairyStates.RightDiagonalDown:
                    myFairy.location = new Vector2(myFairy.location.X + myFairy.speed, myFairy.location.Y + myFairy.speed);
                    break;
                case FairyStates.LeftDiagonalDown:
                    myFairy.location = new Vector2(myFairy.location.X - myFairy.speed, myFairy.location.Y + myFairy.speed);
                    break;
                case FairyStates.LeftDiagonalUp:
                    myFairy.location = new Vector2(myFairy.location.X - myFairy.speed, myFairy.location.Y - myFairy.speed);
                    break;
                case FairyStates.RightDiagonalUp:
                    myFairy.location = new Vector2(myFairy.location.X + myFairy.speed, myFairy.location.Y - myFairy.speed);
                    break;
                case FairyStates.Up:
                    myFairy.location = new Vector2(myFairy.location.X, myFairy.location.Y - myFairy.speed);
                    break;
                case FairyStates.Down:
                    myFairy.location = new Vector2(myFairy.location.X, myFairy.location.Y + myFairy.speed);
                    break;
            }
        }
    }
}
