using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.EnemyStuff.DragonStuff;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;


namespace sprint0Real.EnemyStuff
{
    public class EnemyPage
    {
        List<IEnemy> enemyList;

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
    }
}
