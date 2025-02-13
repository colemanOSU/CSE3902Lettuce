using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.EnemyStuff.RedGoriyaStuff
{
    public class GoriyaLeftDamaged
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public GoriyaLeftDamaged(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 24;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame <= 12)
            {
                sourceRectangle = new Rectangle(51, 11, 24, 32);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 48, 64);
            }
            else
            {
                sourceRectangle = new Rectangle(76, 11, 24, 32);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 48, 64);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
