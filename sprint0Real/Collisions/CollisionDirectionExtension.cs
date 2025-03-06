using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.Collisions
{
    public static class CollisionDirectionExtensions
    {
        public static Link.Direction ToLinkDirection(this CollisionDirections dir)
        {
            return dir switch
            {
                CollisionDirections.Up => Link.Direction.Up,
                CollisionDirections.Down => Link.Direction.Down,
                CollisionDirections.Left => Link.Direction.Left,
                CollisionDirections.Right => Link.Direction.Right,
                _ => Link.Direction.None,
            };
        }
    }
}
