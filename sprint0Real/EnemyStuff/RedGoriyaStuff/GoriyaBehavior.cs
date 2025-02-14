using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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

        private void SafeJuke()
        {
            // THIS IS BAD CODE FIX!!!
            if (myGoriya.location.X > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myGoriya.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                myGoriya.ChangeDirection();
            }
            else if (myGoriya.location.X < 0)
            {
                jukeTimer = 0;
                myGoriya.location.X = 0;
                myGoriya.ChangeDirection();
            }
            else if (myGoriya.location.Y > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48)
            {
                jukeTimer = 0;
                myGoriya.location.Y = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48;
                myGoriya.ChangeDirection();
            }
            else if (myGoriya.location.Y < 0)
            {
                jukeTimer = 0;
                myGoriya.location.Y = 0;
                myGoriya.ChangeDirection();
            }
            
        }
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
        private void AttackFinish()
        {
            if (attackFlag && attackTimer >= attackDuration)
            {
                attackFlag = false;
                attackTimer = 0;
                myGoriya.Idle();
            }
        }

        public void TakeDamage()
        {
            damageFlag = true;
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            attackTimer += (float)time.ElapsedGameTime.TotalSeconds;
            JukeCheck();
            // Gotta make sure the Goriya doesn't juke it's way off screen
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
                    myGoriya.Idle();
                }
            }
        }
    }
}
