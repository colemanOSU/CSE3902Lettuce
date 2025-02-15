using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.ZolStuff
{
    public class ZolStateMachine : IStateMachine
    {
        private enum ZolStates {Left, Right, Up, Down}
        private ZolStates currentState = ZolStates.Right;
        private Zol myZol;
        private Random random = new Random();

        public ZolStateMachine(Zol Zol)
        {
            myZol = Zol;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = ZolStates.Right;
                    break;
                case 1:
                    currentState = ZolStates.Left;
                    break;
                case 2:
                    currentState = ZolStates.Up;
                    break;
                case 3:
                    currentState = ZolStates.Down;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case ZolStates.Right:
                    myZol.location.X -= myZol.speed;
                    break;
                case ZolStates.Left:
                    myZol.location.X += myZol.speed;
                    break;
                case ZolStates.Up:
                    myZol.location.Y -= myZol.speed;
                    break;
                case ZolStates.Down:
                    myZol.location.Y += myZol.speed;
                    break;
            }
        }
    }
}