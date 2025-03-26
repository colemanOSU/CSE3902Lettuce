using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.TreasureItemSprites
{
    public class Bomb : ITreasureItems
    {
        public Rectangle sourceRectangle = new Rectangle(136, 0, 8, 14);
        public Rectangle destinationRectangle;
        public bool IsActive { get; set; } = true;

        public Texture2D _texture;

        public Bomb(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 32, 56);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
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

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
