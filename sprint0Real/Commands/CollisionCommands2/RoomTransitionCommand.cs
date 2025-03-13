using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class RoomTransitionCommand : ICollisionCommand2
    {
        public void Execute(IObject Link, IObject transitionBox, CollisionDirections direction)
        {
            String neighbor = CurrentMap.Instance.GetNeighbor(direction.ToString());
            EnemyPage nextMap = LevelLoader.Instance.RetrieveMap(neighbor);
            CurrentMap.Instance.SetMap(nextMap);
            // Adjust this to be right
            ((Link)Link).SetLocation(new Rectangle(200, 200, 19, 19));
        }
    }
}
