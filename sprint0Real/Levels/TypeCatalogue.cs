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
            objectCatalogue.Add("Bat", "sprint0Real.EnemyStuff.BatStuff.Bat");
            objectCatalogue.Add("Skeleton", "sprint0Real.EnemyStuff.SkeletonStuff.Skeleton");
            objectCatalogue.Add("Slime", "sprint0Real.EnemyStuff.SlimeStuff.Slime");
            objectCatalogue.Add("Dino", "sprint0Real.EnemyStuff.DinoStuff.Dino");

            objectCatalogue.Add("BlackBlock", "sprint0Real.BlockSprites.BlockSpriteBlack");
            objectCatalogue.Add("NavyBlock", "sprint0Real.BlockSprites.BlockSpriteNavy");
            objectCatalogue.Add("BlockTile", "sprint0Real.BlockSprites.BlockSpriteFloorBlock");

            objectCatalogue.Add("Map", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Map");
            objectCatalogue.Add("ContainerHeart", "sprint0Real.TreasureItemStuff.TreasureItemSprites.ContainerHeart");
            objectCatalogue.Add("Rupee", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Rupee");
            objectCatalogue.Add("Fairy", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Fairy");
            objectCatalogue.Add("Heart", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Heart");
            objectCatalogue.Add("Key", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Key");
            objectCatalogue.Add("WhiteSword", "sprint0Real.TreasureItemStuff.TreasureItemSprites.WhiteSword");
            objectCatalogue.Add("Food", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Food");

            //all items
            objectCatalogue.Add("Arrow", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Arrow");
            objectCatalogue.Add("BlueCandle", "sprint0Real.TreasureItemStuff.TreasureItemSprites.BlueCandle");
            objectCatalogue.Add("BlueRing", "sprint0Real.TreasureItemStuff.TreasureItemSprites.BlueRing");
            objectCatalogue.Add("Bomb", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Bomb");
            objectCatalogue.Add("BookOfMagic", "sprint0Real.TreasureItemStuff.TreasureItemSprites.BookOfMagic");
            objectCatalogue.Add("Boomerang", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Boomerang");
            objectCatalogue.Add("Bow", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Bow");
            objectCatalogue.Add("Clock", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Clock");
            objectCatalogue.Add("Compass", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Compass");
            objectCatalogue.Add("FiveRupies", "sprint0Real.TreasureItemStuff.TreasureItemSprites.FiveRupies");
            objectCatalogue.Add("Letter", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Letter");
            objectCatalogue.Add("LifePotion", "sprint0Real.TreasureItemStuff.TreasureItemSprites.LifePotion");
            objectCatalogue.Add("MagicalBoomerang", "sprint0Real.TreasureItemStuff.TreasureItemSprites.MagicalBoomerang");
            objectCatalogue.Add("MagicalKey", "sprint0Real.TreasureItemStuff.TreasureItemSprites.MagicalKey");
            objectCatalogue.Add("MagicalRod", "sprint0Real.TreasureItemStuff.TreasureItemSprites.MagicalRod");
            objectCatalogue.Add("MagicalShield", "sprint0Real.TreasureItemStuff.TreasureItemSprites.MagicalShield");
            objectCatalogue.Add("MagicalSword", "sprint0Real.TreasureItemStuff.TreasureItemSprites.MagicalSword");
            objectCatalogue.Add("PowerBracelet", "sprint0Real.TreasureItemStuff.TreasureItemSprites.PowerBracelet");
            objectCatalogue.Add("Raft", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Raft");
            objectCatalogue.Add("Recorder", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Recorder");
            objectCatalogue.Add("RedCandle", "sprint0Real.TreasureItemStuff.TreasureItemSprites.RedCandle");
            objectCatalogue.Add("RedRing", "sprint0Real.TreasureItemStuff.TreasureItemSprites.RedRing");
            objectCatalogue.Add("SecondPotion", "sprint0Real.TreasureItemStuff.TreasureItemSprites.SecondPotion");
            objectCatalogue.Add("StepLadder", "sprint0Real.TreasureItemStuff.TreasureItemSprites.StepLadder");
            objectCatalogue.Add("Sword", "sprint0Real.TreasureItemStuff.TreasureItemSprites.Sword");

            objectCatalogue.Add("Border", "sprint0Real.CollisionBoxes.Border");
            objectCatalogue.Add("RoomTransitionBox", "sprint0Real.CollisionBoxes.RoomTransitionBox");
            objectCatalogue.Add("SealedTransitionBox", "sprint0Real.CollisionBoxes.SealedTransitionBox");
            objectCatalogue.Add("LockedTransitionBox", "sprint0Real.CollisionBoxes.LockedTransitionBox");

            objectCatalogue.Add("Oldman", "sprint0Real.NPCStuff.OldManSprite");
            objectCatalogue.Add("Fire", "sprint0Real.NPCStuff.FireSprite");
        }

        public String ReturnObjectType(String type)
        {
            return objectCatalogue[type];
        }
    }
}
