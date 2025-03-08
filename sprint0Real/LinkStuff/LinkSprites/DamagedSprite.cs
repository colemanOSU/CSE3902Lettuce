using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using System.Collections.Generic;

namespace sprint0Real.LinkStuff.LinkSprites
{
    public class DamagedSprite : ILinkSpriteTemp
    {
        private Game1 _game;
        private Texture2D _link;
        private int _frameCount = 9;
        private Rectangle destinationRectangle;
        private float _frameSpeed = 0.2f;
        private int _currentFrame;
        private double _timer;

        public DamagedSprite(Game1 game, Texture2D linkSheet)
        {
            _link = linkSheet;
            _game = game;
            _timer = 0;
            destinationRectangle = _game.Link.GetLocation();
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (_timer > _frameSpeed)
            {
                _currentFrame = (_currentFrame + 1) % _frameCount;
                _timer -= _frameSpeed;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            int _horizontal = 0;
            int _verticle = 0;

            if (_currentFrame < 3)
            {
                _horizontal = 1 + _currentFrame * 17;
            }
            else if (_currentFrame == 3)
            {
                _horizontal = 3 * 17 + 7;
                _verticle = -8;
            }
            else if (_currentFrame > 3 && _currentFrame < 7)
            {
                _horizontal = _currentFrame * 17 + 7;
                _verticle = -8;
            }
            else if (_currentFrame == 7)
            {
                _horizontal = 8 * 17 + 64;
                _verticle = 9;
            }
            else if (_currentFrame == 8)
            {
                _horizontal = 9 * 17 + 70;
                _verticle = 9;
            }
            Rectangle sourceRectangle = new Rectangle(0 + _horizontal, 232 + _verticle, 16, 16);
            spriteBatch.Draw(_link, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
