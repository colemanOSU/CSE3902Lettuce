using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.EnemyStuff.RedGoriya;
using sprint0Real.Interfaces;

namespace sprint0Real.Levels
{
    public class TypeCatalogue
    {
        private Dictionary<String, String> objectCatalogue;
        public TypeCatalogue()
        {
            objectCatalogue = new Dictionary<String, String>();

            objectCatalogue.Add("Dragon", "sprint0Real.EnemyStuff.DragonStuff.Dragon");
            objectCatalogue.Add("Goriya", "sprint0Real.EnemyStuff.RedGoriya.Goriya");
            objectCatalogue.Add("BlackBlock", "sprint0Real.BlockSprites.BlockSpriteBlack");
            objectCatalogue.Add("Map", "sprint0Real.ItemTempSprites.Map");

            objectCatalogue.Add("Border", "sprint0Real.CollisionBoxes.Border");
            objectCatalogue.Add("RoomTransitionBox", "sprint0Real.CollisionBoxes.RoomTransitionBox");
        }

        public String ReturnObjectType(String type)
        {
            return objectCatalogue[type];
        }
    }
}
