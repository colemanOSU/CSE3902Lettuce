using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.BubbleStuff
{
    public class BubbleStateMachine : IStateMachine
    {
        private enum BubbleStates {Left, Right, Up, Down}
        private BubbleStates currentState = BubbleStates.Right;
        private Bubble myBubble;
        private Random random = new Random();

        public BubbleStateMachine(Bubble Bubble)
        {
            myBubble = Bubble;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = BubbleStates.Right;
                    break;
                case 1:
                    currentState = BubbleStates.Left;
                    break;
                case 2:
                    currentState = BubbleStates.Up;
                    break;
                case 3:
                    currentState = BubbleStates.Down;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case BubbleStates.Right:
                    myBubble.location.X -= myBubble.speed;
                    break;
                case BubbleStates.Left:
                    myBubble.location.X += myBubble.speed;
                    break;
                case BubbleStates.Up:
                    myBubble.location.Y -= myBubble.speed;
                    break;
                case BubbleStates.Down:
                    myBubble.location.Y += myBubble.speed;
                    break;
            }
        }
    }
}