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
        private int index;
        public ItemStateMachine()
        {
            CurrentItem = Item.WoodSword;
            index = 0;
        }
        public void nextItem()
        {
            if (index == 8)
            {
                index = 0;
            }
            else
            {
                index += 1;
            }
            CurrentItem = (Item)index;
        }
        public void lastItem()
        {
            if (index == 0)
            {
                index = 8;
            }
            else
            {
                index -= 1;
            }
            CurrentItem = (Item)index;
        }
        public void SetItem(int num)
        {
            switch (num)
            {
                case 1:
                    CurrentItem = Item.WoodSword;
                    break;
                case 2:
                    CurrentItem = Item.Whitesword;
                    break;
                case 3:
                    CurrentItem = Item.MagicRod;
                    break;
                case 4:
                    CurrentItem = Item.WoodArrow;
                    break;
                case 5:
                    CurrentItem = Item.BlueArrow;
                    break
            ;   case 6:
                    CurrentItem = Item.WoodBoomerang;
                    break;
                case 7:
                    CurrentItem = Item.BlueBoomerang;
                    break;
                case 8:
                    CurrentItem = Item.Bomb;
                    break;
                case 9:
                    CurrentItem = Item.Fire;
                    break;
            }
        }
    }
}
