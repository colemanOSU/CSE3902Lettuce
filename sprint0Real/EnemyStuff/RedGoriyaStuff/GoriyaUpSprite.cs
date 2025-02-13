using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.EnemyStuff.RedGoriyaStuff
{
    public class GoriyaUpSprite
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public GoriyaUpSprite(Texture2D spriteSheet, SpriteBatch spriteBatch)
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
                sourceRectangle = new Rectangle(241, 11, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 48, 64);
            }
            else
            {
                sourceRectangle = new Rectangle(98, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 48, 64);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
