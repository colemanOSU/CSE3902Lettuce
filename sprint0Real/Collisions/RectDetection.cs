using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.Collisions
{
    public class RectDetection
    {
        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            return rect1.IntersectsWith(rect2);
        }
    }
}
