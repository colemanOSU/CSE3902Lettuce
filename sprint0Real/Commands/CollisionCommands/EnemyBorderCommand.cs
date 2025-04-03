using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    internal class EnemyBorderCommand : ICollisionCommand
    {
        public void Execute(IObject objA, IObject objB, CollisionDirections direction)
        {
            ((IEnemy)objA).ChangeDirection();
        }
    }
}
