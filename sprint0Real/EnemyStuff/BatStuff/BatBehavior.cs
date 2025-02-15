using System;
using Microsoft.Xna.Framework;

namespace sprint0Real.EnemyStuff.BatStuff
{
    internal class BatBehavior
    {
        private Bat myBat;

        public BatBehavior(Bat Bat)
        {
            myBat = Bat;
        }

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;
        private bool PerchFlag = true;
        private float PerchDelay = 1f;
        private float PerchTimer = 0f;
        private float UnPerchDelay = 1f;
        private float UnPerchTimer = 0f;

        private Random random = new Random();

        private void SafeJuke()
        {
            // THIS IS BAD CODE FIX!!!
            if (myBat.location.X > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myBat.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                myBat.ChangeDirection();
            }
            else if (myBat.location.X < 0)
            {
                jukeTimer = 0;
                myBat.location.X = 0;
                myBat.ChangeDirection();
            }
            else if (myBat.location.Y > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48)
            {
                jukeTimer = 0;
                myBat.location.Y = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48;
                myBat.ChangeDirection();
            }
            else if (myBat.location.Y < 0)
            {
                jukeTimer = 0;
                myBat.location.Y = 0;
                myBat.ChangeDirection();
            }

        }
        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 1);
                myBat.ChangeDirection();
            }
        }
        private void TimeToPerch()
        {
            if (PerchTimer >= PerchDelay)
            {
                PerchFlag = false;
                UnPerchTimer = 0;
            }
        }
        private void TimeToUnPerch()
        {
            if (UnPerchTimer >= UnPerchDelay)
            {
                PerchFlag = true;
                PerchTimer = 0;
            }
        }
        private void Perch(GameTime time)
        {
            if (PerchFlag)
            {
                myBat.Perch();
                UnPerchTimer += (float)time.ElapsedGameTime.TotalSeconds;
            } else
            {
                myBat.UnPerch();
                PerchTimer += (float)time.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            TimeToPerch();
            TimeToUnPerch();
            Perch(time);
            SafeJuke();
            JukeCheck();
        }
    }
}
