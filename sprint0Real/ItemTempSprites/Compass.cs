using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class Compass : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(258, 1, 11, 12);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 44, 48);

        public Texture2D _texture;

        public Compass(Texture2D texture)
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
