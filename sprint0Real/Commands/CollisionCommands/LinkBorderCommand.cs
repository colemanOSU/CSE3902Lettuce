using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class LinkBorderCommand : ICollisionCommand
    {

        private void Adjust(Link Link, ICollisionBoxes Border, CollisionDirections direction)
        {

            Rectangle rectA = Link.Rect;
            Rectangle rectB = Border.Rect;

            //calculate overlap
            int overlapBottom = rectB.Bottom - rectA.Top;
            int overlapTop = rectA.Bottom - rectB.Top;
            int overlapRight = rectB.Right - rectA.Left;
            int overlapLeft = rectA.Right - rectB.Left;

            Rectangle Linklocation = Link.GetLocation();
            switch (direction)
            {
                case CollisionDirections.Left:
                    Link.SetLocation(new Rectangle(Linklocation.X - overlapLeft, Linklocation.Y, 50, 50));
                    break;
                case CollisionDirections.Right:
                    Link.SetLocation(new Rectangle(Linklocation.X + overlapRight, Linklocation.Y, 50, 50));
                    break;
                case CollisionDirections.Up:
                    Link.SetLocation(new Rectangle(Linklocation.X, Linklocation.Y - overlapTop, 50, 50));
                    break;
                case CollisionDirections.Down:
                    Link.SetLocation(new Rectangle(Linklocation.X, Linklocation.Y + overlapBottom, 50, 50));
                    break;
            }
        }
        public void Execute(IObject Link, IObject Border, CollisionDirections direction)
        {
            Adjust((Link)Link, (ICollisionBoxes)Border, direction);
            ((Link)Link).StopMomentumInDirection(direction.ToLinkDirection());        
        }
    }
}
