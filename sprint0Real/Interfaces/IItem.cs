using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace sprint0Real.Interfaces
{
    public interface IItem : IGameObject
    {
        //public void Update(SpriteBatch spriteBatch);

        public void Draw(SpriteBatch _spriteBatch);

    }
}
