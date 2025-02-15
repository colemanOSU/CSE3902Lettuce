using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.BubbleStuff;

namespace sprint0Real.EnemyStuff.BubbleStuff
{
    internal class BubbleBehavior
    {
        private Bubble myBubble;

        public BubbleBehavior(Bubble Bubble)
        {
            myBubble = Bubble;
        }

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;


        private Random random = new Random();

        private void SafeJuke()
        {
            if (myBubble.location.X > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myBubble.location.X = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth - 48;
                myBubble.ChangeDirection();
            }
            else if (myBubble.location.X < 0)
            {
                jukeTimer = 0;
                myBubble.location.X = 0;
                myBubble.ChangeDirection();
            }
            else if (myBubble.location.Y > EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48)
            {
                jukeTimer = 0;
                myBubble.location.Y = EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight - 48;
                myBubble.ChangeDirection();
            }
            else if (myBubble.location.Y < 0)
            {
                jukeTimer = 0;
                myBubble.location.Y = 0;
                myBubble.ChangeDirection();
            }

        }
        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)((random.NextDouble()) * 0.7);
                myBubble.ChangeDirection();
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
