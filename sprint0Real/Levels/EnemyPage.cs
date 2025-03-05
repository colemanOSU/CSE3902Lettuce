using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.EnemyStuff.DragonStuff;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.Fireballs;


namespace sprint0Real.Levels
{
    public class EnemyPage
    {
        private List<IGameObject> gameObjects;
        private List<ICollisionBoxes> Hitboxes;
        private Dictionary<String, String> Neighbors;
        public LevelBackground background;

        /* DELETE LATER
         * This should allow RoomTransitioncCommand to look like:
         * String NextMapName = CurrentMap.Instance.myMap.Neighbors[Direction];
         * CurrentMap.Instance.myMap = LevelLoader.Instance.Maps[NextMapName];
         * Collisions.ObjectList = CurrentMap.Instance.GameObjectList();
         * Collisions.RoomCollisions = CurrentMap.Instance.RoomCollisionsList();
         */

        public EnemyPage()
        {
            gameObjects = new List<IGameObject>();
        }

        
        public List<IGameObject> ReturnGameObjectList()
        {
            return gameObjects;
        }

        public List<ICollisionBoxes> ReturnHitboxList()
        {
            return Hitboxes;
        }

        public void Update(GameTime time)
        {
            foreach (IEnemy enemy in gameObjects)
            {
                enemy.Update(time);
            }
        }

        public void AddNeighbor(String side, String name)
        {
            Neighbors.Add(side, name);
        }

        public void AddCollisionBox(ICollisionBoxes collisionBox)
        {
            Hitboxes.Add(collisionBox);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEnemy enemy in gameObjects)
            {
                enemy.Draw(spriteBatch);
            }
            //background.Draw(spriteBatch);
        }
        public void Stage(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void DeStage(IGameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }
    }
}
