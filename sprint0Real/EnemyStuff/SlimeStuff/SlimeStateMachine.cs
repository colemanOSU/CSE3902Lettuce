using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.EnemyStuff.BatStuff;
using sprint0Real.EnemyStuff.SlimeStuff;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemStuff;
using System;

namespace sprint0Real.EnemyStuff.SlimeStuff
{
    public class SlimeStateMachine : IStateMachine
    {
        private enum SlimeStates {Left, Right, Up, Down}
        private SlimeStates currentState = SlimeStates.Right;
        private Slime mySlime;
        private Random random = new Random();
        private SoundEffect EnemyDie;
        private bool DieSoundPlayed = false;
        public SlimeStateMachine(Slime Slime)
        {
            mySlime = Slime;
            EnemyDie = SoundEffectFactory.Instance.getEnemyDie();
        }

        public void TakeDamage(int damage)
        {
            mySlime.Health -= damage;
            if (mySlime.Health <= 0)
            {
                if (!DieSoundPlayed)
                {
                    EnemyDie.Play();
                    DieSoundPlayed = true;
                }
                DropManager.Instance.OnDeath(mySlime.location);
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
                    mySlime.location = new Vector2(mySlime.location.X - mySlime.speed, mySlime.location.Y);
                    break;
                case SlimeStates.Left:
                    mySlime.location = new Vector2(mySlime.location.X + mySlime.speed, mySlime.location.Y);
                    break;
                case SlimeStates.Up:
                    mySlime.location = new Vector2(mySlime.location.X, mySlime.location.Y - mySlime.speed);
                    break;
                case SlimeStates.Down:
                    mySlime.location = new Vector2(mySlime.location.X, mySlime.location.Y + mySlime.speed);
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case SlimeStates.Right:
                    mySlime.location = new Vector2(mySlime.location.X - mySlime.speed, mySlime.location.Y);
                    break;
                case SlimeStates.Left:
                    mySlime.location = new Vector2(mySlime.location.X + mySlime.speed, mySlime.location.Y);
                    break;
                case SlimeStates.Up:
                    mySlime.location = new Vector2(mySlime.location.X, mySlime.location.Y - mySlime.speed);
                    break;
                case SlimeStates.Down:
                    mySlime.location = new Vector2(mySlime.location.X, mySlime.location.Y + mySlime.speed);
                    break;
            }
        }
    }
}