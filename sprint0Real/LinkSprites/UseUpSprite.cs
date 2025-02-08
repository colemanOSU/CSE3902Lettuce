using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using System.Xml.Linq;

namespace sprint0Real.LinkSprites
{
    internal class UseUpSprite : ILinkSprite
    {
        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 0;

        private Rectangle sourceRectangle = new(141, 11, 16, 16);
        private Rectangle destinationRectangle;

        

        public UseUpSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = myGame.Link.GetLocation();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            myGame.Link.SetCanMove(false);
            myGame.Link.SetCanAttack(false);
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            frameCount++;
            if (frameCount >= 30)
            {
                myGame.Link.SetCanMove(true);
                myGame.Link.SetCanAttack(true);
                new FaceUpCommand(myGame).Execute();
            }
        }
    }
}
