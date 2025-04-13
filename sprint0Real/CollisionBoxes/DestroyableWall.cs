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
    public class DestroyableWall : ILockedTransitionBox, ITouchesLink
    {
        public Rectangle Rect { get; }
        public String direction { get; }
        public DestroyableWall(Rectangle destinationRectangle, String direction)
        {
            Rect = destinationRectangle;
            this.direction = direction;
        }
        public void Unlock()
        {
            // Add sound effect
            CurrentMap.Instance.DeStage(this);
            CurrentMap.Instance.Stage(new RoomTransitionBox(Rect, direction));
            CurrentMap.Instance.SetDoor(direction, "Open");
        }
    }
}
