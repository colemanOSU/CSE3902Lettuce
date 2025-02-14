using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;

namespace sprint0Real.Items.ItemSprites
{
    internal class NullSprite : ILinkSprite
    {
        private Rectangle sourceRectangle = new(125, 78, 1, 1);
        private Rectangle destinationRectangle;
        private Texture2D _texture;
        private Game1 myGame;
        
        public NullSprite(Texture2D texture, Game1 game)
        {
            myGame = game;
            _texture = texture;
            destinationRectangle = new Rectangle(game.Link.GetLocation().X + 13, game.Link.GetLocation().Y + 1, 1, 1);
        }
        public void Update(GameTime gametime, SpriteBatch spriteBatch)
        {
           //static
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
