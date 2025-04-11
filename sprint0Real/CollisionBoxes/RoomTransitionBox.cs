using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;

namespace sprint0Real.CollisionBoxes
{
    public class RoomTransitionBox : ICollisionBoxes, ITouchesLink
    {
        public Rectangle Rect { get; }
        public String direction { get; }
        public RoomTransitionBox(Rectangle destinationRectangle, String direction)
        {
            Rect = destinationRectangle;
            this.direction = direction;
        }
    }
}
