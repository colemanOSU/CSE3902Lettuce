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

namespace sprint0Real.LinkStuff.LinkSprites
{
    internal class UseFireball : ILinkSpriteTemp
    {
        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 4;
        private float _frameSpeed = 0.2f;
        private int _currentFrame;
        private double _timer;
        private bool flag = false;
        private Rectangle sourceRectangle = new(107, 11, 16, 16);
        private Rectangle destinationRectangle;
        private bool _useItem;

        public UseFireball(Texture2D texture, Game1 game,bool useItem)
        {
            _texture = texture;
            myGame = game;
            _timer = 0;
            destinationRectangle = myGame.Link.GetLocation();
            _useItem = useItem;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!flag)
            {
                switch (_currentFrame)
                {
                    case 1:
                        myGame.Link.DrawFireball();
                        break;
                    case 2:
                        break;
                    case 3:
                        flag = true;
                        myGame.Link.SetCanMove(true);
                        myGame.Link.SetCanAttack(true);
                        break;
                }
            }
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, myGame.Link.GetLinkColor());

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
