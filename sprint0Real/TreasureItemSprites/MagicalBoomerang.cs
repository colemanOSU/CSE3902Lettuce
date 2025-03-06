using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class MagicalBoomerang : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(129, 19, 5, 8);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 20, 32);

        public Texture2D _texture;

        public MagicalBoomerang(Texture2D texture)
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

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
