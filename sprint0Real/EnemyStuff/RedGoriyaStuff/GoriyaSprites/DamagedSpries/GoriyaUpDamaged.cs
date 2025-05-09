﻿using System;
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
    public class GoriyaUpDamaged : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public GoriyaUpDamaged(Texture2D spriteSheet, SpriteBatch spriteBatch)
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
                // White
                sourceRectangle = new Rectangle(310, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 1)
            {
                // Teal
                sourceRectangle = new Rectangle(383, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 2)
            {
                // Red
                sourceRectangle = new Rectangle(241, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 3)
            {
                // Blue
                sourceRectangle = new Rectangle(241, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 4)
            {
                sourceRectangle = new Rectangle(119, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 5)
            {
                sourceRectangle = new Rectangle(121, 95, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else if (currentFrame == 6)
            {
                sourceRectangle = new Rectangle(99, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(98, 95, 15, 15);
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
