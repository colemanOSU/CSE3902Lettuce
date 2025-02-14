using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class Bomb : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(136, 0, 8, 14);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 32, 56);

        public Texture2D _texture;

        public Bomb(Texture2D texture)
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
