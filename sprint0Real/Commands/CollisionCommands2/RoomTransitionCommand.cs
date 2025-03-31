using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.CollisionBoxes;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class RoomTransitionCommand : ICollisionCommand2
    {
        CollisionDetection collisionDetector;
        TransitionDirections transitionDirections;
        public RoomTransitionCommand(CollisionDetection collisionDetector) 
        { 
            this.collisionDetector = collisionDetector;
            transitionDirections = new TransitionDirections();
        }
        private void newLinkLocation(Link link, String transitionDirection)
        {
            Rectangle placement = transitionDirections.ReturnPlacement(transitionDirection);
            link.SetLocation((placement));
        }
        public void Execute(IObject Link, IObject transitionBox, CollisionDirections direction)
        {
            String transitionDirection = ((RoomTransitionBox)transitionBox).Direction;
            String neighbor = CurrentMap.Instance.GetNeighbor(transitionDirection);
            EnemyPage nextMap = LevelLoader.Instance.RetrieveMap(neighbor);
            CurrentMap.Instance.SetMap(nextMap);
            collisionDetector.UpdateRoomObjects();
            newLinkLocation((Link)Link, transitionDirection);
        }
    }
}
