using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.BlockSprites;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class LinkStairsCollisionCommand : ICollisionCommand
    {
        public void Execute(IObject Link, IObject Block, CollisionDirections direction)
        {
            if(Block is BlockSpriteStairs block)
            {
                block.TakeStairs();
            }
            if(Block is BlockSpriteBlack block2)
            {
                block2.TakeStairs();
            }
        }
    }
}
