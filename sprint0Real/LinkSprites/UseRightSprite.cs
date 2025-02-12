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
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace sprint0Real.LinkSprites
{
    internal class UseRightSprite : ILinkSprite
    {
        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 5;
        private Rectangle sourceRectangle = new(124, 11, 16, 16);
        private Rectangle destinationRectangle;
        private float _frameSpeed = 0.2f;
        private int _currentFrame;
        private double _timer;
        private bool flag = false;

        public UseRightSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            _timer = 0;
            destinationRectangle = myGame.Link.GetLocation();
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            switch (_currentFrame)
            {
                case 1:
                    sourceRectangle = new(111, 77, 27, 18);
                    destinationRectangle = new(myGame.Link.GetLocation().X, myGame.Link.GetLocation().Y, 27 * 3, 18 * 3);
                    break;
                case 2:
                    sourceRectangle = new(138, 77, 24, 18);
                    destinationRectangle = new(myGame.Link.GetLocation().X, myGame.Link.GetLocation().Y, 24 * 3, 18 * 3);
                    break;
                case 3:
                    sourceRectangle = new(164, 77, 18, 18);
                    destinationRectangle = new(myGame.Link.GetLocation().X, myGame.Link.GetLocation().Y, 18 * 3, 18 * 3);
                    break;
                case 4:
                    flag = true;
                    break;
            }
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            myGame.Link.SetCanMove(false);
            myGame.Link.SetCanAttack(false);

        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (_timer > _frameSpeed)
            {
                _currentFrame = (_currentFrame + 1) % frameCount;
                _timer -= _frameSpeed;
            }
            if (flag == true)
            {
                myGame.Link.SetCanMove(true);
                myGame.Link.SetCanAttack(true);
                new FaceRightCommand(myGame).Execute();
            }

        }
    }
}
