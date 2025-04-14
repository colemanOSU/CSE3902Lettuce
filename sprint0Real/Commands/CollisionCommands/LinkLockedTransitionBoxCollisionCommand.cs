using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private bool LinkHasKey(Link link)
        {
            return (link.inventory.KeyCount > 0);
        }
        public void Execute(IObject link, IObject border, CollisionDirections direction)
        {
            Link Link = (Link)link;
            if (border.GetType().Name == "LockedTransitionBox")
            {
                if (LinkHasKey(Link))
                {
                    Link.inventory.KeyUse();
                    ((ILockedTransitionBox)border).Unlock();
                }
                else
                {
                    borderCommand.Execute(link, border, direction);
                }
            }
            else
            {
                borderCommand.Execute(link, border, direction);
            }
        }
    }
}
