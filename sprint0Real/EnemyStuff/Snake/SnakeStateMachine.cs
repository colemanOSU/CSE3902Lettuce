using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.SnakeStuff
{
    public class SnakeStateMachine : IStateMachine
    {
        private enum SnakeStates {Left, Right, Up, Down, Stop}
        private SnakeStates currentState = SnakeStates.Right;
        private Snake mySnake;
        private Random random = new Random();

        public SnakeStateMachine(Snake Snake)
        {
            mySnake = Snake;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 5);
            switch (nextDirection)
            {
                case 0:
                    currentState = SnakeStates.Right;
                    break;
                case 1:
                    currentState = SnakeStates.Left;
                    break;
                case 2:
                    currentState = SnakeStates.Up;
                    break;
                case 3:
                    currentState = SnakeStates.Down;
                    break;
                case 4:
                    currentState = SnakeStates.Stop;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case SnakeStates.Right:
                    mySnake.location.X -= mySnake.speed;
                    break;
                case SnakeStates.Left:
                    mySnake.location.X += mySnake.speed;
                    break;
                case SnakeStates.Up:
                    mySnake.location.Y -= mySnake.speed;
                    break;
                case SnakeStates.Down:
                    mySnake.location.Y += mySnake.speed;
                    break;
                //Stop does nothing so no movement. its there so I can implement lunge after a stop
            }
        }
    }
}