
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Linq.Expressions;

namespace sprint0Real.Items.ItemSprites
{
    internal class MagicSword : ILinkSprite
    {
        private Rectangle sourceRectangle = new(80, 154, 16, 16);
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
        private Link.Direction swordDirection;


        public MagicSword(Texture2D texture, Game1 game)
        {

            _texture = texture;
            myGame = game;
            _timer = 0;
            velocity = Vector2.Zero;
            swordDirection = myGame.Link.GetFacing();
            GetPosition(swordDirection);
            _position = startPosition;
            destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);

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
            if (isMoving)
            {
                switch (swordDirection)
                {
                    case Link.Direction.Right:
                        sourceRectangle = new(80, 154, 16, 16);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Link.Direction.Left:
                        sourceRectangle = new(80, 154, 16, 16);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                        break;
                    case Link.Direction.Up:
                        sourceRectangle = new(71, 154, 8, 16);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Link.Direction.Down:
                        sourceRectangle = new(71, 154, 8, 16);
                        spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipVertically, 0);
                        break;
                }

            }

        }

        public void Update(GameTime gameTime)
        {
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            switch (swordDirection)
            {
                case Link.Direction.Right:
                    destinationRectangle = new((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
                    break;
                case Link.Direction.Left:
                    destinationRectangle = new((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
                    break;
                case Link.Direction.Up:
                    destinationRectangle = new((int)_position.X, (int)_position.Y, 8 * 3, 16 * 3);
                    break;
                case Link.Direction.Down:
                    destinationRectangle = new((int)_position.X, (int)_position.Y, 8 * 3, 16 * 3);
                    break;
            }
            if (isMoving)
            {
                _position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_timer >= 5)
                {
                    isMoving = false;
                    velocity = Vector2.Zero;
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
                    myGame.weaponItems = new NullSprite(_texture, myGame);
                }
            }
        }

    }
}
