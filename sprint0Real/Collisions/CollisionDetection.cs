using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Diagnostics;
using sprint0Real.Items.ItemSprites;
using sprint0Real.Levels;
using System.Linq;

namespace sprint0Real.Collisions
{
    public class CollisionDetection
    {
        private List<IGameObject> gameObjectsInRoom;
        private List<ICollisionBoxes> collisionBoxesInRoom;
        private ILink link;
        //private CollisionHandler collisionHandler;
        private CollisionHandler2 collisionHandler;
        public bool isWeaponActive = false;
        private Game1 game; //passing in game right now because need it for more commands, probably could take out if we alter how things are set up
        
        private Dictionary<(IObject, IObject), bool> executedCollisions = new Dictionary<(IObject, IObject), bool>(); // Track executed collisions

        public CollisionDetection(Game1 game)
        {
            this.game = game;
            //collisionHandler = new CollisionHandler("Collisions/CollisionCommands.xml", game);
            collisionHandler = new CollisionHandler2(game);
        }
        public void LoadLink(ILink Link)
        {
            link = Link;
        }

        public void UpdateRoomObjects()
        {
            gameObjectsInRoom = CurrentMap.Instance.ObjectList();
            collisionBoxesInRoom = CurrentMap.Instance.CollisionList();
        }

        public void Update(GameTime gametime)
        {
            CheckCollisions();
        }

        public void CheckCollisions()
        {
            /*
            for (int i = 0; i < gameObjectsInRoom.Count; i++)
            {
                var objA = gameObjectsInRoom[i];

                for (int j = i + 1; j < gameObjectsInRoom.Count; j++) // Only check each pair once
                {
                    var objB = gameObjectsInRoom[j];

                    if (objA.Rect.Intersects(objB.Rect) && objA is not ILinkSprite && objB is not ILinkSprite || objA.Rect.Intersects(objB.Rect) && objA is ILinkSprite && isWeaponActive || objB is ILinkSprite)
                    {
                        CollisionDirections direction = DetectCollisionDirection(objA, objB);
                        collisionHandler.HandleCollision(objA, objB, direction);
                    }
                }
            }
            */

            // Link against all game objects
            // Link against all collisionBoxes
            // Enemies against Link Projectiles
            // Enemies against Borders 
            foreach(IEnemy enemy in gameObjectsInRoom.OfType<IEnemy>())
            {
                if (ILink.rect)
                {
                    
                }
                foreach (ICollisionBoxes collision in collisionBoxesInRoom)
                {
                    if (enemy.Rect.Intersects(collision.Rect))
                    {
                        //HandleCollisionOnce(enemy, collision);
                    }
                }
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