using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class FireballSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public FireballSprite(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 3;
        }

        void ISprite2.Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(101, 11, 7, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 14, 30);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(110, 11, 7, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 14, 30);
            }
            else if (currentFrame == 2)
            {
                sourceRectangle = new Rectangle(119, 11, 7, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 14, 30);
            }
            else
            {
                sourceRectangle = new Rectangle(128, 11, 7, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 14, 30);
            }
            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        void ISprite2.Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }
    }
}
