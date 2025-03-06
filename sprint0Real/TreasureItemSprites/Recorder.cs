using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.ItemTempSprites
{
    public class Recorder : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(187, 0, 3, 16);
        public Rectangle destinationRectangle;

        public Texture2D _texture;

        public Recorder(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 12, 64);
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
