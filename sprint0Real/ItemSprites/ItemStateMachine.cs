using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;

namespace sprint0Real.LinkSprites
{

    //This class is passed an item and the Link object and determines the correct sprite
    //to play based on the properties of both
    internal class ItemStateMachine
    {
        public enum Item
        {
            WoodSword,
            Whitesword,
            MagicRod,
            WoodArrow,
            BlueArrow,
            WoodBoomerang,
            BlueBoomerang,
            Bomb,
            Fire

        }
        private Item CurrentItem;
        public ItemStateMachine()
        {
            CurrentItem = Item.WoodSword;
        }
        public void SetItem()
        {

        }
    }
}
