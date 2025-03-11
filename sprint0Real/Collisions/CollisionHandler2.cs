using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.BlockSprites;
using sprint0Real.Commands.CollisionCommands;
using sprint0Real.Commands.CollisionCommands2;
using sprint0Real.Interfaces;

namespace sprint0Real.Collisions
{
    public class CollisionHandler2
    {
        private Dictionary<(String, String), ICollisionCommand2> collisionCommands;
        private Game1 game;

        // Maybe make these strings
        public CollisionHandler2(Game1 game)
        {
            this.game = game;
            collisionCommands = new Dictionary<(String, String), ICollisionCommand2>();

            collisionCommands.Add(("Link", "Dragon"),  new LinkEnemyCommand());

            collisionCommands.Add(("Link", "Border"), new LinkBorderCommand());
        }
        private Type GetGeneralType(IGameObject obj)
        {
            if (obj is IEnemy) return typeof(IEnemy);  
            if (obj is IItemtemp) return typeof(IItemtemp); 
            if (obj is ILink) return typeof(ILink); 
            if (obj is IBlock) return typeof(IBlock);
            if (obj is ILinkSprite) return typeof(ILinkSprite);
            return obj.GetType();                      //Default to concrete type for anything else
        }
        public void HandleCollision(IObject objA, IObject objB)
        {
            //var key = (GetGeneralType(objA), GetGeneralType(objB));
            CollisionDirections direction = DetectCollisionDirection(objA, objB);
            if (collisionCommands.TryGetValue((objA.GetType().Name.ToString(), objB.GetType().Name.ToString()), out ICollisionCommand2 command))
            {
                command.Execute(objA, objB, direction);
            }
        }

        public CollisionDirections DetectCollisionDirection(IObject objA, IObject objB)
        {

            Rectangle rectA = objA.Rect;
            Rectangle rectB = objB.Rect;

            CollisionDirections recentCollisionDirection = CollisionDirections.Default;

            //calculate overlap
            int overlapBottom = rectB.Bottom - rectA.Top;
            int overlapTop = rectA.Bottom - rectB.Top;
            int overlapRight = rectB.Right - rectA.Left;
            int overlapLeft = rectA.Right - rectB.Left;

            //find smallest overlap
            int minOverlap = MathHelper.Min(MathHelper.Min(overlapTop, overlapBottom), MathHelper.Min(overlapLeft, overlapRight));

            if (minOverlap == overlapTop)
            {
                recentCollisionDirection = CollisionDirections.Up;
                //Debug.WriteLine("Collision from Top of " + objB.GetType().Name);
            }
            else if (minOverlap == overlapBottom)
            {
                recentCollisionDirection = CollisionDirections.Down;
                //Debug.WriteLine("Collision from Bottom of " + objB.GetType().Name);
            }
            else if (minOverlap == overlapLeft)
            {
                recentCollisionDirection = CollisionDirections.Left;
                //Debug.WriteLine("Collision from Left of " + objB.GetType().Name);

            }
            else if (minOverlap == overlapRight)
            {
                recentCollisionDirection = CollisionDirections.Right;
                //Debug.WriteLine("Collision from Right of " + objB.GetType().Name);
            }
            return recentCollisionDirection;
        }
    }
}
