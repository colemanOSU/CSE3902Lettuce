using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class LinkEnemyCommand() : ICollisionCommand2
    {
        public void Execute(IObject Link, IObject Enemy, CollisionDirections direction)
        {
            ((Link)Link).TakeDamage();
        }
    }
}
