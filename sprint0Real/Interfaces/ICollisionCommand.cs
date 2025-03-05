using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;

namespace sprint0Real.Interfaces
{
    public interface ICollisionCommand
    {
        void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction);
    }
}
