using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.BlockSprites
{
    public class BlockSprite1 : IBlock
    {
        int currentFrame = 0;
        int totalFrames = 1;
        int yPos = 0;
        int xPos = 0;
        bool movingUp = false;
        bool movingLeft = false;

        public Rectangle sourceRectangle = new Rectangle(983, 9, 16, 18);
        public Rectangle destinationRectangle = new Rectangle(200, 200, 200, 25);

        public Texture2D _texture;

        public BlockSprite1(Texture2D texture)
        {
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, sourceRectangle, destinationRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
            //nothing, static
        }
    }
}
