using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.BladeTrapStuff
{
    public class BladeTrapStateMachine : IStateMachine
    {
        private enum BladeTrapStates {Left, Right, Up, Down}
        private BladeTrapStates currentState = BladeTrapStates.Right;
        private BladeTrap myBladeTrap;
        private Random random = new Random();

        public BladeTrapStateMachine(BladeTrap BladeTrap)
        {
            myBladeTrap = BladeTrap;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = BladeTrapStates.Right;
                    break;
                case 1:
                    currentState = BladeTrapStates.Left;
                    break;
                case 2:
                    currentState = BladeTrapStates.Up;
                    break;
                case 3:
                    currentState = BladeTrapStates.Down;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case BladeTrapStates.Right:
                    myBladeTrap.location.X -= myBladeTrap.speed;
                    break;
                case BladeTrapStates.Left:
                    myBladeTrap.location.X += myBladeTrap.speed;
                    break;
                case BladeTrapStates.Up:
                    myBladeTrap.location.Y -= myBladeTrap.speed;
                    break;
                case BladeTrapStates.Down:
                    myBladeTrap.location.Y += myBladeTrap.speed;
                    break;
            }
        }
    }
}