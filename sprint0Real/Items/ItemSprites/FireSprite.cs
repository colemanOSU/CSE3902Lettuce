using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;

namespace sprint0Real.Items.ItemSprites
{
    internal class FireSprite : ILinkSprite
    {
        private Rectangle sourceRectangle = new(10, 185, 16, 16);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 4;
        private float _frameSpeed = 0.2f;
        private int _currentFrame;
        private Vector2 startPosition;
        private Vector2 velocity;
        private double _timer;
        private bool flag = false;
        private bool isMoving = true;
        private Vector2 _position;

        public FireSprite(Texture2D texture, Game1 game)
        {

            _texture = texture;
            myGame = game;
            _timer = 0;
            velocity = Vector2.Zero;
            startPosition = new Vector2(game.Link.GetLocation().X + 15, game.Link.GetLocation().Y + 1);
            _position = startPosition;
            destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                switch (myGame.Link.GetFacing())
                {
                    case Link.Direction.Right:
                        velocity.X = 300;
                        sourceRectangle = new(10, 185, 16, 16);
                        destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);

                        break;
                    case Link.Direction.Left:
                        velocity.X = -300;
                        _position = new Vector2(myGame.Link.GetLocation().X - 15, myGame.Link.GetLocation().Y - 1);
                        sourceRectangle = new(10, 185, 16, 16);
                        destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
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
            else
            {
                sourceRectangle = new(53, 189, 8, 8);
                destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 8 * 3, 8 * 3);
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            }

        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (isMoving)
            {
                _position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_timer > 10)
                {
                    isMoving = false;
                    velocity = Vector2.Zero;
                }

            }
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
