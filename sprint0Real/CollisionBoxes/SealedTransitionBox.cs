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
    public class SealedTransitionBox : ILockedTransitionBox, IUpdates, ITouchesLink
    {

        public Rectangle Rect { get; }
        public String direction { get; }
        public SealedTransitionBox(Rectangle destinationRectangle, String direction)
        {
            Rect = destinationRectangle;
            this.direction = direction;
        }
        public void Update(GameTime gameTime)
        {
            if (CheckIfAllEnemiesDead())
            {
                Unlock();
            }
        }
        public bool CheckIfAllEnemiesDead()
        {
            List<IObject> objectList = CurrentMap.Instance.ObjectList();
            foreach (IEnemy enemy in objectList.OfType<IEnemy>())
            {
                return false;
            }
            return true;
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
