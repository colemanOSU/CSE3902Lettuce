using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkBlockCollisionCommand : ICollisionCommand
    {
        private Game1 game;

        public LinkBlockCollisionCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {

            // Check if objA is a Dragon
            if (objA is Link linkA)
            {
                linkA.StopMomentumInDirection(direction.ToLinkDirection());
            }

            // Check if objB is a Dragon
            if (objB is Link linkB)
            {
                linkB.StopMomentumInDirection(direction.ToLinkDirection());
            }

        }
    }
}
