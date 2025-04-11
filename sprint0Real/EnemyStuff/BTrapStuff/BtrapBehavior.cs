using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.BTrapStuff;

namespace sprint0Real.EnemyStuff.BTrapStuff
{
    internal class BTrapBehavior
    {
        private BTrap myBTrap;

        public BTrapBehavior(BTrap BTrap)
        {
            myBTrap = BTrap;
        }

        private float jukeTimer = 0f;
        private int moving = 0;


        private Random random = new Random();

        private void JukeCheck()
        {
            if (moving ==0)
            {
                moving = 1;
                myBTrap.ChangeDirection();
            }
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            JukeCheck();
        }
    }
}
