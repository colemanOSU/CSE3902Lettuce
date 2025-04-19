using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.HandStuff
{
    public class HandSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public HandSprite(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 2;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(393, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 15 * Game1.RENDERSCALE, 15 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(409, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 15 * Game1.RENDERSCALE, 15 * Game1.RENDERSCALE);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }

        public void DrawUpsideDown(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(393, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 15 * Game1.RENDERSCALE, 15 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(409, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 15 * Game1.RENDERSCALE, 15 * Game1.RENDERSCALE);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipVertically, 1);
        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
