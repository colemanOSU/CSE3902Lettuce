using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using System;

namespace sprint0Real.EnemyStuff.HandStuff
{
    public class HandStateMachine : IStateMachine
    {
        private enum HandStates {Left, Right, Up, Down}
        private HandStates currentState = HandStates.Right;
        private Hand myHand;
        private Random random = new Random();

        public HandStateMachine(Hand Hand)
        {
            myHand = Hand;
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = HandStates.Right;
                    break;
                case 1:
                    currentState = HandStates.Left;
                    break;
                case 2:
                    currentState = HandStates.Up;
                    break;
                case 3:
                    currentState = HandStates.Down;
                    break;
            }
        }
        public void hitWall()
        {
            switch (currentState)
            {
                case HandStates.Right:
                    myHand.location.X += myHand.speed;
                    break;
                case HandStates.Left:
                    myHand.location.X -= myHand.speed;
                    break;
                case HandStates.Up:
                    myHand.location.Y += myHand.speed;
                    break;
                case HandStates.Down:
                    myHand.location.Y -= myHand.speed;
                    break;
            }
        }

        public void TakeDamage(int damage)
        {
            myHand.Health -= damage;
            if (myHand.Health <= 0)
            {
                CurrentMap.Instance.DeStage(myHand);
            }
        }
        

        public void Update()
        {
            switch (currentState)
            {
                case HandStates.Right:
                    myHand.location.X -= myHand.speed;
                    break;
                case HandStates.Left:
                    myHand.location.X += myHand.speed;
                    break;
                case HandStates.Up:
                    myHand.location.Y -= myHand.speed;
                    break;
                case HandStates.Down:
                    myHand.location.Y += myHand.speed;
                    break;
            }
        }
    }
}