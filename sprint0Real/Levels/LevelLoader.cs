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

namespace sprint0Real.Levels
{
    public class LevelLoader
    {
        private Dictionary<String, EnemyPage> Maps = new Dictionary<String, EnemyPage>();
        private static LevelLoader instance = new LevelLoader();
        private TypeCatalogue catalogue = new TypeCatalogue();
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
                foreach(XmlElement Object in xml.SelectNodes("//Objects/Object"))
                {
                    Type type = Type.GetType(catalogue.ReturnObjectType(Object.GetAttribute("Type")));
                    Debug.WriteLine(catalogue.ReturnObjectType(Object.GetAttribute("Type")));
                    int x = Int32.Parse(Object.GetAttribute("x"));
                    int y = Int32.Parse(Object.GetAttribute("y")) + 186;
                    newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y)));
                }
                foreach(XmlElement MapHitBox in xml.SelectNodes("//MapHitBoxes/HitBox"))
                {
                    string boxType = MapHitBox.GetAttribute("Type");
                    Type type = Type.GetType(catalogue.ReturnObjectType(boxType));
                    int x = Int32.Parse(MapHitBox.GetAttribute("x"));
                    int y = Int32.Parse(MapHitBox.GetAttribute("y")) + 186;
                    int width = Int32.Parse(MapHitBox.GetAttribute("width"));
                    int height = Int32.Parse(MapHitBox.GetAttribute("height"));
                    if (boxType == "RoomTransitionBox")
                    {
                        string direction = MapHitBox.GetAttribute("direction");
                        newMap.Stage((RoomTransitionBox)Activator.CreateInstance(type, new Rectangle(x, y, width, height), direction));
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
    }
}
