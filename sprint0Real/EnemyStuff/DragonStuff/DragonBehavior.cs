using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.EnemyStuff.DragonStuff
{

    public class DragonBehavior
    {
        private Dragon myDragon;

        private float attackDelay = 5f;
        private float attackTimer = 0f;
        private float attackDuration = 2f;
        private bool attackFlag = false;

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;

        private float damageTimer;
        private float damageDuration = 1f;
        private bool damageFlag = false;

        private Random random = new Random();

        public DragonBehavior(Dragon dragon)
        {
            myDragon = dragon;
        }

        private void SafeJuke()
        {
            if (myDragon.location.X >= EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myDragon.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                myDragon.ChangeDirection();
            }
            else if (myDragon.location.X <= 0)
            {
                jukeTimer = 0;
                myDragon.location.X = 0;
                myDragon.ChangeDirection();
            }
        }
        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 2);
                myDragon.ChangeDirection();
            }
        }
        private void AttackCheck()
        {
            if (attackDelay <= attackTimer)
            {
                attackTimer = 0;
                myDragon.Attack();
                attackFlag = true;
            }
        }
        private void AttackFinish()
        {
            if (attackFlag && attackTimer >= attackDuration)
            {
                attackFlag = false;
                attackTimer = 0;
                myDragon.Idle();
            }
        }

        public void TakeDamage()
        {
            damageFlag = true;
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            
            JukeCheck();
            // Gotta make sure the dragon doesn't juke it's way off screen
            SafeJuke();
            AttackCheck();
            AttackFinish();

            if (damageFlag)
            {
                damageTimer += (float)time.ElapsedGameTime.TotalSeconds;
                if (damageTimer >= damageDuration)
                {
                    damageTimer = 0;
                    damageFlag = false;
                    myDragon.Idle();
                }
            }
            else
            {
                // Don't want to be attacking while damaged
                attackTimer += (float)time.ElapsedGameTime.TotalSeconds;
            }

        }
    }
}
