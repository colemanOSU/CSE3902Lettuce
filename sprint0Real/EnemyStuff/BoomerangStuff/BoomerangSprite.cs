using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.BoomerangStuff
{
    public class BoomerangSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;
        private int FrameCounter;

        public BoomerangSprite(Texture2D spriteSheet)
        {
            sprites = spriteSheet;
            totalFrames = 3;
            FrameCounter = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(290, 14, 7, 9);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 7 * Game1.RENDERSCALE, 9 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(299, 14, 7, 9);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 7 * Game1.RENDERSCALE, 9 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(308, 14, 7, 9);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 7 * Game1.RENDERSCALE, 9 * Game1.RENDERSCALE);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            FrameCounter++;
            currentFrame = FrameCounter / 7;
            if (FrameCounter > totalFrames * 7) FrameCounter = 0;
        }
    }
}
