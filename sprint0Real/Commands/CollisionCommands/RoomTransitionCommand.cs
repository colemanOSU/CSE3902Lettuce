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
        TransitionDirections transitionDirections;
        Game1 myGame;
        public RoomTransitionCommand(Game1 game) 
        { 
            myGame = game;
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
                    target = new Vector2(Game1.SCREENMIDX * 3, Game1.SCREENMIDY);
                    break;
                case CollisionDirections.Right:
                    target = new Vector2(-Game1.SCREENMIDX, Game1.SCREENMIDY);
                    break;
                case CollisionDirections.Up:
                    target = new Vector2(Game1.SCREENMIDX, Game1.SCREENMIDY + 504);
                    break;
                case CollisionDirections.Down:
                    target = new Vector2(Game1.SCREENMIDX, Game1.SCREENMIDY - 504);
                    break;
            }
            return target;
        }
        private void SetOffset(CollisionDirections direction)
        {
            switch (direction)
            {
                case CollisionDirections.Left:
                    myGame.transitionOffset = new Vector2(Game1.SCREENWIDTH, 0);
                    break;
                case CollisionDirections.Right:
                    myGame.transitionOffset = new Vector2(-Game1.SCREENWIDTH, 0);
                    break;
                case CollisionDirections.Up:
                    myGame.transitionOffset = new Vector2(0, 504);
                    break;
                case CollisionDirections.Down:
                    myGame.transitionOffset = new Vector2(0, -504);
                    break;
            }
        }
        public void Execute(IObject Link, IObject transitionBox, CollisionDirections direction)
        {
            SetOffset(direction);
            myGame.UISprite.MoveLinkMapMarker(direction.ToLinkDirectionMirror());
            myGame._camera.target = TargetLocation(direction);
            myGame.currentGameState = GameState.GameStates.LevelTransition;
            CurrentMap.Instance.SetPrevious();
            String transitionDirection = ((RoomTransitionBox)transitionBox).direction;
            String neighbor = CurrentMap.Instance.GetNeighbor(transitionDirection);
            EnemyPage nextMap = LevelLoader.Instance.RetrieveMap(neighbor);
            CurrentMap.Instance.SetMap(nextMap);
            myGame.collisionDetection.UpdateRoomObjects();
            NewLinkLocation((Link)Link, transitionDirection);
            myGame.Link.GetInventory().blueCandleUsedThisRoom = false;
        }
    }
}
