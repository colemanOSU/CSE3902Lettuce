using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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

        public void Update(GameTime time)
        {
            
        }
    }
}
