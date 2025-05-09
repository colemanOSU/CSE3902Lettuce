﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DinoStuff.DinoWalkingSprites
{
    public class DinoWalkingUpSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public DinoWalkingUpSprite(Texture2D spriteSheet)
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
                sourceRectangle = new Rectangle(35, 58, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
                spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                sourceRectangle = new Rectangle(35, 58, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
                spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 1);
            }

        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
