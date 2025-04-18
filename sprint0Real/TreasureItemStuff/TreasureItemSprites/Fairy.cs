using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.EnemyStuff.SkeletonStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Audio;

namespace sprint0Real.TreasureItemStuff.TreasureItemSprites
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
        private Vector2 Location;
        private int frameXOffset = 40;
        private bool SoundPlayed = false;
        public float speed = 1.15f;
        private float jukeTimer = 0f;
        private float jukeDelay = 0f;

        private Random random = new Random();

        public Texture2D _texture;
        private FairyStateMachine _stateMachine;

        public Fairy(Vector2 pos)
        {
            Location = pos;
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 28, 48);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
            currentFrame = new Rectangle(frameXOffset, 0, frameWidth, frameHeight);
            _stateMachine = new FairyStateMachine(this);
        }
        public void CollectItem()
        {
            if (!SoundPlayed)
            {
                SoundEffectFactory.Instance.Play(SoundEffectType.itemPickup);
                SoundPlayed = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, currentFrame, Color.White);
        }
        public void Spawn()
        {
            CurrentMap.Instance.Stage(this);
        }
        public void ChangeDirection()
        {
            _stateMachine.ChangeDirection();
        }

        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 0.3f);
                ChangeDirection();
            }
        }
        public void Update(GameTime gametime)
        {
            // Handle frame timing
            timeSinceLastFrame += gametime.ElapsedGameTime.TotalMilliseconds;
            _stateMachine.Update();
            jukeTimer += (float)gametime.ElapsedGameTime.TotalSeconds;
            JukeCheck();

            if (timeSinceLastFrame >= timePerFrame)
            {
                timeSinceLastFrame -= timePerFrame;
                currentFrameIndex++;

                if (currentFrameIndex >= 2)
                {
                    currentFrameIndex = 0; // Loop back to the first frame
                }

                // Update the current frame
                currentFrame.X = frameXOffset + currentFrameIndex * frameWidth;

            }
            destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, destinationRectangle.Width, destinationRectangle.Height);

        }
        public Vector2 location
        {
            get { return Location; }
            set { Location = value; }
        }

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
