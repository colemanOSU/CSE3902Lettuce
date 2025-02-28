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
    public class EnemyPage
    {
        public List<IGameObject> gameObjects;

        public EnemyPage()
        {
            gameObjects = new List<IGameObject>();
        }

        public void Update(GameTime time)
        {
            foreach (IEnemy enemy in gameObjects)
            {
                enemy.Update(time);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEnemy enemy in gameObjects)
            {
                enemy.Draw(spriteBatch);
            }
        }
        public void Stage(IEnemy enemy)
        {
            gameObjects.Add(enemy);
        }

        public void DeStage(IEnemy enemy)
        {
            gameObjects.Remove(enemy);
        }
    }
}
