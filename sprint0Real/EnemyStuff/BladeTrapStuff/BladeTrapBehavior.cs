using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.BladeTrapStuff;

namespace sprint0Real.EnemyStuff.BladeTrapStuff
{
    internal class BladeTrapBehavior
    {
        private BladeTrap myBladeTrap;

        public BladeTrapBehavior(BladeTrap BladeTrap)
        {
            myBladeTrap = BladeTrap;
        }

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;


        private Random random = new Random();

        private void SafeJuke()
        {
            // THIS IS BAD CODE FIX!!!
            if (myBladeTrap.location.X > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myBladeTrap.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                myBladeTrap.ChangeDirection();
            }
            else if (myBladeTrap.location.X < 0)
            {
                jukeTimer = 0;
                myBladeTrap.location.X = 0;
                myBladeTrap.ChangeDirection();
            }
            else if (myBladeTrap.location.Y > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48)
            {
                jukeTimer = 0;
                myBladeTrap.location.Y = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48;
                myBladeTrap.ChangeDirection();
            }
            else if (myBladeTrap.location.Y < 0)
            {
                jukeTimer = 0;
                myBladeTrap.location.Y = 0;
                myBladeTrap.ChangeDirection();
            }

        }
        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 1);
                myBladeTrap.ChangeDirection();
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
