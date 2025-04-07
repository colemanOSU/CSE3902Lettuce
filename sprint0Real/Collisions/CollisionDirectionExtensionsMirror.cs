using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.Collisions
{
    public static class CollisionDirectionExtensionsMirror
    {
        public static Link.Direction ToLinkDirectionMirror(this CollisionDirections dir)
        {
            return dir switch
            {
                CollisionDirections.Up => Link.Direction.Down,
                CollisionDirections.Down => Link.Direction.Up,
                CollisionDirections.Left => Link.Direction.Right,
                CollisionDirections.Right => Link.Direction.Left,
                _ => Link.Direction.None,
            };
        }
    }
}
