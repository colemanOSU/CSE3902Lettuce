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

        private bool returnFlag = false;
        private float returnTimer = 0f;
        private float returnDelay = 0f;

        private bool stunFlag = false;
        private float stunTimer = 0f;
        private float stunDelay = 2f;

        private Random random = new Random();

        public void StartReturnTimer()
        {
            returnFlag = true;
            returnDelay = (float)(random.NextDouble() * 2 + 3);
        }

        private void ReturnCheck()
        {
            if (returnDelay <= returnTimer)
            {
                myHand.Return();
            }
        }

        public void Stun()
        {
            stunFlag = true;
        }

        private void StunCheck()
        {
            if (stunDelay <= stunTimer)
            {
                stunFlag = false;
                myHand.UnStun();
            }
        }

        public void Update(GameTime time)
        {
            if (returnFlag && !stunFlag)
            {
                returnTimer += (float)time.ElapsedGameTime.TotalSeconds;
                ReturnCheck();
            }
            if (stunFlag)
            {
                stunTimer += (float)time.ElapsedGameTime.TotalSeconds;
                StunCheck();
            }
        }
    }
}
