using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Diagnostics;

namespace sprint0Real.Collisions
{
    public class CollisionDetection : ICollision
    {
        private List<IGameObject> gameObjectsInRoom = new List<IGameObject>();

        public void UpdateRoomObjects(List<IGameObject> objects)
        {
            gameObjectsInRoom = objects;
        }

        public void Update(GameTime gametime)
        {
            CheckCollisions();
        }

        public void CheckCollisions()
        {
            foreach (var objA in gameObjectsInRoom)
            {
                foreach (var objB in gameObjectsInRoom)
                {
                    if (objA == objB) continue; //don't need to check object against itself

                    if (objA.Rect.Intersects(objB.Rect))
                    {
                        DetectCollisionType(objA, objB);
                    }
                }
            }
        }

        public void DetectCollisionType(IGameObject objA, IGameObject objB)
        {
            if (objA is Link link && objB is IBlock block)
            {
                Debug.WriteLine("Link hits Block");

                Rectangle linkRect = link.Rect;
                Rectangle blockRect = block.Rect;

                //calculate overlap
                int overlapBottom = blockRect.Bottom - linkRect.Top;
                int overlapTop = linkRect.Bottom - blockRect.Top;
                int overlapRight = blockRect.Right - linkRect.Left;
                int overlapLeft = linkRect.Right - blockRect.Left;

                //find smallest overlap
                int minOverlap = MathHelper.Min(MathHelper.Min(overlapTop, overlapBottom), MathHelper.Min(overlapLeft, overlapRight));

                if (minOverlap == overlapTop)
                {
                    Debug.WriteLine("Collision from Top of Block");
                    link.StopMomentumInDirection(Link.Direction.Down);
                }
                else if (minOverlap == overlapBottom)
                {
                    Debug.WriteLine("Collision from Bottom of Block");
                    link.StopMomentumInDirection(Link.Direction.Up);
                }
                else if (minOverlap == overlapLeft)
                {
                    Debug.WriteLine("Collision from Left of Block");
                    link.StopMomentumInDirection(Link.Direction.Right);
                }
                else if (minOverlap == overlapRight)
                {
                    Debug.WriteLine("Collision from Right of Block");
                    link.StopMomentumInDirection(Link.Direction.Left);
                }
            }
            else if (objA is IEnemy enemy && objB is IBlock)
            {
                Debug.WriteLine("Enemy hits block");
            }
            else if (objA is Link && objB is IItem item)
            {
                Debug.WriteLine("Link hits item");
            }
            else if (objA is Link && objB is IEnemy)
            {
                Debug.WriteLine("Link hits enemy");
                //link.SetIsDamaged(true);
            }
        }
    }
}

