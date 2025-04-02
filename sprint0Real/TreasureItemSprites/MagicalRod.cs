using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.TreasureItemSprites
{
    public class MagicalRod : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(226, 0, 4, 16);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 16, 64);
        private SoundEffect soundEffect;
        private bool SoundPlayed = false;
        public Texture2D _texture;

        public MagicalRod(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 16, 64);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
            soundEffect = SoundEffectFactory.Instance.getFanfareSoundEffect();
        }
        public void CollectItem()
        {
            if (!SoundPlayed)
            {
                soundEffect.Play();
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

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
