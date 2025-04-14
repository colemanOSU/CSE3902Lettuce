using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.NPCStuff;

namespace sprint0Real.Commands.CollisionCommands
{
    public class OldManCollisionCommand : ICollisionCommand
    {
        public void Execute(IObject objA, IObject objB, CollisionDirections direction)
        {
            // Add a way to know the amount of damage an item does
            ((OldManSprite)objA).TakeDamage(1);
        }
    }
}
