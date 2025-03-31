using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Linq.Expressions;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.LinkSprites;

namespace sprint0Real.Items.ItemSprites
{
    internal class BlueArrowSprite : ILinkSprite
    {
        public bool IsActive { get; private set; } = true; // Start inactive
        private SoundEffect soundEffect;
        private bool soundPlayed = false;
        public void Disable()
        {
            IsActive = false; // This keeps the weapon in memory but disables it
        }

        public void Activate()
        {
            IsActive = true;
        }
        private Rectangle sourceRectangle = new(10, 185, 16, 16);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private Game1 myGame;
        private Vector2 startPosition;
        private Vector2 velocity;
        private double _timer;
        private bool isMoving = true;
        private Vector2 _position;
        private double delayTimer;
        private double delayDuration = 0.5;
        private bool isDelaying = false;
        private Vector2 finalPosition;
        private Link.Direction arrowDirection;
        
        public BlueArrowSprite(Texture2D texture, Game1 game)
        {

            _texture = texture;
            myGame = game;
            _timer = 0;
            velocity = Vector2.Zero;
            arrowDirection = myGame.Link.GetFacing();
            GetPosition(arrowDirection);
            _position = startPosition;
            destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
            //soundEffect = SoundEffectFactory.Instance.getArrowOrBoomerang();

        }

        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
        public void GetPosition(Link.Direction direction)
        {
            switch (direction)
            {
                case Link.Direction.Right:
                    velocity = new Vector2(300, 0);
                    startPosition = new(myGame.Link.GetLocation().X + 16 * 3, myGame.Link.GetLocation().Y);
                    break;
                case Link.Direction.Left:
                    velocity = new Vector2(-300, 0);
                    startPosition = new(myGame.Link.GetLocation().X - 9 * 3, myGame.Link.GetLocation().Y);
                    break;
                case Link.Direction.Up:
                    velocity = new Vector2(0, -300);
                    startPosition = new(myGame.Link.GetLocation().X + 3 * 3, myGame.Link.GetLocation().Y - 16 * 3);
                    break;
                case Link.Direction.Down:
                    velocity = new Vector2(0, 300);
                    startPosition = new(myGame.Link.GetLocation().X + 3 * 3, myGame.Link.GetLocation().Y + 14 * 3);
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isDelaying)
            {
                sourceRectangle = new(53, 189, 8, 8);
                switch (arrowDirection)
                {
                    case Link.Direction.Right:
                        destinationRectangle = new Rectangle((int)finalPosition.X + (16 * 3), (int)finalPosition.Y + 5, 8 * 3, 8 * 3);
                        break;

                    case Link.Direction.Left:
                        destinationRectangle = new Rectangle((int)finalPosition.X - (8 * 3), (int)finalPosition.Y + 5, 8 * 3, 8 * 3);
                        break;

                    case Link.Direction.Up:
                        destinationRectangle = new Rectangle((int)finalPosition.X + 5, (int)finalPosition.Y - (8 * 3), 8 * 3, 8 * 3);
                        break;

                    case Link.Direction.Down:
                        destinationRectangle = new Rectangle((int)finalPosition.X + 5, (int)finalPosition.Y + (16 * 3), 8 * 3, 8 * 3);
                        break;
                }

                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                return;
            }
            if (isMoving)
            {
                switch (arrowDirection)
                {
                    case Link.Direction.Right:
                        sourceRectangle = new(36, 185, 16, 16);
                        destinationRectangle = new((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Link.Direction.Left:
                        sourceRectangle = new(36, 185, 16, 16);
                        destinationRectangle = new((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                        break;
                    case Link.Direction.Up:
                        sourceRectangle = new(27, 185, 8, 16);
                        destinationRectangle = new((int)_position.X, (int)_position.Y, 8 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Link.Direction.Down:
                        sourceRectangle = new(27, 185, 8, 16);
                        destinationRectangle = new((int)_position.X, (int)_position.Y, 8 * 3, 16 * 3);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipVertically, 0);
                        break;
                }

            }

        }

        public void Update(GameTime gameTime)
        {
            if (!soundPlayed)
            {
                soundEffect.Play();
                soundPlayed = true;
            }
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (isMoving)
            {
                _position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, destinationRectangle.Width, destinationRectangle.Height);
                if (_timer >= 2)
                {
                    isMoving = false;
                    velocity = Vector2.Zero;
                    finalPosition = _position;
                    isDelaying = true;
                    delayTimer = 0;
                }
            }
            if (isDelaying)
            {
                delayTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (delayTimer >= delayDuration)
                {
                    isDelaying = false;
                    myGame.weaponItemsB = new NullSprite(_texture, myGame);
                }
            }
        }

    }
}
