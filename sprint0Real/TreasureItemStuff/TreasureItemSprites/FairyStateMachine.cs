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
        private enum FairyStates { LeftDiagonal, RightDiagonal, Up, Down }
        private FairyStates currentState = FairyStates.Up;
        private Fairy myFairy;
        private Random random = new Random();

        public FairyStateMachine(Fairy fairy)
        {
            myFairy = fairy;
        }
        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = FairyStates.Up;
                    break;
                case 1:
                    currentState = FairyStates.Down;
                    break;
                case 2:
                    currentState = FairyStates.LeftDiagonal;
                    break;
                case 3:
                    currentState = FairyStates.RightDiagonal;
                    break;
            }
        }
        public void Update()
        {
            switch (currentState)
            {
                case FairyStates.RightDiagonal:
                    myFairy.location = new Vector2(myFairy.location.X + myFairy.speed, myFairy.location.Y + myFairy.speed);
                    break;
                case FairyStates.LeftDiagonal:
                    myFairy.location = new Vector2(myFairy.location.X - myFairy.speed, myFairy.location.Y + myFairy.speed);
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
