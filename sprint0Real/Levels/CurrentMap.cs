using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;

namespace sprint0Real.Levels
{
    public class CurrentMap
    {
        // Functions as a singleton that holds the current stage, and as an interface between what should be added
        // to that stage.
        private EnemyPage previousMap;
        private static CurrentMap instance = new CurrentMap();
        private EnemyPage myMap;
        private List<IObject> stagingAdd;
        private List<IObject> stagingRemove; 
        public static CurrentMap Instance
        {
            get
            {
                return instance;
            }
        }
        private CurrentMap()
        { 
            stagingAdd = new List<IObject>();
            stagingRemove = new List<IObject>();
        }
        public void SetMap(EnemyPage newMap)
        {
            myMap = newMap;
            if(CurrentMap.Instance.MapName == "Level8" && previousMap.Name == "Level11")
            {
                CurrentMap.Instance.Stage(new Map(new Vector2(550, 425)));
            }
        }
        public void SetPrevious()
        {
            previousMap = myMap;
        }

        public List<IObject> ObjectList()
        {
            return myMap.ReturnObjectList();
        }

        public String GetNeighbor(String direction)
        {
            return myMap.GetNeighbor(direction);
        }

        public void Stage(IObject enemy)
        {
            stagingAdd.Add(enemy);
        }

        public void DeStage(IObject thing)
        {
            stagingRemove.Add(thing);
        }

        public void Update(GameTime gameTime)
        {
            myMap.Update(gameTime);
            foreach (IObject thing in stagingAdd)
            {
                myMap.Stage(thing);
            }
            stagingAdd.Clear();
            foreach (IObject thing in stagingRemove)
            {
                myMap.DeStage(thing);
            }
            stagingRemove.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myMap.Draw(spriteBatch);
        }

        // Draw blocks and the background. 
        public void DrawBackground(SpriteBatch spriteBatch, Vector2 offset)
        {
            myMap.DrawBackground(spriteBatch, offset);
        }
        // For level transitions
        public void DrawPreviousBackground(SpriteBatch spriteBatch)
        {
            previousMap.DrawBackground(spriteBatch);
        }
        public void SetDoor(String direction, String sprite)
        {
            if (direction == "Left")
            {
                myMap.background.SetLeftDoor(sprite);
            }
            else if (direction == "Right")
            {
                myMap.background.SetRightDoor(sprite);
            }
            else if (direction == "Up")
            {
                myMap.background.SetUpDoor(sprite);
            }
            else if (direction == "Down")
            {
                myMap.background.SetDownDoor(sprite);
            }
        }
        public string MapName => myMap?.Name;
    }
}
