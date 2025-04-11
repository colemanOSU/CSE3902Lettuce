using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using System.Collections;
using sprint0Real.Levels;
using System;
using sprint0Real.TreasureItemStuff;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;
using System.Diagnostics;
using sprint0Real.LinkStuff;
using static sprint0Real.LinkStuff.Inventory;

namespace sprint0Real.LinkSprites
{

    //This class is passed an item and the Link object and determines the correct sprite
    //to play based on the properties of both
    public class ItemStateMachine
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
        private int bombCount;
        private int index;
        private Game1 myGame;
        private double itemUseCooldown = 100; 
        private double timeSinceLastUse = 0;
        private bool isNoItem = false;
        public ItemStateMachine(Game1 game, Inventory inv)
        {
            myGame = game;
            index = 0;
            inventory = inv;
            currentItem = inventory.CurrentItem;
            currentSwords = inventory.CurrentSword;
            bombCount = inventory.BombCount;
        }
        public void UpdateEquippedItems(GameTime gameTime)
        {
            timeSinceLastUse += gameTime.ElapsedGameTime.TotalMilliseconds;
            currentItem = inventory.CurrentItem;
            currentSwords = inventory.CurrentSword;
            bombCount = inventory.BombCount;

            //System.Diagnostics.Debug.WriteLine($"Updated currentItem: {currentItem}");
        }
        public void SetItem(int num, Game1 game)
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
            if (myGame.weaponItemsA != null && !(myGame.weaponItemsA is NullSprite))
            {
                CurrentMap.Instance.ObjectList().Remove(myGame.weaponItemsA);
            }


            ILinkSprite newWeapon = CreateWeaponInstance(currentSwords);

            if (newWeapon != null)
            {
                myGame.weaponItemsA = newWeapon;

                if (!CurrentMap.Instance.ObjectList().Contains(myGame.weaponItemsA))
                {
                    CurrentMap.Instance.ObjectList().Add(myGame.weaponItemsA);
                }
            }
        }
        public void DrawItemSprite()
        {
            if (isNoItem && currentItem == Inventory.Items.Bomb) return;
            CurrentMap.Instance.ObjectList().RemoveAll(obj => obj is ILinkSprite && obj != myGame.weaponItemsA);
            CurrentMap.Instance.ObjectList().RemoveAll(obj => obj is ILinkSprite && obj != myGame.weaponItemsB);
            if (myGame.weaponItemsB != null && !(myGame.weaponItemsB is NullSprite))
            {
                CurrentMap.Instance.ObjectList().Remove(myGame.weaponItemsB);
            }

            ILinkSprite newItem = TryUseItem(currentItem);

            if (newItem != null)
            {
                myGame.weaponItemsB = newItem;

                if (!CurrentMap.Instance.ObjectList().Contains(myGame.weaponItemsB))
                {
                    CurrentMap.Instance.ObjectList().Add(myGame.weaponItemsB);
                }
            }
        }
        public ILinkSprite TryUseItem(Inventory.Items currentItem)
        {
            
            UpdateEquippedItems(new GameTime()); 

            ILinkSprite item = CreateItemInstance(currentItem);

            if (currentItem == Inventory.Items.Bomb)
            {
                if (inventory.BombCount > 0 && timeSinceLastUse >= itemUseCooldown)
                {
                    isNoItem = false;
                    inventory.BombUse();
                    timeSinceLastUse = 0;
                    Debug.WriteLine($"Bomb used!");
                }
                else if (inventory.BombCount <= 0)
                {
                    Debug.WriteLine($"No bombs left!");
                    isNoItem = true;
                }
            }
            else
            {
                if (timeSinceLastUse >= itemUseCooldown)
                {
                    timeSinceLastUse = 0;
                }
            }
            return item;
        }

        private ILinkSprite CreateWeaponInstance(Inventory.Swords sword)
        {
            return sword switch
            {
                Inventory.Swords.Wood_Sword => new WoodSwordSprite(myGame.linkSheet, myGame),
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
