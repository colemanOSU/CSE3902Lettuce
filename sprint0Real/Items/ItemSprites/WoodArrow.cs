using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Linq.Expressions;

namespace sprint0Real.Items.ItemSprites
{
    internal class WoodArrow : ILinkSprite
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
        private double delayTimer;
        private double delayDuration = 0.5;
        private bool isDelaying = false;

        public WoodArrow(Texture2D texture, Game1 game)
        {
            
            _texture = texture;
            myGame = game;
            _timer = 0;
            velocity = Vector2.Zero;
            startPosition = new Vector2(game.Link.GetLocation().X + 15, game.Link.GetLocation().Y + 1);
            _position = startPosition;
            destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16*3, 16 * 3);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isMoving)
            {
                sourceRectangle = new(53, 189, 8, 8);
                destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y+13, 8 * 3, 8 * 3);
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                isDelaying = true;
                delayTimer = 0;
            }
            else { 
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
                        sourceRectangle = new(10, 185, 16, 16);
                        destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);
                        break;
                    case Link.Direction.Up:
                        velocity.X = 0;
                        velocity.Y = -300;
                        sourceRectangle = new(3, 185, 5, 16);
                        destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 5 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Link.Direction.Down:
                        velocity.X = 0;
                        velocity.Y = 300;
                        sourceRectangle = new(3, 185, 5, 16);
                        destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 5 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipVertically, 0);
                        break;
                }
            }

        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _timer += gameTime.ElapsedGameTime.TotalSeconds*2;
            if (isMoving)
            {
                _position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_timer > 1)
                {
                    isMoving = false;
                    velocity = Vector2.Zero;
                }
            }
            if (isDelaying)
            {
                delayTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (delayTimer >= delayDuration)
                {
                    isDelaying = false;
                    myGame.weaponItems = new NullSprite(_texture, myGame);
                }
            }
        }

    }
}
