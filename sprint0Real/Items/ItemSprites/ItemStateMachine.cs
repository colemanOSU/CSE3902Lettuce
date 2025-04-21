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
        }
        public void SetItem(int num, Game1 game)
        {

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
            if (myGame.weaponItemsB is FireSprite fire && fire.IsActive)
            {
                return;
            }
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
            
            if (item is FireSprite)
            {
                if (currentItem == Inventory.Items.Blue_Candle)
                {
                    myGame.Link.GetInventory().blueCandleUsedThisRoom = true;
                }
                timeSinceLastUse = 0;
            }

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
            switch (item)
            {
                case Inventory.Items.Red_Candle:
                    return new FireSprite(myGame.linkSheet, myGame);

                case Inventory.Items.Blue_Candle:
                    if (!myGame.Link.GetInventory().blueCandleUsedThisRoom)
                    {
                        return new FireSprite(myGame.linkSheet, myGame);
                    }
                    return new NullSprite(myGame.linkSheet, myGame);

                // Other items
                case Inventory.Items.Arrow:
                    return new WoodArrow(myGame.linkSheet, myGame);
                case Inventory.Items.Silver_Arrow:
                    return new BlueArrowSprite(myGame.linkSheet, myGame);
                case Inventory.Items.Boomerang:
                    return new WoodBoomerangSprite(myGame.linkSheet, myGame);
                case Inventory.Items.M_Boomerang:
                    return new BlueBoomerangSprite(myGame.linkSheet, myGame);
                case Inventory.Items.Bomb:
                    return new BombSprite(myGame.linkSheet, myGame);

                default:
                    return new NullSprite(myGame.linkSheet, myGame);
            }
        }

    }
}
