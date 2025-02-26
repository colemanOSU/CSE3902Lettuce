using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.BlockSprites
{
    public class BlockSpriteNavy : IBlock
    {
        private int width = 16;
        private int height = 16;
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        public Vector2 position;

        public Texture2D texture;

        public BlockSpriteNavy(Texture2D texture, Vector2 startPos)
        {
            this.texture = texture;
            this.position = startPos;

            sourceRectangle = new Rectangle(1018, 28, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width * 2, height * 2);
            //destination(200, 200)
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
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