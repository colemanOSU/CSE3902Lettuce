using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace sprint0Real.Interfaces
{
    public interface IBlock
    {
        void Update(GameTime gametime);

        void Draw(SpriteBatch spriteBatch);
        public Rectangle CollisionBox { get; }

    }
}
