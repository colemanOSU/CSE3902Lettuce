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
        private List<IObject> gameObjects;
        private Dictionary<String, String> Neighbors;
        public LevelBackground background;

        public EnemyPage()
        {
            gameObjects = new List<IObject>();
            background = new LevelBackground();
            Neighbors = new Dictionary<string, string>();
        }
        public string Name { get; set; }
        public List<IObject> ReturnObjectList()
        {
            return gameObjects;
        }
        public void Update(GameTime time)
        {
            foreach (IUpdates updatable in gameObjects.OfType<IUpdates>())
            {
                updatable.Update(time);
            }
        }
        public void AddNeighbor(String side, String name)
        {
            Neighbors.Add(side, name);
        }

        public String GetNeighbor(String direction)
        {
            return Neighbors.ContainsKey(direction) ? Neighbors[direction] : null;
        }
        public void DrawBackground(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            foreach (IBlock block in gameObjects.OfType<IBlock>())
            {
                block.Draw(spriteBatch);
            }
        }
        // For level transitions
        public void DrawBackground(SpriteBatch spriteBatch, Vector2 offset)
        {
            background.Draw(spriteBatch, offset);
            foreach (IBlock block in gameObjects.OfType<IBlock>())
            {
                // This is a hack to get blocks to show up during level transitions
                Type type = Type.GetType(block.GetType().ToString());
                IBlock temp = (IBlock)Activator.CreateInstance(type, block.Position + offset);
                temp.Draw(spriteBatch);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            foreach (IDrawn gameObject in gameObjects.OfType<IDrawn>())
            {
                gameObject.Draw(spriteBatch);
            }
        }
        public void Stage(IObject thing)
        {
            gameObjects.Add(thing);
        }
        public void DeStage(IObject thing)
        {
            gameObjects.Remove(thing);
        }
    }
}
