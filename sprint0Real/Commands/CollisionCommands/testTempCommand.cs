using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    public class testTempCommand : ICollisionCommand
    {
        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {
            Debug.WriteLine("Collision");
        }

    }
}
