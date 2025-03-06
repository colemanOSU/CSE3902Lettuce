using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.LinkStuff.LinkSprites
{
    internal class FaceLeftSprite : ILinkSpriteTemp
    {
        private Rectangle sourceRectangle = new(35, 11, 16, 16);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private Game1 myGame;

        public FaceLeftSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = myGame.Link.GetLocation();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws all right facing sprites flipped horizontally
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, myGame.Link.GetLinkColor(), 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Static sprite, no need to update
        }
    }
}
