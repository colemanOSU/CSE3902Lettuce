using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Audio;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;
using sprint0Real.WolfLink;
namespace sprint0Real.TreasureItemStuff.TreasureItemSprites
{
    internal class Triforce : ITreasureItems
    {
        private Texture2D _texture;
        private Game1 _game;
        private Rectangle[] _sourceFrames = new Rectangle[]
        {
            new Rectangle(275, 3, 10, 10),
            new Rectangle(275, 19, 10, 10)
        };

        private int _currentFrame = 0;
        private double _frameTimer = 0;
        private const double FrameDuration = 0.2;
        private bool SoundPlayed = false;

        private Rectangle destinationRectangle;

        public Triforce(Vector2 pos)
        {
            destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 10*3, 10*3);
            _texture = TreasureItemSpriteFactory.Instance.GetItemSpriteSheet();
        }
        public void CollectItem()
        {
            if (!SoundPlayed)
            {
                SoundEffectFactory.Instance.Play(SoundEffectType.itemPickup);
                SoundPlayed = true;
            }

        }
        public void Spawn()
        {
            CurrentMap.Instance.Stage(this);
        }
        public void Update(GameTime gameTime)
        {
            _frameTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (_frameTimer >= FrameDuration)
            {
                _frameTimer -= FrameDuration;
                _currentFrame = (_currentFrame + 1) % _sourceFrames.Length;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle, _sourceFrames[_currentFrame], Color.White);
        }
        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}
