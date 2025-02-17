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
using sprint0Real.Items.ItemSprites;
using System.Net;

namespace sprint0Real.LinkSprites
{
    internal class SwordUseRight : IItemSprite
    {
        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 4;
        private float _frameSpeed = 2f;
        private int _currentFrame;
        private double _timer;
        private bool flag = false;
        private Rectangle sourceRectangle = new(10, 154, 16, 16);
        private Rectangle destinationRectangle;


        public SwordUseRight(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            _timer = 0;
            destinationRectangle = myGame.Link.GetLocation();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!flag)
            {
                for (int i = 0; destinationRectangle.X + 1 * i < 1000; i++)
                {
                    destinationRectangle.X += 1;
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                }
            }
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (_timer > _frameSpeed)
            {
                _currentFrame = (_currentFrame + 1) % frameCount;
                _timer -= _frameSpeed;
            }

        }
    }
}
