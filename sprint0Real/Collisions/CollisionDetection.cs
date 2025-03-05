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
        private Link link;
        public CollisionDirections recentCollisionDirection;
        public void UpdateRoomObjects(List<IGameObject> objects, ILink link)
        {
            gameObjectsInRoom = objects;
            objects.Add(link);
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

            Rectangle rectA = objA.Rect;
            Rectangle rectB = objB.Rect;

            recentCollisionDirection = CollisionDirections.Default;

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

        }

    }
}

