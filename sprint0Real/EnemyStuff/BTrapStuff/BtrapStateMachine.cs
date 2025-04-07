using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.BTrapStuff;
using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.BTrapStuff
{
    public class BTrapStateMachine : IStateMachine
    {
        private enum BTrapStates { Left, Right, Up, Down }
        private bool ret = false;
        private BTrapStates currentState = BTrapStates.Right;
        private BTrap myBTrap;
        private Random random = new Random();

        public BTrapStateMachine(BTrap BTrap)
        {
            myBTrap = BTrap;
        }
        public void hitWall()
        {
            if (ret)
            {
                ret = false;
                ChangeDirection();
            }
            else
            {
                ret = true;
                Return();
            }
        }
        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = BTrapStates.Right;
                    break;
                case 1:
                    currentState = BTrapStates.Left;
                    break;
                case 2:
                    currentState = BTrapStates.Up;
                    break;
                case 3:
                    currentState = BTrapStates.Down;
                    break;
            }
        }
        public void Return()
        {
            switch (currentState)
            {
                case BTrapStates.Right:
                    currentState = BTrapStates.Left;
                    break;
                case BTrapStates.Left:
                    currentState = BTrapStates.Right;
                    break;
                case BTrapStates.Up:
                    currentState = BTrapStates.Up;
                    break;
                case BTrapStates.Down:
                    currentState = BTrapStates.Down;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case BTrapStates.Right:
                    myBTrap.location = new Vector2(myBTrap.location.X - myBTrap.speed, myBTrap.location.Y);
                    break;
                case BTrapStates.Left:
                    myBTrap.location = new Vector2(myBTrap.location.X + myBTrap.speed, myBTrap.location.Y);
                    break;
                case BTrapStates.Up:
                    myBTrap.location = new Vector2(myBTrap.location.X, myBTrap.location.Y - myBTrap.speed);
                    break;
                case BTrapStates.Down:
                    myBTrap.location = new Vector2(myBTrap.location.X, myBTrap.location.Y + myBTrap.speed);
                    break;
            }
        }
    }
}