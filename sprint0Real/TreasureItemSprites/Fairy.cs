using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.TreasureItemSprites
{
    public class Fairy : ITreasureItems
    {
        private int frameWidth = 8;
        private int frameHeight = 16;
        private int currentFrameIndex = 0;
        private double timeSinceLastFrame = 0;
        private double timePerFrame = 150;
        private Rectangle currentFrame;
        public Rectangle destinationRectangle;
        private int frameXOffset = 40;

        public Texture2D _texture;
        public bool IsActive { get; set; } = true;

        public Fairy(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 32, 64);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
            currentFrame = new Rectangle(frameXOffset, 0, frameWidth, frameHeight);
        }
        public void CollectItem()
        {
            IsActive = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                spriteBatch.Draw(_texture, destinationRectangle, currentFrame, Color.White);
            }
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
                currentFrame.X = frameXOffset + ( currentFrameIndex * frameWidth);
            }

        }

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
