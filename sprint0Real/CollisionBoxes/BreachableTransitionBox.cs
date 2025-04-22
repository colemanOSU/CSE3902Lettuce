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
    public class BreachableTransitionBox : ILockedTransitionBox
    {
        public Rectangle Rect { get; }
        public String direction { get; }
        public BreachableTransitionBox(Rectangle destinationRectangle, String direction)
        {
            Rect = destinationRectangle;
            this.direction = direction;
        }

        private void setDoor(String direction, EnemyPage neighbor)
        {
            // breachable doors are only up or down
            if (direction == "Up")
            {
                neighbor.background.SetDownDoor("Breached");
            }
            else
            {
                neighbor.background.SetUpDoor("Breached");
            }
        }

        private void Cycle(List<IObject> gameObjects, String direction, EnemyPage neighbor)
        {
            ILockedTransitionBox remove = null;
            foreach (ILockedTransitionBox transitionBox in gameObjects.OfType<ILockedTransitionBox>())
            {
                if (transitionBox.direction == direction)
                {
                    remove = transitionBox;
                }
            }
            if (remove != null)
            {
                neighbor.DeStage(remove);
            }
            neighbor.Stage(new RoomTransitionBox(remove.Rect, direction));
        }

        private void setTransitionBox(String direction, EnemyPage neighbor)
        {
            List<IObject> gameObjects = neighbor.ReturnObjectList();
            if (direction == "Up")
            {
                Cycle(gameObjects, "Down", neighbor);
            }
            else
            {
                Cycle(gameObjects, "Up", neighbor);
            }
        }

        public void Unlock()
        {
            // Add sound effect
            String neighborName = CurrentMap.Instance.GetNeighbor(direction);
            EnemyPage neighbor = LevelLoader.Instance.RetrieveMap(neighborName);
            setTransitionBox(direction, neighbor);
            setDoor(direction, neighbor);
            CurrentMap.Instance.DeStage(this);
            CurrentMap.Instance.Stage(new RoomTransitionBox(Rect, direction));
            CurrentMap.Instance.SetDoor(direction, "Breached");
        }
    }
}
