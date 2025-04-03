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
        Rectangle myDestinationRectangle;
        private String direction;
        public RoomTransitionBox(Rectangle destinationRectangle, String direction)
        {
            myDestinationRectangle = destinationRectangle;
            this.direction = direction;
        }
        public Rectangle Rect
        {
            get
            {
                return myDestinationRectangle;
            }
        }

        public String Direction
        {
            get
            {
                return direction;

            }
        }
    }
}
