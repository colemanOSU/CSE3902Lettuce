using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace sprint0Real.Items.ItemSprites
{
    internal class BombSprite : ILinkSprite
    {
        public bool IsActive { get; private set; } = false; // Start inactive

        public void Disable()
        {
            IsActive = false; // This keeps the weapon in memory but disables it
        }

        public void Activate()
        {
            IsActive = true;
        }
        private readonly Texture2D _texture;
        private readonly Game1 myGame;
        private readonly float _frameSpeed = 0.2f;
        private readonly int _frameCount = 3; 
        private int _currentFrame;
        private double _timer;
        private Vector2 _position;
        private bool isDelaying = true;
        private bool isAnimating = false;
        private bool animationComplete = false;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;


        public BombSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            _position = new(game.Link.GetLocation().X,game.Link.GetLocation().Y);
            SetPosition(game.Link.GetFacing());
            destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, isDelaying ? 8 * 3 : 16 * 3, 16 * 3);
            bombDrop = SoundEffectFactory.Instance.getBombDrop();
            bombExplode = SoundEffectFactory.Instance.GetBombExplode();
        }
        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }

        private void SetPosition(Link.Direction direction)
        {
            _position = myGame.Link.GetFacing() switch
            {
                Link.Direction.Right => new(myGame.Link.GetLocation().X + 16 * 3, myGame.Link.GetLocation().Y),
                Link.Direction.Left => new(myGame.Link.GetLocation().X - 9 * 3, myGame.Link.GetLocation().Y),
                Link.Direction.Up => new(myGame.Link.GetLocation().X + 3*3, myGame.Link.GetLocation().Y - 16*3),
                Link.Direction.Down => new(myGame.Link.GetLocation().X + 3*3, myGame.Link.GetLocation().Y + 14*3),
                _ => _position,
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (animationComplete) return;
            sourceRectangle = new Rectangle(isDelaying ? 129 : 138 + 17 * _currentFrame, 185, isDelaying ? 8 : 16, 16);
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            if (animationComplete) return;

            _timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= 1 && isDelaying)
            {
                isDelaying = false;
                isAnimating = true;
                _timer = 0;
                destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, isDelaying ? 8 * 3 : 16 * 3, 16 * 3);
            }
            
            if (isAnimating && _timer >= _frameSpeed)
            {
                _currentFrame++;
                _timer -= _frameSpeed;

                if (_currentFrame >= _frameCount)
                {
                    isAnimating = false;
                    animationComplete = true;
                    myGame.weaponItemsB = new NullSprite(_texture, myGame);
                }
            }
        }
    }
}
