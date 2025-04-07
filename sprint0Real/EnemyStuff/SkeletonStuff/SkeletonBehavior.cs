using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.SkeletonStuff;

namespace sprint0Real.EnemyStuff.SkeletonStuff
{
    internal class SkeletonBehavior
    {
        private Skeleton mySkeleton;

        public SkeletonBehavior(Skeleton Skeleton)
        {
            mySkeleton = Skeleton;
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
                mySkeleton.ChangeDirection();
            }
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            JukeCheck();
        }
    }
}
