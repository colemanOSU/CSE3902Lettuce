using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class Sword : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(104, 0, 7, 16);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 28, 64);

        public Texture2D _texture;

        public Sword(Texture2D texture)
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
    }
}