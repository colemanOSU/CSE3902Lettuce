using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace sprint0Real.LinkSprites
{
    internal class FaceUpSprite : ILinkSprite
    {
        private Texture2D _texture;
        private Game1 myGame;

        private Rectangle sourceRectangle = new(69, 11, 16, 16);
        private Rectangle destinationRectangle;



        public FaceUpSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = myGame.Link.GetLocation();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Static Sprite, no need to update
        }
    }
}
