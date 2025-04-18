using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Audio;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real.TreasureItemStuff.TreasureItemSprites
{
    //It's spelled Rupee but hell if I'm going to change it at this point.
    public class Rupee : ITreasureItems
    {
        private int frameWidth = 8;
        private int frameHeight = 16;
        private int currentFrameIndex = 0;
        private double timeSinceLastFrame = 0;
        private double timePerFrame = 150;
        private Rectangle currentFrame;
        public Rectangle destinationRectangle;
        private int frameXOffset = 72;
        private bool SoundPlayed = false;
        public Texture2D _texture;

        public Rupee(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 28, 48);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
            currentFrame = new Rectangle(frameXOffset, 0, frameWidth, frameHeight);
        }
        public void Spawn()
        {
            CurrentMap.Instance.Stage(this);
        }
        public void CollectItem()
        {
            if (!SoundPlayed)
            {
                SoundEffectFactory.Instance.Play(SoundEffectType.RupeePickup);
                SoundPlayed = true;
            }
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
