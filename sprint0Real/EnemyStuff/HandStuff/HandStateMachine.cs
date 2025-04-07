using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.EnemyStuff.BatStuff;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.EnemyStuff.HandStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;
using System;

namespace sprint0Real.EnemyStuff.HandStuff
{
    public class HandStateMachine : IStateMachine
    {
        private enum HandStates {Left, Right, Up, Down}
        private HandStates currentState = HandStates.Right;
        private Hand myHand;
        private Random random = new Random();
        private SoundEffect EnemyDie;
        private bool DieSoundPlayed = false;
        public HandStateMachine(Hand Hand)
        {
            myHand = Hand;
            EnemyDie = SoundEffectFactory.Instance.getEnemyDie();
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
                    myHand.location = new Vector2(myHand.location.X - myHand.speed, myHand.location.Y);
                    break;
                case HandStates.Left:
                    myHand.location = new Vector2(myHand.location.X + myHand.speed, myHand.location.Y);
                    break;
                case HandStates.Up:
                    myHand.location = new Vector2(myHand.location.X, myHand.location.Y - myHand.speed);
                    break;
                case HandStates.Down:
                    myHand.location = new Vector2(myHand.location.X, myHand.location.Y + myHand.speed);
                    break;
            }
        }

        public void TakeDamage(int damage)
        {
            myHand.Health -= damage;
            if (myHand.Health <= 0)
            {
                if (!DieSoundPlayed)
                {
                    EnemyDie.Play();
                    DieSoundPlayed = true;
                }
                DropManager.Instance.OnDeath(myHand.location);
                CurrentMap.Instance.DeStage(myHand);
            }
        }
        

        public void Update()
        {
            switch (currentState)
            {
                case HandStates.Right:
                    myHand.location = new Vector2(myHand.location.X - myHand.speed, myHand.location.Y);
                    break;
                case HandStates.Left:
                    myHand.location = new Vector2(myHand.location.X + myHand.speed, myHand.location.Y);
                    break;
                case HandStates.Up:
                    myHand.location = new Vector2(myHand.location.X, myHand.location.Y - myHand.speed);
                    break;
                case HandStates.Down:
                    myHand.location = new Vector2(myHand.location.X, myHand.location.Y + myHand.speed);
                    break;
            }
        }
    }
}