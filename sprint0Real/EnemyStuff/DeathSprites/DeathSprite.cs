using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DeathSprites
{
    public class DeathSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;
        private int frameDelay = 6;
        private int frameCounter = 0;

        // Flag to indicate the animation has finished
        public bool AnimationComplete { get; private set; } = false;

        public DeathSprite(Texture2D spriteSheet)
        {
            sprites = spriteSheet;
            totalFrames = 4;
            currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(0, 0, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(16, 0, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 2)
            {
                sourceRectangle = new Rectangle(32, 0, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(48, 0, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            if (AnimationComplete) return;

            frameCounter++;
            if (frameCounter >= frameDelay)
            {
                if (currentFrame < totalFrames - 1)
                {
                    currentFrame++;
                }
                else
                {
                    AnimationComplete = true;
                }
                frameCounter = 0;
            }
        }
    }
}
