using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkEnemyCollisionCommand : ICollisionCommand
    {
        private Game1 game;

        public LinkEnemyCollisionCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {

            // Check if objA is a Dragon
            if (objA is Link linkA)
            {
                linkA.TakeDamage();
            }

            // Check if objB is a Dragon
            if (objB is Link linkB)
            {
                linkB.TakeDamage();
            }

        }

    }
}
