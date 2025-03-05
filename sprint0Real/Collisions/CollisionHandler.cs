using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Diagnostics;

namespace sprint0Real.Collisions
{
    public class CollisionHandler
    {
        private CollisionCommandLoader commandLoader;

        public CollisionHandler(string xmlPath)
        {
            commandLoader = new CollisionCommandLoader(xmlPath);
        }

        public void HandleCollision(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {
            var key = (objA.GetType().Name, objB.GetType().Name, direction);

            ICollisionCommand command = commandLoader.GetCommand(objA.GetType().Name, objB.GetType().Name, direction);
            if (command != null)
            {
                command.Execute(objA, objB, direction);
            }
        }
    }
}