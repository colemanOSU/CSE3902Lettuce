﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Audio;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real.TreasureItemStuff.TreasureItemSprites
{
    public class Recorder : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(187, 0, 3, 16);
        public Rectangle destinationRectangle;
        private bool SoundPlayed = false;
        public Texture2D _texture;

        public Recorder(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 9, 48);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public void CollectItem()
        {
            if (!SoundPlayed)
            {
                SoundEffectFactory.Instance.Play(SoundEffectType.Fanfare);
                SoundPlayed = true;
            }
        }
        public void Spawn()
        {
            CurrentMap.Instance.Stage(this);
        }
        public void Update(GameTime gametime)
        {
            //nothing, static
        }

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
