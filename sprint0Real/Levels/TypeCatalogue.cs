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
            objectCatalogue.Add("NavyBlock", "sprint0Real.BlockSprites.BlockSpriteNavy");
            objectCatalogue.Add("Map", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Map");
            objectCatalogue.Add("ContainerHeart", "sprint0Real.TreasureItemStuff.TreasureItemSprites.ContainerHeart");
            objectCatalogue.Add("Rupee", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Rupee");
            objectCatalogue.Add("Fairy", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Fairy");
            objectCatalogue.Add("Heart", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Heart");
            objectCatalogue.Add("Key", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Key");
            objectCatalogue.Add("WhiteSword", "sprint0Real.TreasureItemStuff.TreasureItemSprites.WhiteSword");
            objectCatalogue.Add("Food", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Food");
            objectCatalogue.Add("BlockTile", "sprint0Real.BlockSprites.BlockSpriteFloorBlock");
            
            objectCatalogue.Add("Bat", "sprint0Real.EnemyStuff.BatStuff.Bat");
            objectCatalogue.Add("Skeleton", "sprint0Real.EnemyStuff.SkeletonStuff.Skeleton");
            objectCatalogue.Add("Slime", "sprint0Real.EnemyStuff.SlimeStuff.Slime");

            objectCatalogue.Add("Border", "sprint0Real.CollisionBoxes.Border");
            objectCatalogue.Add("RoomTransitionBox", "sprint0Real.CollisionBoxes.RoomTransitionBox");
        }

        public String ReturnObjectType(String type)
        {
            return objectCatalogue[type];
        }
    }
}
