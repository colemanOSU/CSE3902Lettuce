using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.CollisionBoxes;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkHandSpawnerCollisionCommand : ICollisionCommand
    {
        public void Execute(IObject Link, IObject Border, CollisionDirections direction)
        {
            ((HandVicinitySpawner)Border).AdvanceTimer();
        }
    }
}
