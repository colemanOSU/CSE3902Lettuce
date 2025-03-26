using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.ItemTempSprites
{
    public class Arrow : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(154, 0, 5, 16);
        public Rectangle destinationRectangle;
        public bool IsActive { get; set; } = true;

        public Texture2D _texture;

        public Arrow(Vector2 position)
        {
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 20, 64);
        }

        public void CollectItem()
        {
            IsActive = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(GameTime gametime)
        {
            //nothing, static
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
