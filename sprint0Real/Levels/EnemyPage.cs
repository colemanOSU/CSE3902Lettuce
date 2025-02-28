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


namespace sprint0Real.Levels
{
    public class EnemyPage : IMap
    {
        private List<IEnemy> enemyList;
        private List<IBlock> blockList;
        private List<IItem> itemList;


        // Temporary for Sprit 2. Enemy Page should not have a parameter when initilizing
        public EnemyPage()
        {
            enemyList = new List<IEnemy>();
        }

        public void Update(GameTime time)
        {
            foreach (IEnemy enemy in enemyList)
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
