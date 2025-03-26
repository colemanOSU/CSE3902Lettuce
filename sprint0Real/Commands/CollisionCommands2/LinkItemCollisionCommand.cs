using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.ItemTempSprites;
using sprint0Real.Levels;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.Commands.CollisionCommands2
{
    internal class LinkItemCollisionCommand : ICollisionCommand2
    {
        public void Execute(IObject Link, IObject Item, CollisionDirections direction)
        {
            if (Link is Link linkA)
            {
                //TODO make link pick up item/update inventory etc.
            }
            if (Item is ITreasureItems item)
            {
                CurrentMap.Instance.DeStage(item);
            }
        }
    }
}
