using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.SkeletonStuff;

namespace sprint0Real.EnemyStuff.DinoStuff
{

    public class DinoBehavior
    {
        private Dino myDino;
        private float jukeTimer = 0f;
        private float jukeDelay = 0f;

        private bool damageFlag = false;
        private float damageTimer = 0f;
        private float damageDelay = 0f;

        private Random random = new Random();

        public DinoBehavior(Dino dino)
        {
            myDino = dino;
        }

        public void TakeDamage()
        {
            damageFlag = true;
        }

        private void DamageCheck()
        {
            if (damageTimer > damageDelay)
            {
                damageTimer = 0f;
                damageFlag = false;
                myDino.FinishDamage();
            }
        }

        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 1);
                myDino.ChangeDirection();
            }
        }

        public void Update(GameTime time)
        {
            if (damageFlag)
            {
                damageTimer += (float)time.ElapsedGameTime.TotalSeconds;
                DamageCheck();
            }
            else
            {
                // We don't want to move while taking damage
                jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
                JukeCheck();
            }
        }
    }
}
