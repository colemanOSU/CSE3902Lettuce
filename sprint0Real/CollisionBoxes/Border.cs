using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;

namespace sprint0Real.CollisionBoxes
{
    public class Border : ICollisionBoxes, ITouchesLink
    {
        Rectangle myDestinationRectangle;
        public Border(Rectangle destinationRectangle) {
            myDestinationRectangle = destinationRectangle;
        }
        public Rectangle Rect
        {
            get
            {
                return myDestinationRectangle;
            }
        }
    }
}
