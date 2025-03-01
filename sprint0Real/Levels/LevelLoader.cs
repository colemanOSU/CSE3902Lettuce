using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using static System.Net.WebRequestMethods;

namespace sprint0Real.Levels
{
    public class LevelLoader
    {
        Dictionary<String, EnemyPage> Maps = new Dictionary<String, EnemyPage>();
        private static LevelLoader instance = new LevelLoader();
        public static LevelLoader Instance
        {
            get
            {
                return instance;
            }
        }

        void LoadLevels()
        {
            foreach (String fileName in Directory.GetFiles("C: \\Users\\icebe\\Source\\Repos\\CSE3902Lettuce\\sprint0Real\\Levels\\Level Files\\"))
            {
                EnemyPage newMap = new EnemyPage();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(fileName);
                foreach(XmlElement Object in xml.SelectNodes("Objects"))
                {
                    Type type = Type.GetType(Object.GetAttribute("Type"));
                    int x = Int32.Parse(Object.GetAttribute("x"));
                    int y = Int32.Parse(Object.GetAttribute("y"));
                    newMap.Stage((IGameObject)Activator.CreateInstance(type, new Vector2(x, y)));
                }
                foreach(XmlElement MapHitBox in xml.SelectNodes("MapHitBoxes"))
                {
                    Type type = Type.GetType(MapHitBox.GetAttribute("Type"));
                    int x = Int32.Parse(MapHitBox.GetAttribute("x"));
                    int y = Int32.Parse(MapHitBox.GetAttribute("y"));
                    int width = Int32.Parse(MapHitBox.GetAttribute("width"));
                    int height = Int32.Parse(MapHitBox.GetAttribute("height"));
                    newMap.AddCollisionBox((ICollisionBoxes)Activator.CreateInstance(type, new Rectangle(x, y, width, height)));
                }

                foreach(XmlElement Neighbor in xml.SelectNodes("Neighbors"))
                {
                    newMap.AddNeighbor(Neighbor.GetAttribute("Side"), Neighbor.GetAttribute("Name"));
                }
                Maps.Add(xml.GetElementById("Name").GetAttribute("Name"), newMap);
            }
            CurrentMap.Instance.SetMap(Maps["Entrance"]);
        }
    }
}
