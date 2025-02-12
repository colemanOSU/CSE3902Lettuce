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
        private List<IEnemy> enemyList;
        private IEnemy enemyToDraw;
        private int current;
        private int total;
        private Vector2 location;

        public EnemyCycleExample()
        {
            enemyList = new List<IEnemy>();
            location = new Vector2(0, 0);

            // Add the enemies that have been made here
            enemyList.Add(new Dragon(location));

            total = enemyList.Count;
            enemyToDraw = enemyList[0];
        }

        public void NextEnemy()
        {
            current = (current + 1) % total;
            enemyToDraw = enemyList[current];
        }

        public void PreviousEnemy()
        {
            current = (current - 1) % total;
            enemyToDraw = enemyList[current];
        }

        public void Update(GameTime gameTime)
        {
            enemyToDraw.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemyToDraw.Draw(spriteBatch);
        }
    }
}
