using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.TreasureItemSprites
{
    public class MagicalShield : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(120, 2, 8, 12);
        public Rectangle destinationRectangle;

        public Texture2D _texture;

        public MagicalShield(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 32, 48);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
        }
        public void CollectItem()
        {

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
