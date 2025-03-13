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
        private List<IObject> gameObjects;
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
            gameObjects = new List<IObject>();
            background = new LevelBackground();
        }
        public List<IObject> ReturnObjectList()
        {
            return gameObjects;
        }
        public void Update(GameTime time)
        {
            foreach (IGameObject enemy in gameObjects.OfType<IGameObject>())
            {
                enemy.Update(time);
            }
        }
        public void AddNeighbor(String side, String name)
        {
            Neighbors.Add(side, name);
        }

        public String GetNeighbor(String direction)
        {
            return Neighbors[direction];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            foreach (IGameObject gameObject in gameObjects.OfType<IGameObject>())
            {
                gameObject.Draw(spriteBatch);
            }
        }
        public void Stage(IObject thing)
        {
            gameObjects.Add(thing);
        }
        public void DeStage(IObject thing)
        {
            gameObjects.Remove(thing);
        }
    }
}
