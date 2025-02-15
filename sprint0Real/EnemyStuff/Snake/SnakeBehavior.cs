using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.SnakeStuff;

namespace sprint0Real.EnemyStuff.SnakeStuff
{
    internal class SnakeBehavior
    {
        private Snake mySnake;

        public SnakeBehavior(Snake Snake)
        {
            mySnake = Snake;
        }

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;


        private Random random = new Random();

        private void SafeJuke()
        {
            // THIS IS BAD CODE FIX!!!
            if (mySnake.location.X > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                mySnake.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                mySnake.ChangeDirection();
            }
            else if (mySnake.location.X < 0)
            {
                jukeTimer = 0;
                mySnake.location.X = 0;
                mySnake.ChangeDirection();
            }
            else if (mySnake.location.Y > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48)
            {
                jukeTimer = 0;
                mySnake.location.Y = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48;
                mySnake.ChangeDirection();
            }
            else if (mySnake.location.Y < 0)
            {
                jukeTimer = 0;
                mySnake.location.Y = 0;
                mySnake.ChangeDirection();
            }

        }
        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 1);
                mySnake.ChangeDirection();
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
