using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using System.Collections;
using sprint0Real.Levels;
using System;
using sprint0Real.TreasureItemSprites;
using System.Diagnostics;
using sprint0Real.LinkStuff;
using static sprint0Real.LinkStuff.Inventory;

namespace sprint0Real.LinkSprites
{

    //This class is passed an item and the Link object and determines the correct sprite
    //to play based on the properties of both
    internal class ItemStateMachine
    {
        /*
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
        */
        private Inventory inventory;
        private Inventory.Items currentItem;
        private Inventory.Swords currentSwords;
        private int index;
        private Game1 myGame;
        public ItemStateMachine(Game1 game, Inventory inv)
        {
            myGame = game;
            index = 0;
            inventory = inv;
            currentItem = inventory.CurrentItem;
            currentSwords = inventory.CurrentSword;
        }
        public void UpdateEquippedItems()
        {
            currentItem = inventory.CurrentItem;
            currentSwords = inventory.CurrentSword;
            //System.Diagnostics.Debug.WriteLine($"Updated currentItem: {currentItem}");
        }
        public void SetItem(int num,Game1 game)
        {
            /*
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
            */

        }
        public void setActive()
        {
            if (myGame.weaponItemsA is NullSprite)
            {
                myGame.weaponItemsA.Disable();
            }
            else
            {
                myGame.weaponItemsA.Activate();
            }
            if (myGame.weaponItemsB is NullSprite)
            {
                myGame.weaponItemsB.Disable();
            }
            else
            {
                myGame.weaponItemsB.Activate();
            }
        }

        public void DrawWeaponSprite()
        {
            CurrentMap.Instance.ObjectList().RemoveAll(obj => obj is ILinkSprite && obj != myGame.weaponItemsA);
            CurrentMap.Instance.ObjectList().RemoveAll(obj => obj is ILinkSprite && obj != myGame.weaponItemsB);
            /*if (myGame.weaponItems != null && myGame.weaponItems.GetType() == GetWeaponType(currentSwords))
            {
                return; 
            }*/

            if (myGame.weaponItemsA != null && !(myGame.weaponItemsA is NullSprite))
            {
                CurrentMap.Instance.ObjectList().Remove(myGame.weaponItemsA);
                Debug.WriteLine($"Removed old weapon: {myGame.weaponItemsA.GetType().Name}");
            }
            

            ILinkSprite newWeapon = CreateWeaponInstance(currentSwords);

            if (newWeapon != null)
            {
                myGame.weaponItemsA = newWeapon;

                if (!CurrentMap.Instance.ObjectList().Contains(myGame.weaponItemsA))
                {
                    CurrentMap.Instance.ObjectList().Add(myGame.weaponItemsA);
                    Debug.WriteLine($"Added new weapon: {myGame.weaponItemsA.GetType().Name}");
                }
            }
        }
        public void DrawItemSprite()
        {
            CurrentMap.Instance.ObjectList().RemoveAll(obj => obj is ILinkSprite && obj != myGame.weaponItemsA);

            CurrentMap.Instance.ObjectList().RemoveAll(obj => obj is ILinkSprite && obj != myGame.weaponItemsB);
            if (myGame.weaponItemsB != null && !(myGame.weaponItemsB is NullSprite))
            {
                CurrentMap.Instance.ObjectList().Remove(myGame.weaponItemsB);
                Debug.WriteLine($"Removed old weapon: {myGame.weaponItemsB.GetType().Name}");
            }

            ILinkSprite newItem = CreateItemInstance(currentItem);
            if (newItem != null)
            {
                myGame.weaponItemsB = newItem;

              if (!CurrentMap.Instance.ObjectList().Contains(myGame.weaponItemsB))
                {
                    CurrentMap.Instance.ObjectList().Add(myGame.weaponItemsB);
                    Debug.WriteLine($"Added new weapon: {myGame.weaponItemsB.GetType().Name}");
                }
            }
        }
                  
   
        private ILinkSprite CreateWeaponInstance(Inventory.Swords sword)
        {
            return sword switch
            {
                Inventory.Swords.Wood_Sword => new WoodSwordSprite(myGame.linkSheet,myGame),
                Inventory.Swords.White_Sword => new WhiteSwordSprite(myGame.linkSheet, myGame),
                _ => new NullSprite(myGame.linkSheet, myGame),
            };
        }
        private ILinkSprite CreateItemInstance(Inventory.Items item)
        {
            return item switch
            {
                //Inventory.Items.MagicRod => new MagicRod(myGame.linkSheet, myGame),
                Inventory.Items.Arrow => new WoodArrow(myGame.linkSheet, myGame),
                Inventory.Items.Silver_Arrow => new BlueArrowSprite(myGame.linkSheet, myGame),
                Inventory.Items.Boomerang => new WoodBoomerangSprite(myGame.linkSheet, myGame),
                Inventory.Items.M_Boomerang => new BlueBoomerangSprite(myGame.linkSheet, myGame),
                Inventory.Items.Bomb => new BombSprite(myGame.linkSheet, myGame),
                // Inventory.Items.Fire => new FireSprite(myGame.linkSheet, myGame),
                _ => new NullSprite(myGame.linkSheet, myGame),
            };
        }

    }
}
