﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.BoomerangStuff;
using sprint0Real.EnemyStuff.GoriyaStuff;
using sprint0Real.EnemyStuff.RedGoriya;

namespace sprint0Real.EnemyStuff.RedGoriyaStuff
{
    public class GoriyaBehavior
    {
        private Goriya myGoriya;

        public GoriyaBehavior(Goriya goriya) {
            myGoriya = goriya;
        }

        private float attackTimer = 0f;
        private float attackDelay = 5f;
        private bool attackFlag = false;
        
        private float jukeTimer = 0f;
        private float jukeDelay = 0f;

        private float damageTimer;
        private float damageDuration = 1f;
        private bool damageFlag = false;


        private Random random = new Random();
        private void JukeCheck()
        {
            if (!attackFlag && jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 2);
                myGoriya.ChangeDirection();
            }
        }
        private void AttackCheck()
        {
            if (attackDelay <= attackTimer)
            {
                attackTimer = 0;
                myGoriya.Attack();
                attackFlag = true;
            }
        }

        private bool Overlaps()
        {
            // Do you ever realize you're doing something so horribly but the colossal effort of making a
            // tedious, but necessary change is so monumental that you instead choose to ignore it?
            return (myGoriya.boomerang.location.X >= myGoriya.location.X && myGoriya.boomerang.location.X <= myGoriya.location.X + 30 && myGoriya.boomerang.location.Y >= myGoriya.location.Y && myGoriya.boomerang.location.Y <= myGoriya.location.Y + 30);
        }

        private void AttackFinish()
        {
            if (attackFlag && Overlaps() && myGoriya.boomerang.Hit)
            {
                attackFlag = false;
                myGoriya.boomerang.Caught();
                myGoriya.Idle();
            }
        }

        public void TakeDamage()
        {
            damageFlag = true;
        }

        private void FinishDamage()
        {
            damageTimer = 0;
            damageFlag = false;
            myGoriya.FinishDamage();
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            if (!attackFlag)
            {
                attackTimer += (float)time.ElapsedGameTime.TotalSeconds;
            }

            JukeCheck();
            AttackCheck();
            AttackFinish();

            if (damageFlag)
            {
                damageTimer += (float)time.ElapsedGameTime.TotalSeconds;
                if (damageTimer >= damageDuration)
                {
                    FinishDamage();
                }
            }
        }
    }
}
