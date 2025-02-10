using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;

namespace sprint0Real.LinkSprites
{
    internal class WoodSwordSprite : IItem
    {
        private Rectangle sourceRectangle = new(10, 154, 16, 16);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 0;

        public WoodSwordSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = new Rectangle(game.Link.GetLocation().X + 11, game.Link.GetLocation().Y + 1, 16, 16);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(SpriteBatch spriteBatch, GameTime gameTime)
        {
        
        }

        public void Update(SpriteBatch spriteBatch, Texture2D marioSheet)
        {
            throw new System.NotImplementedException();
        }
    }
}
