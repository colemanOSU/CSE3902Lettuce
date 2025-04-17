using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Audio;
using sprint0Real.EnemyStuff.DeathSprites;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;
using System;

namespace sprint0Real.EnemyStuff.BatStuff
{
    public class BatStateMachine : IStateMachine
    {
        private enum BatStates {LeftUp, RightUp, LeftDown, RightDown, Left, Right, Up, Down, Perched}
        private BatStates currentState = BatStates.Right;
        private Bat myBat;
        private float SqrtSpeed;
        private Random random = new Random();
        private bool DieSoundPlayed = false;
        private Death death;

        public BatStateMachine(Bat Bat)
        {
            myBat = Bat;
            SqrtSpeed = (float)Math.Sqrt((Math.Pow(Bat.speed,2))/2);
        }
        public void Perched()
        {
            currentState = BatStates.Perched;
        }

        public void TakeDamage(int damage)
        {
            myBat.Health -= damage; 
            if (myBat.Health < 0)
            {
                if (!DieSoundPlayed)
                {
                    SoundEffectFactory.Instance.Play(SoundEffectType.EnemyDie);
                    DieSoundPlayed = true;
                }
                DropManager.Instance.OnDeath(myBat.location);
                CurrentMap.Instance.DeStage(myBat);
                death = new Death(myBat.location);
                CurrentMap.Instance.Stage(death);

            }
        }
        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 8);
            switch (nextDirection)
            {
                case 0:
                    currentState = BatStates.Right;
                    break;
                case 1:
                    currentState = BatStates.Left;
                    break;
                case 2:
                    currentState = BatStates.Up;
                    break;
                case 3:
                    currentState = BatStates.Down;
                    break;
                case 4:
                    currentState = BatStates.LeftDown;
                    break;
                case 5:
                    currentState = BatStates.RightDown;
                    break;
                case 6:
                    currentState = BatStates.LeftUp;
                    break;
                case 7:
                    currentState = BatStates.RightUp;
                    break;
            }
        }

        public void Update()
        {
            switch (currentState)
            {
                case BatStates.Right:
                    myBat.location = new Vector2(myBat.location.X - myBat.speed, myBat.location.Y);
                    break;
                case BatStates.Left:
                    myBat.location = new Vector2(myBat.location.X + myBat.speed, myBat.location.Y);
                    break;
                case BatStates.Up:
                    myBat.location = new Vector2(myBat.location.X, myBat.location.Y - myBat.speed);
                    break;
                case BatStates.Down:
                    myBat.location = new Vector2(myBat.location.X, myBat.location.Y + myBat.speed);
                    break;
                case BatStates.LeftUp:
                    myBat.location = new Vector2(myBat.location.X + SqrtSpeed, myBat.location.Y - SqrtSpeed);
                    break;
                case BatStates.LeftDown:
                    myBat.location= new Vector2(myBat.location.X + SqrtSpeed, myBat.location.Y + SqrtSpeed);
                    break;
                case BatStates.RightUp:
                    myBat.location = new Vector2(myBat.location.X - SqrtSpeed, myBat.location.Y - SqrtSpeed); ;
                    break;
                case BatStates.RightDown:
                    myBat.location = new Vector2(myBat.location.X - SqrtSpeed, myBat.location.Y + SqrtSpeed); ;
                    break;
            }
        }
    }
}