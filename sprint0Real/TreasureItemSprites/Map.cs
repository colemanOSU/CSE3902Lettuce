using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.TreasureItemSprites
{
    public class Map : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(88, 0, 8, 16);
        public Rectangle destinationRectangle;

        public Texture2D _texture;

        public Map(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 32, 64);
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
