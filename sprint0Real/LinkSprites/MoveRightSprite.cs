using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.LinkSprites
{
    internal class MoveRightSprite : ILinkSprite
    {
        public Rectangle sourceRectangle = new Rectangle(35, 11, 16, 16);
        public Rectangle destinationRectangle = new Rectangle(200, 200, 16, 16);

        public Texture2D _texture;
        public Game1 myGame;

        public MoveRightSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            destinationRectangle = myGame.Link.getLocation();
            destinationRectangle.Offset(1, 0);
            myGame.Link.setLocation(destinationRectangle);

            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
