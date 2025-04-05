using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.CollisionBoxes;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class RoomTransitionCommand : ICollisionCommand
    {
        CollisionDetection collisionDetector;
        TransitionDirections transitionDirections;
        Camera camera;
        public RoomTransitionCommand(CollisionDetection collisionDetector, Camera camera) 
        { 
            this.camera = camera;
            this.collisionDetector = collisionDetector;
            transitionDirections = new TransitionDirections();
        }
        private void NewLinkLocation(Link link, String transitionDirection)
        {
            Rectangle placement = transitionDirections.ReturnPlacement(transitionDirection);
            link.SetLocation((placement));
        }

        private Vector2 TargetLocation(CollisionDirections direction)
        {
            Vector2 target = new Vector2();
            switch(direction){
                case CollisionDirections.Left:
                    target = new Vector2();
                    break;
                case CollisionDirections.Right:
                    target = new Vector2();
                    break;
                case CollisionDirections.Up:
                    target = new Vector2();
                    break;
                case CollisionDirections.Down:
                    target = new Vector2();
                    break;
            }
            return target;
        }
        public void Execute(IObject Link, IObject transitionBox, CollisionDirections direction)
        {
            camera.target = TargetLocation(direction);
            String transitionDirection = ((RoomTransitionBox)transitionBox).Direction;
            String neighbor = CurrentMap.Instance.GetNeighbor(transitionDirection);
            EnemyPage nextMap = LevelLoader.Instance.RetrieveMap(neighbor);
            CurrentMap.Instance.SetMap(nextMap);
            collisionDetector.UpdateRoomObjects();
            NewLinkLocation((Link)Link, transitionDirection);
        }
    }
}
