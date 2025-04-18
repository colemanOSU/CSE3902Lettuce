using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;
using sprint0Real.WolfLink;
namespace sprint0Real.TreasureItemStuff.TreasureItemSprites
{
    public class WolfBubble : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(85, 8, 7, 7);
        public Rectangle destinationRectangle;
        private SoundEffect soundEffect;
        private bool SoundPlayed = false;
        public Texture2D _texture;

        public WolfBubble(Vector2 pos) {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 7*3, 7*3);
            _texture = WolfSpriteFactory.Instance.GetItemSpriteSheet();
            
        }
        public void CollectItem()
        {
            if (!SoundPlayed)
            {
                soundEffect.Play();
                SoundPlayed = true;
            }
        }
        public void Spawn()
        {
            CurrentMap.Instance.Stage(this);
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
