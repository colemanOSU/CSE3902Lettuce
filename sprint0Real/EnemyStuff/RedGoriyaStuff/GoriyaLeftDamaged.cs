using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.RedGoriyaStuff
{
    public class GoriyaLeftDamaged : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public GoriyaLeftDamaged(Texture2D spriteSheet, SpriteBatch spriteBatch)
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
                sourceRectangle = new Rectangle(325, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(399, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }
            else if (currentFrame == 2)
            {
                sourceRectangle = new Rectangle(256, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }
            else if (currentFrame == 3)
            {
                sourceRectangle = new Rectangle(257, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }
            else if (currentFrame == 4)
            {
                sourceRectangle = new Rectangle(343, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }
            else if (currentFrame == 5)
            {
                sourceRectangle = new Rectangle(417, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }
            else if (currentFrame == 6)
            {
                sourceRectangle = new Rectangle(273, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }
            else
            {
                sourceRectangle = new Rectangle(275, 28, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
