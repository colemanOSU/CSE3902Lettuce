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


namespace sprint0Real.EnemyStuff
{
    public class EnemyPage
    {
        public List<IEnemy> enemyList;

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
            enemyList.Add(new Dragon(new Vector2(5, 5)));
        }

        public void Update(GameTime time)
        {
            foreach(IEnemy enemy in enemyList)
            {
                enemy.Update(time);
            }
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
