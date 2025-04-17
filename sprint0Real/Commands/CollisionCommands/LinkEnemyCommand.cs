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
using sprint0Real.Levels;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class LinkEnemyCommand() : ICollisionCommand
    {
        public void Execute(IObject Link, IObject Enemy, CollisionDirections direction)
        {
            if (Enemy.GetType().Name == "Hand")
            {
                EnemyPage nextMap = LevelLoader.Instance.RetrieveMap("Entrance");
                CurrentMap.Instance.SetMap(nextMap);
            }
            else
            {
                ((Link)Link).TakeDamage();
            }
        }
    }
}
