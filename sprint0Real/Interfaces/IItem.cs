using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.Interfaces
{
    public interface IItem
    {
        void Update(GameTime gameTime, SpriteBatch spriteBatch);

        void Draw(SpriteBatch spriteBatch);

    }
}
