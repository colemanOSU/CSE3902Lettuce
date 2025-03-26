using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.BlockSprites
{
    public class BlockSpriteSpecks : IBlock
    {
        private int width = 16;
        private int height = 16;
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        public Vector2 position;

        public Texture2D texture;

        public BlockSpriteSpecks(Vector2 startPos)
        {
            this.texture = BlockSpriteFactory.Instance.GetDungeonTileSet();
            this.position = startPos;
            sourceRectangle = new Rectangle(1001, 28, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width * 3, height * 3);
            //destination(200, 200)
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
            destinationRectangle.X = (int)position.X;
            destinationRectangle.Y = (int)position.Y;
        }
        public void Move(Vector2 direction)
        {
            position += direction;

        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}