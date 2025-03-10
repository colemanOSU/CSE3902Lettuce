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
        private List<IObject> gameObjectsInRoom;
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
        public void Load(ILink Link)
        {
            UpdateRoomObjects();
            link = Link;
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
            // Link against all game objects
            // Link against all collisionBoxes
            // Enemies against Link Projectiles
            // Enemies against Borders 
            foreach(IEnemy enemy in gameObjectsInRoom.OfType<IEnemy>())
            {
                if (link.Rect.Intersects(enemy.Rect))
                {
                    collisionHandler.HandleCollision(link, enemy);
                }
                foreach (ICollisionBoxes collision in gameObjectsInRoom.OfType<ICollisionBoxes>())
                {
                    if (enemy.Rect.Intersects(collision.Rect))
                    {
                        //HandleCollisionOnce(enemy, collision);
                    }
                }
            }
        }
    }
}