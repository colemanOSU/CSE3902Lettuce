using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff;
using sprint0Real.EnemyStuff.BatStuff;
using sprint0Real.EnemyStuff.BubbleStuff;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.EnemyStuff.HandStuff;
using sprint0Real.EnemyStuff.RedGoriya;
using sprint0Real.EnemyStuff.SkeletonStuff;
using sprint0Real.EnemyStuff.BTrapStuff;
using sprint0Real.EnemyStuff.SnakeStuff;
using sprint0Real.EnemyStuff.ZolStuff;
using sprint0Real.Interfaces;
using sprint0Real.EnemyStuff.SlimeStuff;

namespace sprint0Real.EnemyStuff
{
    // This is a temporary class that I made so that it can be easier to cycle through the different enemies
    public class EnemyCycleExample
    {
        private List<IMap> enemyList;
        private IMap enemyToDraw;
        private int current;
        private int total;
        private Vector2 location = new Vector2(100, 100);


        public EnemyCycleExample()
        {
            enemyList = new List<IMap>();

            // Add the enemies that have been made 
            AddEnemies();

            total = enemyList.Count;
            enemyToDraw = enemyList[0];
            CurrentMap.Instance.SetMap(enemyToDraw);
        }

        private void AddEnemies()
        {
            enemyList.Add(new EnemyPage(new Bat(location)));
            enemyList.Add(new EnemyPage(new Goriya(location)));
            enemyList.Add(new EnemyPage(new Dragon(location)));
            enemyList.Add(new EnemyPage(new Skeleton(location)));
            enemyList.Add(new EnemyPage(new BTrap(location)));
            enemyList.Add(new EnemyPage(new Slime(location)));
            enemyList.Add(new EnemyPage(new Hand(location)));
            enemyList.Add(new EnemyPage(new Zol(location)));
            enemyList.Add(new EnemyPage(new Bubble(location)));
            enemyList.Add(new EnemyPage(new Snake(location)));
        }

        public void NextEnemy()
        {
            current = (current + 1) % total;
            enemyToDraw = enemyList[current];
            CurrentMap.Instance.SetMap(enemyToDraw);
        }

        public int ClockPrevious(int input, int total)
        {
            int result;
            if (input - 1 < 0)
            {
                result = total - 1;
            }
            else
            {
                result = input - 1;
            }
            return result;
        }

        public void PreviousEnemy()
        {
            
            current = ClockPrevious(current, total);
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
