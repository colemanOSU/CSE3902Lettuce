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
        private bool PerchFlag = false;
        private bool SlowedDown = false;
        private float PerchDelay = 5f;
        private float PerchTimer = 0f;
        private float UnPerchDelay = 3f;
        private float UnPerchTimer = 0f;
        private float stopTime = 1;

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
        public void Slowdown(GameTime gameTime)
        {
            if (myBat.FPS > 3)
            {
                myBat.speed = myBat.speed - myBat.speed / stopTime * (float)gameTime.ElapsedGameTime.TotalSeconds;
                myBat.FPS = myBat.FPS - myBat.FPS / stopTime * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                SlowedDown = true;
            }
        }
        private void TimeToPerch()
        {
            if (PerchTimer >= PerchDelay)
            { 
                PerchFlag = true;
                PerchTimer = 0;
            }
        }
        private void TimeToUnPerch()
        {
            if (UnPerchTimer >= UnPerchDelay)
            {
                PerchFlag = false;
                SlowedDown = false;
                myBat.UnPerch();
                UnPerchTimer = 0;
            }
        }
        private void Perch(GameTime time)
        {
            if (PerchFlag && SlowedDown)
            {
                myBat.Perch();
                UnPerchTimer += (float)time.ElapsedGameTime.TotalSeconds;
            } else if (PerchFlag)
            {
                Slowdown(time);
            }
            else if (!PerchFlag)
            {
                PerchTimer += (float)time.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Update(GameTime time)
        {
            // Don't change direction while perching
            if (!PerchFlag)
            {
                jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            }
            TimeToPerch();
            TimeToUnPerch();
            Perch(time);
            SafeJuke();
            JukeCheck();
        }
    }
}
