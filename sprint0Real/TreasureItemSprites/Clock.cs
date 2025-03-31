using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.TreasureItemSprites
{
    public class Clock : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(58, 0, 11, 16);
        public Rectangle destinationRectangle;
        private SoundEffect soundEffect;

        public Texture2D _texture;

        public Clock(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 44, 64);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
            soundEffect = SoundEffectFactory.Instance.getItemSoundEffect();
        }
        public void CollectItem()
        {
            soundEffect.Play();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
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