using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;

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
        private Game1 myGame;
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
        public void SetItem(int num,Game1 game)
        {
            myGame = game;
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
        public void DrawWeaponSprite()
        {
            if (CurrentItem.Equals(Item.Whitesword))
            {
                myGame.weaponItems = new WhiteSwordSprite(myGame.linkSheet, myGame);
            }
        }
    }
}
