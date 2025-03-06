using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.ItemTempSprites
{
    public class Compass : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(258, 1, 11, 12);
        public Rectangle destinationRectangle;

        public Texture2D _texture;

        public Compass(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 44, 48);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
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
