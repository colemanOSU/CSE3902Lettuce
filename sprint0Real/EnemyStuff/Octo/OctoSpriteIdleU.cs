using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using System.Numerics;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class OctoSpriteIdleU : ISprite2
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;

        public OctoSpriteIdleU(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 24;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            Vector2 org;
            org.X = 0;
            org.Y = 0;
            if (currentFrame <= 12)
            {
                sourceRectangle = new Rectangle(51, 11, 15, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 15, 16);
            }
            else 
            {
                sourceRectangle = new Rectangle(76, 11, 15, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 15, 16);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White, 0, org, SpriteEffects.FlipVertically, 5);
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
