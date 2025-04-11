using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.CollisionBoxes
{
        public class LockedTransitionBox : ICollisionBoxes, ITouchesLink
        {
            Rectangle myDestinationRectangle;
            private String direction;
            public LockedTransitionBox(Rectangle destinationRectangle, String direction)
            {
                myDestinationRectangle = destinationRectangle;
                this.direction = direction;
            }

        public void Unlock()
        {
            CurrentMap.Instance.Stage(new RoomTransitionBox(myDestinationRectangle, direction));
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
