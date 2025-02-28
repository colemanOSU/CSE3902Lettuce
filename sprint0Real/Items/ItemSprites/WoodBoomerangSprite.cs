using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System;

namespace sprint0Real.Items.ItemSprites
{
    internal class WoodBoomerangSprite : ILinkSprite
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D _texture;
        private Game1 myGame;
        private Vector2 startPosition;
        private Vector2 velocity;
        private Vector2 _position;
        private int _currentFrame;
        private double _timer;
        private bool isReturning = false;
        private float travelDistance = 180f;
        private float speed = 200f;
        private float _frameSpeed = 0.2f;
        private int _frameCount = 3;
        private Vector2 _finalPos;

        public WoodBoomerangSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            startPosition = new(game.Link.GetLocation().X,game.Link.GetLocation().Y);
            _position = startPosition;
            SetVelocity(game.Link.GetFacing());
            
        }
        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }

        private void SetVelocity(Link.Direction direction)
        {
            velocity = direction switch
            {
                Link.Direction.Right => new Vector2(speed, 0),
                Link.Direction.Left => new Vector2(-speed, 0),
                Link.Direction.Up => new Vector2(0, -speed),
                Link.Direction.Down => new Vector2(0, speed),
                _ => Vector2.Zero,
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sourceRectangle = new Rectangle(64 + 9 * _currentFrame, 185, 8, 16);
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime,SpriteBatch spriteBatch)
        {
            _finalPos = new(myGame.Link.GetLocation().X, myGame.Link.GetLocation().Y);
            destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 8 * 3, 16 * 3);
            _timer += gameTime.ElapsedGameTime.TotalSeconds;
           

            if (!isReturning && Vector2.Distance(_position, startPosition) >= travelDistance)
            {
                isReturning = true;
            }
            if (isReturning)
            {
                Vector2 direction = _finalPos - _position;

                if (direction.Length() > 0)
                    direction.Normalize();

                velocity = direction * speed;
            }
            _position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (isReturning && Vector2.Distance(_position, _finalPos) < 5f)
            {
                myGame.weaponItems = new NullSprite(_texture, myGame);
            }
            if (_timer > _frameSpeed)
            {
                _currentFrame = (_currentFrame + 1) % _frameCount;
                _timer -= _frameSpeed;
            }
        }
    }
}
