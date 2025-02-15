using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.RedGoriyaStuff
{
    public class SkeletonSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public SkeletonSprite(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 2;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            Vector2 org;
            org.X = 0;
            org.Y = 0;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(2, 59, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
                spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                sourceRectangle = new Rectangle(159, 78, 15, 15);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 30, 30);
                spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White, 0, org, SpriteEffects.FlipHorizontally, 5);
            }
        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
