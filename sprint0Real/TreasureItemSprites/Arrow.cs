using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class Arrow : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(154, 0, 5, 16);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 20, 64);

        public Texture2D _texture;

        public Arrow(Texture2D texture)
        {
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
            //nothing, static
        }

        public bool CanBePickedUp()
        {
            return true;
        }
    }
}
