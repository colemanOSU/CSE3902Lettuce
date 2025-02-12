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
    public class EnemyPage : IMap
    {
        private List<IEnemy> enemyList;
        public EnemyPage()
        {
            // Add enemies to be spawned here
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
        public void Stage(IEnemy enemy)
        {
            enemyList.Add(enemy);
        }

        public void DeStage(IEnemy enemy)
        {
            enemyList.Remove(enemy);
        }
    }
}
