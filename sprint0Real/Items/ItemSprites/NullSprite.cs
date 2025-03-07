using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;

namespace sprint0Real.Items.ItemSprites
{
    internal class NullSprite : ILinkSprite
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
        public Rectangle Rect
        {
            get { return new Rectangle(0, 0, 0, 0); }
        }
        public NullSprite(Texture2D texture, Game1 game)
        {
        }
        public void Update(GameTime gametime)
        {
           //static
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }

    }
}
