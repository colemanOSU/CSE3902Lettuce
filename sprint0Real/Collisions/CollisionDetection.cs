using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Diagnostics;
using sprint0Real.Items.ItemSprites;

namespace sprint0Real.Collisions
{
    public class CollisionDetection : ICollision
    {
        private List<IGameObject> gameObjectsInRoom = new List<IGameObject>();

        private Link link;
        public CollisionDirections recentCollisionDirection;
        //private CollisionHandler collisionHandler;
        private CollisionHandler2 collisionHandler;
        public bool isWeaponActive = false;
        private Game1 game; //passing in game right now because need it for more commands, probably could take out if we alter how things are set up
        
        private Dictionary<(IGameObject, IGameObject), bool> executedCollisions = new Dictionary<(IGameObject, IGameObject), bool>(); // Track executed collisions

        public CollisionDetection(Game1 game)
        {
            this.game = game;
            //collisionHandler = new CollisionHandler("Collisions/CollisionCommands.xml", game);
            collisionHandler = new CollisionHandler2(game);
        }
        public void UpdateRoomObjects(List<IGameObject> objects, ILink link,ILinkSprite weapon)

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
            for (int i = 0; i < gameObjectsInRoom.Count; i++)
            {
                var objA = gameObjectsInRoom[i];

                for (int j = i + 1; j < gameObjectsInRoom.Count; j++) // Only check each pair once
                {
                    var objB = gameObjectsInRoom[j];

                    if (objA.Rect.Intersects(objB.Rect) && objA is not ILinkSprite && objB is not ILinkSprite || objA.Rect.Intersects(objB.Rect) && objA is ILinkSprite && isWeaponActive || objB is ILinkSprite)
                    {
                        DetectCollisionDirection(objA, objB);
                        HandleCollisionOnce(objA, objB);
                    }
                }
            }

        }
        private void HandleCollisionOnce(IGameObject objA, IGameObject objB)
        {
            // Check if the collision has already been executed for this pair of objects
            if (!executedCollisions.ContainsKey((objA, objB)) && !executedCollisions.ContainsKey((objB, objA)))
            {
                // If not, handle the collision
                collisionHandler.HandleCollision(objA, objB, recentCollisionDirection);

                // Mark the collision as executed
                executedCollisions[(objA, objB)] = true;
                executedCollisions[(objB, objA)] = true; // Add both directions (since collisions are symmetric)
            }
        }

        public void DetectCollisionDirection(IGameObject objA, IGameObject objB)
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
        public void ResetExecutedCollisions()
        {
            // Reset the executed collisions at the end of the frame
            executedCollisions.Clear();
        }

    }
}

