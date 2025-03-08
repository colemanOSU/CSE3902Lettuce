using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkWallCollisionCommand : ICollisionCommand
    {
        private Game1 _game;

        public LinkWallCollisionCommand(Game1 game)
        {
            _game = game;
        }
        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {
            if (objA is Link link)
            {
                link.StopMomentumInDirection(direction.ToLinkDirection());
            }
            else if (objB is Link link2)
            {
                link2.StopMomentumInDirection(direction.ToLinkDirection());
            }
        }
    }
}
