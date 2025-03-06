using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace sprint0Real.Interfaces
{
    public interface ICollision
    {
        void Update(GameTime gametime);

        void UpdateRoomObjects(List<IGameObject> objects, ILink link);

    }
}