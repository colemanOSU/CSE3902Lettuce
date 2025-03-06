using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.ItemTempSprites
{
    public class WhiteSword : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(104, 16, 8, 16);
        public Rectangle destinationRectangle;

        public Texture2D _texture;

        public WhiteSword(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 28, 64);
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
