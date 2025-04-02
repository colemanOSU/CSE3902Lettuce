using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class LinkEnemyCommand() : ICollisionCommand
    {
        public void Execute(IObject Link, IObject Enemy, CollisionDirections direction)
        {
            ((Link)Link).TakeDamage();
        }
    }
}
