using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff
{
    public class CurrentMap
    {
        // Functions as a singleton that holds the current stage, and as an interface between what should be added
        // to that stage.
        
        private static CurrentMap instance = new CurrentMap();
        private IMap myMap;
        private List<IEnemy> stagingAdd;
        private List<IEnemy> stagingRemove;
        public static CurrentMap Instance
        {
            get
            {
                return instance;
            }
        }
        private CurrentMap()
        {
            stagingAdd = new List<IEnemy>();
            stagingRemove = new List<IEnemy>();
        }

        public void SetMap(IMap enemy)
        {
            // REMEMBER TO FIX THIS AFTER SPRINT 2
            myMap = enemy;
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
