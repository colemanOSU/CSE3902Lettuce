using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.ZolStuff
{
    public class ZolSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public ZolSprite(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 4;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 1|| currentFrame == 2)
            {
                sourceRectangle = new Rectangle(78, 11, 13, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 26, 30);
            }
            else
            {
                sourceRectangle = new Rectangle(95, 11, 13, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 26, 30);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
