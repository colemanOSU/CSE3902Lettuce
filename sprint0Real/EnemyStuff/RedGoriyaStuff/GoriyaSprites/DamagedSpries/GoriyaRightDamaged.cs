using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.RedGoriyaStuff.GoriyaSprites.DamagedSpries
{
    public class GoriyaRightDamaged : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public GoriyaRightDamaged(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 8;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(5, 98, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(44, 95, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 2)
            {
                sourceRectangle = new Rectangle(38, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 3)
            {
                sourceRectangle = new Rectangle(1, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 4)
            {
                sourceRectangle = new Rectangle(24, 97, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 5)
            {
                sourceRectangle = new Rectangle(62, 95, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 6)
            {
                sourceRectangle = new Rectangle(58, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(20, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
