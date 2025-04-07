using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.HandStuff;

namespace sprint0Real.EnemyStuff.HandStuff
{
    internal class HandBehavior
    {
        private Hand myHand;

        public HandBehavior(Hand Hand)
        {
            myHand = Hand;
        }

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;


        private Random random = new Random();

        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 1);
                myHand.ChangeDirection();
            }
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            JukeCheck();
        }
    }
}
