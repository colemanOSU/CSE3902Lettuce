using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using sprint0Real.Collisions;

namespace sprint0Real.Interfaces
{
    public interface IBlock : IGameObject
    {
        void Update(GameTime gametime);

        void Draw(SpriteBatch spriteBatch);
        void Move(Vector2 direction);
        Vector2 Position { get; set; }


    }
}
