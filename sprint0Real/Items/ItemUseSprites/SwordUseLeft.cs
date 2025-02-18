using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;

namespace sprint0Real.LinkSprites
{
    internal class SwordUseLeft : IItemSprite
    {
        private Texture2D _texture;
        private Game1 myGame;
        private float _frameSpeed = 2f;  
        private Rectangle sourceRectangle;  
        private Rectangle destinationRectangle;
        private Vector2 org = new Vector2(0);  

        private bool isMoving = true;  

        public SwordUseLeft(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = myGame.Link.GetLocation();
            sourceRectangle = new Rectangle(10, 154, 16, 16);  
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, org, SpriteEffects.FlipHorizontally, 0f);
            }
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                destinationRectangle.X -= 4;

                if (destinationRectangle.X <= 0)
                {
                    isMoving = false;  
                }
            }
        }
    }
}