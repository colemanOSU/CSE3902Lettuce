using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkWeaponCollisionCommand : ICollisionCommand
    {
        private Game1 game;

        public LinkWeaponCollisionCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute(IGameObject weapon, IGameObject enemy, CollisionDirections direction)
        {
            if (game.collisionDetection.isWeaponActive)
            {
                System.Diagnostics.Debug.WriteLine("Enemy was hit!");
            }
        }
    }
}
