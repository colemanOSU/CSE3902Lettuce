using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class Heart : IItemtemp
    {
        private int frameWidth = 7;
        private int frameHeight = 8;
        private int currentFrameIndex = 0;
        private double timeSinceLastFrame = 0;
        private double timePerFrame = 150;
        private Rectangle currentFrame;
        public Rectangle destinationRectangle = new Rectangle(400, 400, 28, 32);

        public Texture2D _texture;

        public Heart(Texture2D texture)
        {
            _texture = texture;
            currentFrame = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, currentFrame, Color.White);
        }

        public void Update(GameTime gametime)
        {
            // Handle frame timing
            timeSinceLastFrame += gametime.ElapsedGameTime.TotalMilliseconds;

            if (timeSinceLastFrame >= timePerFrame)
            {
                timeSinceLastFrame -= timePerFrame;
                currentFrameIndex++;

                if (currentFrameIndex >= 2) 
                {
                    currentFrameIndex = 0; // Loop back to the first frame
                }

                // Update the current frame
                currentFrame.Y = currentFrameIndex * frameHeight;
            }

        }

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
