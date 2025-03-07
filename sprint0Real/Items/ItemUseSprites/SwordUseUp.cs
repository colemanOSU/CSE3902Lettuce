using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using static Link;

namespace sprint0Real.ItemUseSprites
{
    internal class SwordUseUp : ILinkSprite
    {
        private Texture2D _texture;
        private Game1 myGame;
        private float _frameSpeed = 2f;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        private bool isMoving = true;
        public bool IsActive { get; private set; } = false; // Start inactive

        public void Disable()
        {
            IsActive = false; // This keeps the weapon in memory but disables it
        }

        public void Activate()
        {
            IsActive = true;
        }
        public SwordUseUp(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            destinationRectangle = myGame.Link.GetLocation();
            sourceRectangle = new Rectangle(1, 154, 8, 16);
        }
        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (isMoving)
            {
                destinationRectangle.Y -= 4;

                if (destinationRectangle.Y <= 0)
                {
                    isMoving = false;
                }
            }
        }
    }
}
