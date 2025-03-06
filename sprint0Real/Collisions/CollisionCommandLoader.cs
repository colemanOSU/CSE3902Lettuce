using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using sprint0Real.Interfaces;
using System.IO;
using sprint0Real.LinkStuff;

namespace sprint0Real.Collisions
{
    public class CollisionCommandLoader
    {
        private Dictionary<(string, string, CollisionDirections), ICollisionCommand> collisionResponses;
        private string xmlFilePath;
        private LinkStateMachine linkStateMachine;

        public CollisionCommandLoader(string xmlPath)
        {
            xmlFilePath = xmlPath;
            collisionResponses = new Dictionary<(string, string, CollisionDirections), ICollisionCommand>();
            LoadCommandsFromXml();
        }

        public ICollisionCommand GetCommand(string objectA, string objectB, CollisionDirections direction)
        {
            var key = (objectA, objectB, direction);
            if (collisionResponses.TryGetValue(key, out ICollisionCommand command))
            {
                return command;
            }
            return null;
        }

        private void LoadCommandsFromXml()
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList collisionNodes = xmlDoc.SelectNodes("/CollisionCommands/Collision");

            foreach (XmlNode node in collisionNodes)
            {
                string objectA = node["ObjectA"].InnerText.Trim();
                string objectB = node["ObjectB"].InnerText.Trim();
                CollisionDirections direction = Enum.Parse<CollisionDirections>(node["Direction"].InnerText.Trim());
                string commandName = node["Command"].InnerText.Trim();

                ICollisionCommand commandInstance = CreateCommandInstance(commandName);
                if (commandInstance != null)
                {
                    var key = (objectA, objectB, direction);
                    collisionResponses[key] = commandInstance;
                }
            }
        }

        private ICollisionCommand CreateCommandInstance(string commandName)
        {
            Type commandType = Assembly.GetExecutingAssembly().GetType(commandName);

            if (commandType == null)
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    commandType = asm.GetType(commandName);
                    if (commandType != null) break;
                }
            }

            if (commandType != null && typeof(ICollisionCommand).IsAssignableFrom(commandType))
            {
                return (ICollisionCommand)Activator.CreateInstance(commandType);
            }

            return null;
        }
    }
}
