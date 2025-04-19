using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Audio;
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
        private enum HandStates {Entering, Returning, Shuffling};
        private HandStates Handstate;
        private Hand myHand;
        private bool DieSoundPlayed = false;
        private int DistanceTraveled = 0;
        private bool StunnedFlag = false;
        public HandStateMachine(Hand Hand)
        {
            Handstate = HandStates.Entering;
            myHand = Hand;
        }

        public void Return()
        {
            Handstate = HandStates.Returning;
            if (myHand.YGreaterThanHalf)
            {
                myHand.speed = new Vector2(0, -myHand.movementSpeed);
            }
            else
            {
                myHand.speed = new Vector2(0, myHand.movementSpeed);
            }
        }

        public void MoveSideways()
        {
            Handstate = HandStates.Shuffling;
            if ( myHand.YGreaterThanHalf)
            {
                myHand.speed = new Vector2(-myHand.movementSpeed, 0);
            }
            else
            {
                myHand.speed = new Vector2(myHand.movementSpeed, 0);
            }
        }

        public void TakeDamage(int damage)
        {
            myHand.Health -= damage;
            if (myHand.Health <= 0)
            {
                if (!DieSoundPlayed)
                {
                    SoundEffectFactory.Instance.Play(SoundEffectType.EnemyDie);
                    DieSoundPlayed = true;
                }
                DropManager.Instance.OnDeath(myHand.location);
                CurrentMap.Instance.DeStage(myHand);
            }
        }

        public void Stun()
        {
            StunnedFlag = true;
        }

        public void UnStun()
        {
            StunnedFlag = false;
        }

        public void Update()
        {
            // Don't want to move if stunned
            if (!StunnedFlag)
            {
                // Want precise measurements for entering so record when entering
                if (Handstate == HandStates.Entering)
                {
                    DistanceTraveled += (int)myHand.speed.Y;
                    if (Math.Abs(DistanceTraveled) >= 144)
                    {
                        myHand.MoveSideways();
                    }
                }
                myHand.location = new Vector2(myHand.location.X + myHand.speed.X, myHand.location.Y + myHand.speed.Y);
            }
        }
    }
}