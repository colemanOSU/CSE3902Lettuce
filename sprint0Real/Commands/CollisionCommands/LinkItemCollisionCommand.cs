using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkItemCollisionCommand : ICollisionCommand
    {
        private Game1 _game;

        public LinkItemCollisionCommand(Game1 game)
        {
            _game = game;
        }
        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {

            // Check if objA is a Dragon
            if (objA is Link linkA)
            {
                //pick up item
            }

            // Check if objB is a Dragon
            if (objB is Link linkB)
            {
                //pick up item
            }
            
        }
    }
}
