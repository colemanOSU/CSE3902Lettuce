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
        private float jukeDelay = 0f;
        private int moving = 0;


        private Random random = new Random();

        private void SafeJuke()
        {
            // THIS IS BAD CODE FIX!!!
            if (myBTrap.location.X > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myBTrap.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                if (moving == 1)
                {
                    myBTrap.Return();
                    moving = 2;
                }
                else
                {
                    moving = 0;
                }
            }
            else if (myBTrap.location.X < 0)
            {
                jukeTimer = 0;
                myBTrap.location.X = 0;
                if (moving == 1)
                {
                    myBTrap.Return();
                    moving = 2;
                }
                else
                {
                    moving = 0;
                }
            }
            else if (myBTrap.location.Y > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48)
            {
                jukeTimer = 0;
                myBTrap.location.Y = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48;
                if (moving == 1)
                {
                    myBTrap.Return();
                    moving = 2;
                }
                else
                {
                    moving = 0;
                }
            }
            else if (myBTrap.location.Y < 0)
            {
                jukeTimer = 0;
                myBTrap.location.Y = 0;
                if(moving == 1)
                {
                    myBTrap.Return();
                    moving = 2;
                }
                else
                {
                    moving = 0;
                }
            }

        }
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
            SafeJuke();
            JukeCheck();
        }
    }
}
