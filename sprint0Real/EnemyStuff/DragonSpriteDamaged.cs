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

namespace sprint0Real.EnemyStuff
{
    public class DragonSpriteDamaged : ISprite
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;
        private Game1 myGame;

        public DragonSpriteDamaged(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
            totalFrames = 3;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(261, 226, 24, 42);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 20, 20);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(292, 226, 24, 42);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 20, 20);
            }
            else if (currentFrame == 3)
            {
                sourceRectangle = new Rectangle(323, 226, 24, 42);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 20, 20);
            }
            else
            {
                sourceRectangle = new Rectangle(354, 226, 24, 42);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 20, 20);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        // This is just here to make the compiler happy. Will delete later
        public void Update(SpriteBatch spriteBatch, Texture2D marioSheet)
        {
            throw new NotImplementedException();
        }
    }
}
