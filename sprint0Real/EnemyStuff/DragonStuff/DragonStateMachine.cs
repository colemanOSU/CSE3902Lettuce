using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class DragonStateMachine : IStateMachine
    {
        public DragonStateMachine() { }

        private enum DragonState { Idle, Attack, Damaged };
        private DragonState currentState = DragonState.Idle;
        private Dragon myDragon;
        private SoundEffect EnemyDie;
        private bool DieSoundPlayed = false;

        // All the transitions possible
        public DragonStateMachine(Dragon dragon)
        {
            myDragon = dragon;
            EnemyDie = SoundEffectFactory.Instance.getEnemyDie();
        }

        public void ChangeDirection()
        {
            // Just make make the speed negative
            myDragon.speed *= -1;
        }

        public void TakeDamage(int damage)
        {
            myDragon.Health -= damage;
            currentState = DragonState.Damaged;
            if (myDragon.Health <= 0)
            {
                if (!DieSoundPlayed)
                {
                    EnemyDie.Play();
                    DieSoundPlayed=true;
                }
                CurrentMap.Instance.DeStage(myDragon);
            }
            else
            {
                myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonDamagedSprite();
            }
        }

        public void Attack()
        {
            myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonAttackSprite();
        }

        public void Idle()
        {
            myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
        }

        public void Update()
        {
            myDragon.location = new Vector2(myDragon.location.X + myDragon.speed, myDragon.location.Y);
        }
    }
}
