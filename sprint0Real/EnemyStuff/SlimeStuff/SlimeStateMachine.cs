using sprint0Real.EnemyStuff.SkeletonStuff;
using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.SlimeStuff
{
    public class SlimeStateMachine : IStateMachine
    {
        private enum SlimeStates {Left, Right, Up, Down}
        private SlimeStates currentState = SlimeStates.Right;
        private Slime mySlime;
        private Random random = new Random();

        public SlimeStateMachine(Slime Slime)
        {
            mySlime = Slime;
        }

        public void TakeDamage(int damage)
        {
            mySlime.Health -= damage;
            if (mySlime.Health <= 0)
            {
                mySlime.Despawn();
            }
        }
        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = SlimeStates.Right;
                    break;
                case 1:
                    currentState = SlimeStates.Left;
                    break;
                case 2:
                    currentState = SlimeStates.Up;
                    break;
                case 3:
                    currentState = SlimeStates.Down;
                    break;
            }
        }

        public void hitWall()
        {
            switch (currentState)
            {
                case SlimeStates.Right:
                    mySlime.location.X += mySlime.speed;
                    break;
                case SlimeStates.Left:
                    mySlime.location.X -= mySlime.speed;
                    break;
                case SlimeStates.Up:
                    mySlime.location.Y += mySlime.speed;
                    break;
                case SlimeStates.Down:
                    mySlime.location.Y -= mySlime.speed;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case SlimeStates.Right:
                    mySlime.location.X -= mySlime.speed;
                    break;
                case SlimeStates.Left:
                    mySlime.location.X += mySlime.speed;
                    break;
                case SlimeStates.Up:
                    mySlime.location.Y -= mySlime.speed;
                    break;
                case SlimeStates.Down:
                    mySlime.location.Y += mySlime.speed;
                    break;
            }
        }
    }
}