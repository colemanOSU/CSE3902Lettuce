using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.EnemyStuff.BTrapStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    public class EnemyEnemyCollisionCommand : ICollisionCommand
    {
        // This class is only used by blade traps
        public void Execute(IObject objA, IObject objB, CollisionDirections direction)
        {
            if (objA.GetType().Name == "BTrap" && objB.GetType().Name == "BTrap")
            {
                ((BTrap)objA).Return();
                ((BTrap)objB).Return();
            }
        }
    }
}
