using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff
{
    // This is a temporary class that I made so that it can be easier to cycle through the different enemies
    public class EnemyCycleExample
    {
        private List<IMap> enemyList;
        private IMap enemyToDraw;
        private int current;
        private int total;
        private Vector2 location = new Vector2(10, 10);


        public EnemyCycleExample()
        {
            enemyList = new List<IMap>();
            location = new Vector2(0, 0);

            // Add the enemies that have been made 
            AddEnemies();

            total = enemyList.Count;
            enemyToDraw = enemyList[0];
            CurrentMap.Instance.SetMap(enemyToDraw);
        }

        private void AddEnemies()
        {
            enemyList.Add(new EnemyPage(new Dragon(location)));
        }

        public void NextEnemy()
        {
            current = (current + 1) % total;
            enemyToDraw = enemyList[current];
            CurrentMap.Instance.SetMap(enemyToDraw);
        }

        public void PreviousEnemy()
        {
            current = (current - 1) % total;
            enemyToDraw = enemyList[current];
            CurrentMap.Instance.SetMap(enemyToDraw);
        }

        public void Update(GameTime gameTime)
        {
            CurrentMap.Instance.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentMap.Instance.Draw(spriteBatch);
            enemyToDraw.Draw(spriteBatch);
        }
    }
}
