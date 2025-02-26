using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;

namespace sprint0Real.Items.ItemSprites
{
    internal class NullSprite : ILinkSprite
    {

        public Rectangle Rect
        {
            get { return new Rectangle(0, 0, 0, 0); }
        }
        public NullSprite(Texture2D texture, Game1 game)
        {
        }
        public void Update(GameTime gametime, SpriteBatch spriteBatch)
        {
           //static
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }

    }
}
