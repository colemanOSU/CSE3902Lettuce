using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace sprint0Real.Interfaces
{
    public interface ITreasureItems : IGameObject, ITouchesLink
    {
        //void Update(GameTime gametime);

        //void Draw(SpriteBatch spriteBatch);

        void CollectItem();
        //bool CanBePickedUp();

    }
}