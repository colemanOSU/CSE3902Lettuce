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
    public class RockSprite : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public RockSprite(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 3;
        }

        void ISprite2.Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (true)//lol I didnt feel like removing this b/c this looks funny also helps with keeping a similar template
            {
                sourceRectangle = new Rectangle(72, 11, 7, 9);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 14, 30);//ASK ABOUT THIS
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
