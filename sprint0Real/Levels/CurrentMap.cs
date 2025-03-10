using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Levels
{
    public class CurrentMap
    {
        // Functions as a singleton that holds the current stage, and as an interface between what should be added
        // to that stage.

        private static CurrentMap instance = new CurrentMap();
        private EnemyPage myMap;
        private List<IGameObject> stagingAdd;
        private List<IGameObject> stagingRemove; 

        private List<ICollisionBoxes> stageCollision;
        private List<ICollisionBoxes> removeCollision;
        public static CurrentMap Instance
        {
            get
            {
                return instance;
            }
        }
        private CurrentMap()
        { 
            stagingAdd = new List<IGameObject>();
            stagingRemove = new List<IGameObject>();
            stageCollision = new List<ICollisionBoxes>();
            removeCollision = new List<ICollisionBoxes>();
        }
        public void SetMap(EnemyPage newMap)
        {
            myMap = newMap;
        }

        public List<IGameObject> ObjectList()
        {
            return myMap.ReturnGameObjectList();
        }
        public List<ICollisionBoxes> CollisionList()
        {
            return myMap.ReturnHitboxList();
        }

        public void Stage(IGameObject enemy)
        {
            stagingAdd.Add(enemy);
        }

        public void DeStage(IGameObject enemy)
        {
            stagingRemove.Add(enemy);
        }

        public void Update(GameTime gameTime)
        {
            myMap.Update(gameTime);
            foreach (IGameObject enemy in stagingAdd)
            {
                myMap.Stage(enemy);
            }
            stagingAdd.Clear();
            foreach (IGameObject enemy in stagingRemove)
            {
                myMap.DeStage(enemy);
            }
            stagingRemove.Clear();
            foreach(ICollisionBoxes box in stageCollision)
            {
                myMap.AddCollisionBox(box);
            }
            stageCollision.Clear();
            foreach (ICollisionBoxes box in removeCollision)
            {
                myMap.DeStageCollision(box);
            }
            removeCollision.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myMap.Draw(spriteBatch);
        }
    }
}
