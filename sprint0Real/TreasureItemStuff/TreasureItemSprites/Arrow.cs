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
    public class Arrow : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(154, 0, 5, 16);
        public Rectangle destinationRectangle;
        private bool SoundPlayed = false;

        public Texture2D _texture;

        public Arrow(Vector2 position)
        {
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 15, 48);
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
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
            //nothing, static
        }
        public void Spawn()
        {
            CurrentMap.Instance.Stage(this);
        }

        public bool CanBePickedUp()
        {
            return true;
        }

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
