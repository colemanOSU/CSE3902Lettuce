﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using System.Numerics;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class DragonSpriteAttack : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public DragonSpriteAttack(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 2;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame <= 0)
            {
                sourceRectangle = new Rectangle(1, 11, 24, 32);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 24 * Game1.RENDERSCALE, 32 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(26, 11, 24, 32);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 24 * Game1.RENDERSCALE, 32 * Game1.RENDERSCALE);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
