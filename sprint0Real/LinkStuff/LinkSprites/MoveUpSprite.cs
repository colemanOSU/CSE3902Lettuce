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
    internal class MoveUpSprite : ILinkSpriteTemp
    {
        private Rectangle frame1Rec = new(69 + 17, 11, 16, 16);
        private Rectangle frame2Rec = new(69, 11, 16, 16);
        private Rectangle sourceRectangle = new(35, 11, 16, 16);
        //private Rectangle destinationRectangle = new(200, 200, 16, 16);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 0;

        public MoveUpSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = new Rectangle(myGame.Link.GetLocation().X, myGame.Link.GetLocation().Y, 16, 16);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws all right facing sprites flipped horizontally
            spriteBatch.Draw(_texture, myGame.Link.GetLocation(), sourceRectangle, myGame.Link.GetLinkColor());
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            myGame.Link.MoveInDirection(Link.Direction.Up);
            destinationRectangle = new Rectangle(myGame.Link.GetLocation().X, myGame.Link.GetLocation().Y, 16, 16);

            frameCount++;
            if (frameCount < 10)
            {
                sourceRectangle = frame1Rec;
            }
            else if (frameCount < 20)
            {
                sourceRectangle = frame2Rec;
            }
            else
            {
                frameCount = 0;
            }
        }
    }
}
