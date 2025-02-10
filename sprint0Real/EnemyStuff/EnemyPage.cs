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


namespace sprint0Real.EnemyStuff
{
    public class EnemyPage
    {
        public List<IEnemy> enemyList;
        public List<IEnemy> stagingAdd;
        public List<IEnemy> stagingRemove;


        private static EnemyPage instance = new EnemyPage();
        
        public static EnemyPage Instance
        {
            get
            {
                return instance;
            }
        }

        public EnemyPage()
        {
            enemyList = new List<IEnemy>();
            stagingAdd = new List<IEnemy>();
            stagingRemove = new List<IEnemy>();
        }

        public void AddEnemies()
        {
            enemyList.Add(new Dragon(new Vector2(5, 5)));
            enemyList.Add(new FireBall(new Vector2(0, 0), new Vector2(100, 100)));
        }

        public void Update(GameTime time)
        {
            foreach(IEnemy enemy in enemyList)
            {
                enemy.Update(time);
            }
            foreach(IEnemy enemy in stagingAdd){
                enemyList.Add(enemy);
            }
            stagingAdd.Clear();
            foreach (IEnemy enemy in stagingRemove)
            {
                enemyList.Remove(enemy);
            }
            stagingRemove.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
