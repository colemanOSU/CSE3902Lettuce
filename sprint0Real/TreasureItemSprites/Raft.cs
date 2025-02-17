using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.ItemTempSprites
{
    public class Raft : IItemtemp
    {
        public Rectangle sourceRectangle = new Rectangle(193, 0, 14, 16);
        public Rectangle destinationRectangle = new Rectangle(400, 400, 56, 64);

        public Texture2D _texture;

        public Raft(Texture2D texture)
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
