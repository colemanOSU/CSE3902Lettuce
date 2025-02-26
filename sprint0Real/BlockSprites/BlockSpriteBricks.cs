using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.BlockSprites
{
    public class BlockSpriteBricks : IBlock
    {
        public Rectangle sourceRectangle = new Rectangle(984, 45, 16, 16);
        public Rectangle destinationRectangle = new Rectangle(200, 200, 40, 40);
        public Rectangle CollisionBox => destinationRectangle;
        public Texture2D _texture;

        public BlockSpriteBricks(Texture2D texture)
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