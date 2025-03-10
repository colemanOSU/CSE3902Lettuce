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
        private List<IObject> stagingAdd;
        private List<IObject> stagingRemove; 
        public static CurrentMap Instance
        {
            get
            {
                return instance;
            }
        }
        private CurrentMap()
        { 
            stagingAdd = new List<IObject>();
            stagingRemove = new List<IObject>();
        }
        public void SetMap(EnemyPage newMap)
        {
            myMap = newMap;
        }

        public List<IObject> ObjectList()
        {
            return myMap.ReturnObjectList();
        }

        public void Stage(IObject enemy)
        {
            stagingAdd.Add(enemy);
        }

        public void DeStage(IObject thing)
        {
            stagingRemove.Add(thing);
        }

        public void Update(GameTime gameTime)
        {
            myMap.Update(gameTime);
            foreach (IObject thing in stagingAdd)
            {
                myMap.Stage(thing);
            }
            stagingAdd.Clear();
            foreach (IObject thing in stagingRemove)
            {
                myMap.DeStage(thing);
            }
            stagingRemove.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myMap.Draw(spriteBatch);
        }
    }
}
