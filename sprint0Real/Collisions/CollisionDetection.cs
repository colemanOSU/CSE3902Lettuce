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
using System;

namespace sprint0Real.Collisions
{
    public class CollisionDetection
    {
        private List<IObject> gameObjectsInRoom;
        private ILink link;
        //private CollisionHandler collisionHandler;
        private CollisionHandler collisionHandler;
        public bool isWeaponActive = false;
        private Game1 game; //passing in game right now because need it for more commands, probably could take out if we alter how things are set up
        
        private Dictionary<(IObject, IObject), bool> executedCollisions = new Dictionary<(IObject, IObject), bool>(); // Track executed collisions

        public CollisionDetection(Game1 game, CollisionHandler collisionHandler)
        {
            this.game = game;
            this.collisionHandler = collisionHandler;
        }
        public void Load(ILink Link)
        {
            link = Link;
            UpdateRoomObjects();
        }

        public void UpdateRoomObjects()
        {
            gameObjectsInRoom = CurrentMap.Instance.ObjectList();
        }

        public void Update(GameTime gametime)
        {
            CheckCollisions();
        }

        public void CheckCollisions()
        {
            foreach (IObject A in gameObjectsInRoom.OfType<IObject>())
            {
                foreach (IObject B in gameObjectsInRoom.OfType<IObject>())
                {
                    if (A != B && A.Rect.Intersects(B.Rect))
                    {
                        collisionHandler.HandleCollision(A, B);
                    }
                }
                if (link.Rect.Intersects(A.Rect))
                {
                    collisionHandler.HandleCollision(link, A);
                }
            }
            /**
            foreach (IEnemy enemy in gameObjectsInRoom.OfType<IEnemy>())
            {
                // Enemies against Borders
                foreach (ICollisionBoxes collision in gameObjectsInRoom.OfType<ICollisionBoxes>())
                {
                    if (enemy.Rect.Intersects(collision.Rect))
                    {
                        collisionHandler.HandleCollision(enemy, collision);
                    }
                }
                // Enemies against blocks
                foreach (IBlock block in gameObjectsInRoom.OfType<IBlock>())
                {
                    if (enemy.Rect.Intersects(block.Rect))
                    {
                        collisionHandler.HandleCollision(enemy, block);
                    }
                }
                // Enemies against Link Projectiles
                foreach (ILinkSprite enemyDamage in gameObjectsInRoom.OfType<ILinkSprite>())
                {
                    if (enemy.Rect.Intersects(enemyDamage.Rect))
                    {
                        collisionHandler.HandleCollision(enemy, enemyDamage);
                    }
                }
            // Enemies against Enemies
            foreach (IEnemy enemy2 in gameObjectsInRoom.OfType<IEnemy>())
            {
                if (enemy != enemy2 && enemy.Rect.Intersects(enemy2.Rect))
                {
                    collisionHandler.HandleCollision(enemy, enemy2);
                }
            }
        }

            // Link against all collisionBoxes
            foreach (ITouchesLink source in gameObjectsInRoom.OfType<ITouchesLink>())
            {
                if (link.Rect.Intersects(source.Rect))
                {
                    collisionHandler.HandleCollision(link, source);
                }
            }
            **/
        }
    }
}