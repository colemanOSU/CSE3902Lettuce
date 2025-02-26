using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.BlockSprites
{
    public class BlockSpriteStripes : IBlock
    {
        public Rectangle sourceRectangle = new Rectangle(1001, 45, 16, 16);
        public Rectangle destinationRectangle = new Rectangle(200, 200, 40, 40);
        public Rectangle CollisionBox => destinationRectangle;
        public Texture2D _texture;

        public BlockSpriteStripes(Texture2D texture)
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
