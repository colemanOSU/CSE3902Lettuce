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

namespace sprint0Real.LinkSprites
{
    internal class UseLeftSprite : ILinkSprite
    {
        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 4;
        private float _frameSpeed = 0.2f;
        private int _currentFrame;
        private double _timer;
        private bool flag = false;
        private Rectangle sourceRectangle = new(124, 11, 16, 16);
        private Rectangle destinationRectangle;


        public UseLeftSprite(Texture2D texture, Game1 game)
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
                switch (_currentFrame)
                {
                    case 1:
                        myGame.Link.DrawWeaponSprite();
                        break;
                    case 2:
                        sourceRectangle = new(52, 11, 16, 16);
                        break;
                    case 3:
                        sourceRectangle = new(35, 11, 16, 16);
                        flag = true;
                        break;
                }
            }
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            myGame.Link.SetCanMove(true);
            myGame.Link.SetCanAttack(true);
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
