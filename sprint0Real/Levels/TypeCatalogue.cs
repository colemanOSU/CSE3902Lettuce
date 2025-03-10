using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.Levels
{
    public class TypeCatalogue
    {
        private Dictionary<String, String> gameObjectCatalogue;
        private Dictionary<String, String> collisionBoxCatalogue;
        public TypeCatalogue()
        {
            gameObjectCatalogue = new Dictionary<String, String>();
            collisionBoxCatalogue = new Dictionary<String, String>();

            gameObjectCatalogue.Add("Dragon", "sprint0Real.EnemyStuff.DragonStuff.Dragon");
            gameObjectCatalogue.Add("BlackBlock", "sprint0Real.BlockSprites.BlockSpriteBlack");
            gameObjectCatalogue.Add("Map", "sprint0Real.ItemTempSprites.Map");

            collisionBoxCatalogue.Add("Border", "sprint0Real.CollisionBoxes.RoomBorderBox");
        }

        public String ReturnGameObjectType(String type)
        {
            return gameObjectCatalogue[type];
        }

        public String ReturnCollisionBoxCatalogue(String type)
        {
            return collisionBoxCatalogue[type];
        }
    }
}
