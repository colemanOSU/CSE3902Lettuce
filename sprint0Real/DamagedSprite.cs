using sprint0Real;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using System.Collections.Generic;

namespace sprint0Real
{
    public class DamagedSprite : ILinkSprite
    {
        private Game _game;
        private Texture2D _link;
        private Rectangle sourceRectangle = new Rectangle(50, 10, 15, 15);
        private Rectangle destinationRectangle = new Rectangle(320, 150, 50, 50);

        public DamagedSprite(Game game, Texture2D linkSheet)
        {
            _link = linkSheet;
            _game = game;
        }
        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //static
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(_link, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
