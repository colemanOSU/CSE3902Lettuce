using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.CollisionBoxes;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;

namespace sprint0Real.Commands.CollisionCommands
{
    public class BombBreachableWallCollisionCommand : ICollisionCommand
    {
        public void Execute(IObject border, IObject bomb, CollisionDirections direction)
        {
           if (bomb.GetType().Name == "BombSprite")
            {
                BombSprite Bomb = (BombSprite)bomb;
                if (Bomb.IsDetonated())
                {
                    ((BreachableTransitionBox)border).Unlock();
                }
            }
        }
    }
}
