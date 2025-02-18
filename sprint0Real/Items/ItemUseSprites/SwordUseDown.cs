using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using static Link;

namespace sprint0Real.ItemUseSprites
{
    internal class SwordUseDown : IItemSprite
    {
        private Texture2D _texture;
        private Game1 myGame;
        private float _frameSpeed = 2f;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        private bool isMoving = true;
        private Vector2 org = new Vector2(0);

        public SwordUseDown(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = myGame.Link.GetLocation();
            sourceRectangle = new Rectangle(1, 154, 8, 16);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, org, SpriteEffects.FlipVertically, 0f);
            }
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                destinationRectangle.Y += 4;

                if (destinationRectangle.Y >= 600)
                {
                    isMoving = false;
                }
            }
        }
    }
}
