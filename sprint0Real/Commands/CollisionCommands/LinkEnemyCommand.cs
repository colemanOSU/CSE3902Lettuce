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
using Microsoft.Xna.Framework;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class LinkEnemyCommand(Game1 game) : ICollisionCommand
    {
        public void Execute(IObject Link, IObject Enemy, CollisionDirections direction)
        {
            if (Enemy is IEnemy enemy && enemy.IsStunned)
            {
                return;
            }

            if (Enemy.GetType().Name == "Hand")
            {
                EnemyPage nextMap = LevelLoader.Instance.RetrieveMap("Entrance");
                CurrentMap.Instance.SetMap(nextMap);
                game.collisionDetection.UpdateRoomObjects();
            }
            else
            {
                ((Link)Link).TakeDamage();
            }
        }
    }
}
