using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.WolfLink
{
    internal class WolfMoveDownSprite : ILinkSpriteTemp
    {
        private Texture2D _texture;
        private Game1 _game;
        private static int[] width = new int[]
        {
            15,
            15
        };
        private static int[] height = new int[]
       {
            21,
            19
       };

        private Rectangle[] _sourceFrames = new Rectangle[]
        {
            new Rectangle(44, 2, width[0], height[0]),
            new Rectangle(62, 4, width[1], height[1])
        };

        private int _currentFrame = 0;
        private double _frameTimer = 0;
        private const double FrameDuration = 0.2;

        private Rectangle _destinationRectangle;

        public WolfMoveDownSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            _game = game;
            _destinationRectangle = _game.Link.GetLocation();
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _game.Link.MoveInDirection(Link.Direction.Down);
            _frameTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (_frameTimer >= FrameDuration)
            {
                _frameTimer -= FrameDuration;
                _currentFrame = (_currentFrame + 1) % _sourceFrames.Length;
            }

            Rectangle baseLocation = _game.Link.GetLocation();
            _destinationRectangle = new Rectangle(
                baseLocation.X,
                baseLocation.Y,
                width[_currentFrame] * 3,
                height[_currentFrame] * 3
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _destinationRectangle, _sourceFrames[_currentFrame], _game.Link.GetLinkColor());
        }
    }
}