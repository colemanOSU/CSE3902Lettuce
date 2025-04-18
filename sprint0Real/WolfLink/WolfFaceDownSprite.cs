using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace sprint0Real.WolfLink
{
    internal class WolfFaceDownSprite : ILinkSpriteTemp
    {
        private Texture2D _texture;
        private Game1 myGame;

        private Rectangle sourceRectangle = new(44, 2, 15, 21);
        private Rectangle destinationRectangle;
        public WolfFaceDownSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
        }

        public void Update(GameTime gametime, SpriteBatch spriteBatch)
        {
            Rectangle baseLocation = myGame.Link.GetLocation();
            destinationRectangle = new Rectangle(
                baseLocation.X,
                baseLocation.Y,
                15 * 3,
                21 * 3
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, myGame.Link.GetLinkColor());
        }
    }
}
