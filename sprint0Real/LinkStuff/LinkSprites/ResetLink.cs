﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace sprint0Real.LinkStuff.LinkSprites
{
    internal class ResetLink : ILinkSpriteTemp
    {
        private Texture2D _texture;
        private Game1 myGame;

        private Rectangle sourceRectangle = new(35, 11, 16, 16);
        private Rectangle destinationRectangle;



        public ResetLink(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = new Rectangle(200, 300, 50, 50);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, myGame.Link.GetLinkColor());
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Static Sprite, no need to update
        }
    }
}
