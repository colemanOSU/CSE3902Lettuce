using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;

namespace sprint0Real.Items.ItemSprites
{
    internal class MagicSword : ILinkSprite
    {
        private Rectangle sourceRectangle = new(124, 78, 14, 14);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 4;
        private float _frameSpeed = 0.2f;
        private int _currentFrame;
        private double _timer;
        private bool flag = false;

        public MagicSword(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            _timer = 0;
            destinationRectangle = new Rectangle(game.Link.GetLocation().X + 13, game.Link.GetLocation().Y + 1, 14 * 3, 14 * 3);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (myGame.Link.GetFacing())
            {
                case Link.Direction.Right:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(218, 83, 13, 8);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 40, myGame.Link.GetLocation().Y + 20, 13 * 3, 8 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(151, 81, 11, 11);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 35, myGame.Link.GetLocation().Y + 13, 11 * 3, 11 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(165, 77, 17, 17);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 13, myGame.Link.GetLocation().Y, 17 * 3, 17 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                    break;
                case Link.Direction.Left:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(218, 83, 13, 8);
                            destinationRectangle = new(myGame.Link.GetLocation().X - 30, myGame.Link.GetLocation().Y + 20, 13 * 3, 8 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(151, 81, 11, 11);
                            destinationRectangle = new(myGame.Link.GetLocation().X - 28, myGame.Link.GetLocation().Y + 13, 11 * 3, 11 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(165, 77, 17, 17);
                            destinationRectangle = new(myGame.Link.GetLocation().X - 13, myGame.Link.GetLocation().Y, 17 * 3, 17 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                    break;
                case Link.Direction.Up:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(207, 97, 8, 13);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 12, myGame.Link.GetLocation().Y - 36, 8 * 3, 13 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(131, 98, 8, 13);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 12, myGame.Link.GetLocation().Y - 30, 8 * 3, 13 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(148, 106, 8, 3);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 10, myGame.Link.GetLocation().Y - 30, 8 * 3, 13 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                    break;
                case Link.Direction.Down:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(209, 61, 8, 13);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 16, myGame.Link.GetLocation().Y + 41, 8 * 3, 13 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(134, 61, 5, 9);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 19, myGame.Link.GetLocation().Y + 41, 5 * 3, 9 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(152, 61, 3, 5);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 16, myGame.Link.GetLocation().Y + 41, 3 * 3, 5 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                    break;
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
            if (flag == true)
            {
                myGame.Link.SetCanMove(true);
                myGame.Link.SetCanAttack(true);
                myGame.weaponItems = new NullSprite(_texture, myGame);
            }
        }

    }
}
