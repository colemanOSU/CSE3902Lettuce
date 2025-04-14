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
        private Hand myHand;
        private SoundEffect EnemyDie;
        private bool DieSoundPlayed = false;
        public HandStateMachine(Hand Hand)
        {
            myHand = Hand;
            EnemyDie = SoundEffectFactory.Instance.getEnemyDie();
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
            myHand.location = new Vector2(myHand.location.X + myHand.speed.X, myHand.location.Y + myHand.speed.Y);
        }
    }
}