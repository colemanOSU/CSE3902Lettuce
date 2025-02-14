using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.SkeletonStuff
{
    public class SkeletonStateMachine : IStateMachine
    {
        private enum SkeletonStates {Left, Right, Up, Down}
        private SkeletonStates currentState = SkeletonStates.Right;
        private Skeleton mySkeleton;
        private Random random = new Random();

        public SkeletonStateMachine(Skeleton Skeleton)
        {
            mySkeleton = Skeleton;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = SkeletonStates.Right;
                    break;
                case 1:
                    currentState = SkeletonStates.Left;
                    break;
                case 2:
                    currentState = SkeletonStates.Up;
                    break;
                case 3:
                    currentState = SkeletonStates.Down;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case SkeletonStates.Right:
                    mySkeleton.location.X -= mySkeleton.speed;
                    break;
                case SkeletonStates.Left:
                    mySkeleton.location.X += mySkeleton.speed;
                    break;
                case SkeletonStates.Up:
                    mySkeleton.location.Y -= mySkeleton.speed;
                    break;
                case SkeletonStates.Down:
                    mySkeleton.location.Y += mySkeleton.speed;
                    break;
            }
        }
    }
}