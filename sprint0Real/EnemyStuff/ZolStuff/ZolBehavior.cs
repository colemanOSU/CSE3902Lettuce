using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.ZolStuff;

namespace sprint0Real.EnemyStuff.ZolStuff
{
    internal class ZolBehavior
    {
        private Zol myZol;

        public ZolBehavior(Zol Zol)
        {
            myZol = Zol;
        }

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;


        private Random random = new Random();

        private void SafeJuke()
        {
            if (myZol.location.X > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myZol.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                myZol.ChangeDirection();
            }
            else if (myZol.location.X < 0)
            {
                jukeTimer = 0;
                myZol.location.X = 0;
                myZol.ChangeDirection();
            }
            else if (myZol.location.Y > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48)
            {
                jukeTimer = 0;
                myZol.location.Y = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48;
                myZol.ChangeDirection();
            }
            else if (myZol.location.Y < 0)
            {
                jukeTimer = 0;
                myZol.location.Y = 0;
                myZol.ChangeDirection();
            }

        }
        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)((random.NextDouble()+0.2) * 2);
                myZol.ChangeDirection();
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
