using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class BlueRing : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(169, 19, 7, 9);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 28, 36);

        public Texture2D _texture;

        public BlueRing(Texture2D texture)
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
