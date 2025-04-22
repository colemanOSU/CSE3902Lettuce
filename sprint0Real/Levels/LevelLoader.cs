using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.EnemyStuff;
using sprint0Real.EnemyStuff.DragonStuff;
using System.Diagnostics;
using sprint0Real.EnemyStuff.RedGoriya;
using static Link;
using sprint0Real.CollisionBoxes;
using System.Runtime.Intrinsics.X86;

namespace sprint0Real.Levels
{
    public class LevelLoader
    {
        private Dictionary<String, EnemyPage> Maps = new Dictionary<String, EnemyPage>();
        private static LevelLoader instance = new LevelLoader();
        private TypeCatalogue catalogue = new TypeCatalogue();
        public IEnumerable<EnemyPage> AllMaps => Maps.Values;
        public static LevelLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadLevels()
        {
            String path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Levels", "Level Files");
            foreach (String fileName in Directory.GetFiles(path))
            {
                EnemyPage newMap = new EnemyPage();
                XmlDocument xml = new XmlDocument();
                xml.Load(fileName);

                string mapName = xml.SelectSingleNode("/LevelData/Name").InnerText;
                newMap.Name = mapName;

                foreach (XmlElement Object in xml.SelectNodes("//Objects/Object"))
                {
                    Type type = Type.GetType(catalogue.ReturnObjectType(Object.GetAttribute("Type")));
                    Debug.WriteLine(catalogue.ReturnObjectType(Object.GetAttribute("Type")));
                    int x = Int32.Parse(Object.GetAttribute("x")) + 96;
                    int y = Int32.Parse(Object.GetAttribute("y")) + 186 + 96;

                    if (Object.HasAttribute("Item"))
                    {
                        Type itemType = Type.GetType(catalogue.ReturnObjectType(Object.GetAttribute("Item")));
                        ITreasureItems item = (ITreasureItems)Activator.CreateInstance(itemType, new Vector2(x, y));
                        newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y), item));
                    }
                    bool movable = Object.HasAttribute("Movable") && bool.Parse(Object.GetAttribute("Movable"));
                    string direction = Object.HasAttribute("Direction") ? Object.GetAttribute("Direction") : "None";

                    try
                    {
                        newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y), movable, direction));
                    }
                    catch
                    {
                        //fallback if constructor doesn't take extra params
                        newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y)));
                    }
                }
                foreach(XmlElement MapHitBox in xml.SelectNodes("//MapHitBoxes/HitBox"))
                {
                    string boxType = MapHitBox.GetAttribute("Type");
                    Type type = Type.GetType(catalogue.ReturnObjectType(boxType));
                    int x = Int32.Parse(MapHitBox.GetAttribute("x"));
                    int y = Int32.Parse(MapHitBox.GetAttribute("y")) + 186;
                    int width = Int32.Parse(MapHitBox.GetAttribute("width"));
                    int height = Int32.Parse(MapHitBox.GetAttribute("height"));
                    if (boxType != "Border" && boxType != "HandSpawner" && boxType != "DungeonCollisionBox")
                    {
                        string direction = MapHitBox.GetAttribute("direction");
                        newMap.Stage((ITransitionBox)Activator.CreateInstance(type, new Rectangle(x, y, width, height), direction));
                    }
                    else
                    {
                        newMap.Stage((ICollisionBoxes)Activator.CreateInstance(type, new Rectangle(x, y, width, height)));
                    }
                }

                foreach(XmlElement Neighbor in xml.SelectNodes("//Neighbors/Neighbor"))
                {
                    newMap.AddNeighbor(Neighbor.GetAttribute("Side"), Neighbor.GetAttribute("Name"));
                }

                newMap.background.SetRoomExterior(xml.SelectSingleNode("/LevelData/Door").Attributes["Exterior"].Value);
                newMap.background.SetRoomInterior(xml.SelectSingleNode("/LevelData/Door").Attributes["Interior"].Value);
                newMap.background.SetLeftDoor(xml.SelectSingleNode("/LevelData/Door").Attributes["Left"].Value);
                newMap.background.SetRightDoor(xml.SelectSingleNode("/LevelData/Door").Attributes["Right"].Value);
                newMap.background.SetDownDoor(xml.SelectSingleNode("/LevelData/Door").Attributes["Down"].Value);
                newMap.background.SetUpDoor(xml.SelectSingleNode("/LevelData/Door").Attributes["Up"].Value);

                Maps.Add(xml.SelectSingleNode("/LevelData/Name").InnerText, newMap);
            }
            CurrentMap.Instance.SetMap(Maps["Entrance"]);
        }
        public EnemyPage RetrieveMap(String nextMap)
        {
            return Maps[nextMap];
        }

        public EnemyPage LoadFreshMap(string mapName)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Levels", "Level Files", mapName + ".xml");
            if (!File.Exists(path))
                throw new FileNotFoundException($"Level file not found: {path}");

            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            EnemyPage newMap = new EnemyPage();
            newMap.Name = mapName;

            foreach (XmlElement obj in xml.SelectNodes("//Objects/Object"))
            {
                Type type = Type.GetType(catalogue.ReturnObjectType(obj.GetAttribute("Type")));
                int x = int.Parse(obj.GetAttribute("x")) + 96;
                int y = int.Parse(obj.GetAttribute("y")) + 186 + 96;

                if (obj.HasAttribute("Item"))
                {
                    Type itemType = Type.GetType(catalogue.ReturnObjectType(obj.GetAttribute("Item")));
                    ITreasureItems item = (ITreasureItems)Activator.CreateInstance(itemType, new Vector2(x, y));
                    newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y), item));
                }
                bool movable = obj.HasAttribute("Movable") && bool.Parse(obj.GetAttribute("Movable"));
                string direction = obj.HasAttribute("Direction") ? obj.GetAttribute("Direction") : "None";

                try
                {
                    newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y), movable, direction));
                }
                catch
                {
                    //fallback if constructor doesn't take extra params
                    newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y)));
                }
            }

            foreach (XmlElement hitBox in xml.SelectNodes("//MapHitBoxes/HitBox"))
            {
                string boxType = hitBox.GetAttribute("Type");
                Type type = Type.GetType(catalogue.ReturnObjectType(boxType));
                int x = int.Parse(hitBox.GetAttribute("x"));
                int y = int.Parse(hitBox.GetAttribute("y")) + 186;
                int width = int.Parse(hitBox.GetAttribute("width"));
                int height = int.Parse(hitBox.GetAttribute("height"));

                if (boxType != "Border" && boxType != "HandSpawner" && boxType != "DungeonCollisionBox")
                {
                    string direction = hitBox.GetAttribute("direction");
                    newMap.Stage((ITransitionBox)Activator.CreateInstance(type, new Rectangle(x, y, width, height), direction));
                }
                else
                {
                    newMap.Stage((ICollisionBoxes)Activator.CreateInstance(type, new Rectangle(x, y, width, height)));
                }
            }

            foreach (XmlElement neighbor in xml.SelectNodes("//Neighbors/Neighbor"))
            {
                newMap.AddNeighbor(neighbor.GetAttribute("Side"), neighbor.GetAttribute("Name"));
            }

            var door = xml.SelectSingleNode("/LevelData/Door").Attributes;
            newMap.background.SetRoomExterior(door["Exterior"].Value);
            newMap.background.SetRoomInterior(door["Interior"].Value);
            newMap.background.SetLeftDoor(door["Left"].Value);
            newMap.background.SetRightDoor(door["Right"].Value);
            newMap.background.SetDownDoor(door["Down"].Value);
            newMap.background.SetUpDoor(door["Up"].Value);

            return newMap;
        }

        public void ReloadAllLevels()
        {
            Maps.Clear();

            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Levels", "Level Files");
            foreach (string fileName in Directory.GetFiles(path))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(fileName);

                string mapName = xml.SelectSingleNode("/LevelData/Name").InnerText;

                EnemyPage freshMap = LoadFreshMap(mapName);
                Maps[mapName] = freshMap;
            }
        }
    }
}
