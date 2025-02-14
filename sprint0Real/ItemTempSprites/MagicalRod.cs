using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class MagicalRod : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(226, 0, 4, 16);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 16, 64);

        public Texture2D _texture;

        public MagicalRod(Texture2D texture)
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
