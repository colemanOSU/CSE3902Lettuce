using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Audio;
using sprint0Real.EnemyStuff.BatStuff;
using sprint0Real.EnemyStuff.DeathSprites;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class DragonStateMachine : IStateMachine
    {
        public DragonStateMachine() { }

        private enum DragonState { Idle, Attack, Damaged };
        private DragonState currentState = DragonState.Idle;
        private Dragon myDragon;
        private bool DieSoundPlayed = false;
        private Death death;

        // All the transitions possible
        public DragonStateMachine(Dragon dragon)
        {
            myDragon = dragon;
        }

        public void ChangeDirection()
        {
            // Just make make the speed negative
            myDragon.speed *= -1;
        }

        public void TakeDamage(int damage)
        {
            if (currentState != DragonState.Damaged)
            {
                myDragon.Health -= damage;
                currentState = DragonState.Damaged;
                myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonDamagedSprite();
            }
            if (myDragon.Health <= 0)
            {
                if (!DieSoundPlayed)
                {
                    SoundEffectFactory.Instance.Play(SoundEffectType.EnemyDie);
                    DieSoundPlayed=true;
                }
                myDragon.StageItem();
                CurrentMap.Instance.DeStage(myDragon);
                death = new Death(myDragon.location);
                CurrentMap.Instance.Stage(death);
            }
        }

        public void Attack()
        {
            currentState = DragonState.Attack;
            myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonAttackSprite();
        }

        public void Idle()
        {
            currentState = DragonState.Idle;
            myDragon.mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
        }

        public void Update()
        {
            myDragon.location = new Vector2(myDragon.location.X + myDragon.speed, myDragon.location.Y);
        }
    }
}
