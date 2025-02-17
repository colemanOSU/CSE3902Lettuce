using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class ContainerHeart : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(25, 1, 13, 13);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 52, 52);

        public Texture2D _texture;

        public ContainerHeart(Texture2D texture)
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
