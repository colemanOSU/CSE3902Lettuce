using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using sprint0Real.Collisions;
using sprint0Real.Commands.CollisionCommands2;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkLockedTransitionBoxCollisionCommand : ICollisionCommand
    {
        // Check if the transitionbox is a "locked" and if so, check if link has a key
        // else just act like a border. 
        LinkBorderCommand borderCommand = new LinkBorderCommand();

        public void Execute(IObject link, IObject border, CollisionDirections direction)
        {
            Link Link = (Link)link;
            if (border.GetType().ToString() == "LockedTransitionBox")
            {
                if (Link.inventory.KeyCount > 0)
                {
                    // Add sound effect
                    ((ILockedTransitionBox)border).Unlock();
                }
            }
            else
            {
                borderCommand.Execute(link, border, direction);
            }
        }
    }
}
