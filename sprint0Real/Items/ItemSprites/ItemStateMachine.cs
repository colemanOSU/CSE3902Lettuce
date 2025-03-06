using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using System.Collections;
using sprint0Real.Levels;

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
            Fire,
            MagicSword
        }
        private Item CurrentItem;
        private int index;
        private Game1 myGame;
        public ItemStateMachine(Game1 game)
        {
            myGame = game;
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
                case 0:
                    CurrentItem = Item.MagicSword;
                    break;
            }

        }
        public void DrawWeaponSprite()
        {
            
            switch (CurrentItem) {
                case Item.WoodSword:
                    myGame.weaponItems = new WoodSwordSprite(myGame.linkSheet, myGame);
                    break;
                case Item.Whitesword:
                    myGame.weaponItems = new WhiteSwordSprite(myGame.linkSheet, myGame);
                    break;
                case Item.MagicSword:
                    myGame.weaponItems = new MagicSword(myGame.linkSheet, myGame);
                        break;
                case Item.MagicRod:
                    myGame.weaponItems = new MagicRod(myGame.linkSheet, myGame);
                    break;
                case Item.WoodArrow:
                    myGame.weaponItems = new WoodArrow(myGame.linkSheet, myGame);
                    break;
                case Item.BlueArrow:
                    myGame.weaponItems = new BlueArrowSprite(myGame.linkSheet, myGame);
                    break;
                case Item.WoodBoomerang:
                    myGame.weaponItems = new WoodBoomerangSprite(myGame.linkSheet, myGame);
                    break;
                case Item.BlueBoomerang:
                    myGame.weaponItems = new BlueBoomerangSprite(myGame.linkSheet, myGame);
                    break;
                case Item.Bomb:
                    myGame.weaponItems = new BombSprite(myGame.linkSheet, myGame);
                    break;
                case Item.Fire:
                    myGame.weaponItems = new FireSprite(myGame.linkSheet, myGame);
                    break;  
            

            }
            
        }
    }
}
