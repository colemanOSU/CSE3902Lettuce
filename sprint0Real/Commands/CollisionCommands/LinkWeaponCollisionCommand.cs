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
    public class LinkWeaponCollisionCommand : ICollisionCommand
    {
        private readonly Game1 _game;

        public LinkWeaponCollisionCommand(Game1 game)
        {
            _game = game;
        }

        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {
            if (Rectangle.Intersect(objA.Rect, objB.Rect))
            {
                System.Diagnostics.Debug.WriteLine("enemy was hit");
            }
        }
    }
}
