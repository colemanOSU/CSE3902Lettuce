using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.LinkStuff2
{
    public class LinkDamageColorHandler
    {
        private float timer;
        private float cutoff = 1f;
        private Link myLink;
        private int totalFrames = 5;
        private int currentFrame = 0;

        public LinkDamageColorHandler(Link link)
        {
            myLink = link;
        }

        public void Update(GameTime gameTime)
        {
            if (timer < cutoff)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                currentFrame = (currentFrame + 1) % totalFrames;
                if (currentFrame == 0)
                {
                    myLink.SetColor(Color.White);
                }
                else if (currentFrame == 1)
                {
                    myLink.SetColor(Color.DarkRed);
                }
                else if (currentFrame == 2)
                {
                    myLink.SetColor(Color.Red);
                }
                else if (currentFrame == 3)
                {
                    myLink.SetColor(Color.OrangeRed);
                }
            }
            else
            {
                timer = 0;
                currentFrame = 0;
                myLink.SetColor(Color.White);
            }
        }
    }
}
