using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Debug.WriteLine("Transition");
            Debug.WriteLine(DateTime.Now.ToString());
            /*
            String neighbor = CurrentMap.Instance.GetNeighbor(direction.ToString());
            EnemyPage nextMap = LevelLoader.Instance.RetrieveMap(neighbor);
            CurrentMap.Instance.SetMap(nextMap);
            */
        }
    }
}
