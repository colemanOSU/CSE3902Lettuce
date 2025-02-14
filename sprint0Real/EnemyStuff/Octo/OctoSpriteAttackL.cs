using System;
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
    public class OctoSpriteAttackL : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;
        private int state;

        public OctoSpriteAttackL(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 24;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            if (state==1 || state==3)
            {
                if (currentFrame <= 12)
                {
                    sourceRectangle = new Rectangle(1, 11, 15, 16);
                    destinationRectangle = new Rectangle((int)location.X,
                    (int)location.Y, 15, 16);
                }
                else
                {
                    sourceRectangle = new Rectangle(18, 11, 15, 16);
                    destinationRectangle = new Rectangle((int)location.X,
                    (int)location.Y, 15, 16);
                }
            }
            else
            {
                if (currentFrame <= 12)
                {
                    sourceRectangle = new Rectangle(35, 11, 15, 16);
                    destinationRectangle = new Rectangle((int)location.X,
                    (int)location.Y, 48, 64);
                }
                else
                {
                    sourceRectangle = new Rectangle(53, 11, 15, 16);
                    destinationRectangle = new Rectangle((int)location.X,
                    (int)location.Y, 48, 64);
                }
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }
    }
}
