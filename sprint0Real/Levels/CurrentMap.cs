using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        }

        public void SetMap(EnemyPage newMap)
        {
            myMap = newMap;
        }

        public List<IGameObject> MapList()
        {
            return myMap.ReturnList();
        }

        public void Stage(IEnemy enemy)
        {
            stagingAdd.Add(enemy);
        }

        public void DeStage(IEnemy enemy)
        {
            stagingRemove.Add(enemy);
        }

        public void Update(GameTime gameTime)
        {
            myMap.Update(gameTime);
            foreach (IEnemy enemy in stagingAdd)
            {
                myMap.Stage(enemy);
            }
            stagingAdd.Clear();
            foreach (IEnemy enemy in stagingRemove)
            {
                myMap.DeStage(enemy);
            }
            stagingRemove.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myMap.Draw(spriteBatch);
        }
    }
}
