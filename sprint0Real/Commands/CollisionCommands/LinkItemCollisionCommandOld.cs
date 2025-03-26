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
    public class LinkItemCollisionCommandOld : ICollisionCommand
    {
        private Game1 _game;

        public LinkItemCollisionCommandOld(Game1 game)
        {
            _game = game;
        }
        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {

            // Check if objA is Link
            if (objA is Link linkA)
            {
                linkA.PickUpItem();
            }

            // Check if objB is Link
            if (objB is Link linkB)
            {
                linkB.PickUpItem();
            }
            
        }
    }
}
