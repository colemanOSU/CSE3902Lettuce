using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using System.Collections;
using sprint0Real.Levels;
using System;
using sprint0Real.TreasureItemSprites;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.BlockSprites;

namespace sprint0Real.LinkSprites
{

    //This class is passed an item and the Link object and determines the correct sprite
    //to play based on the properties of both
    public class ItemStateMachine
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
        private ContentManager content;
        private SoundEffect soundEffect;
        public ItemStateMachine(Game1 game)
        {
            myGame = game;
            CurrentItem = Item.WoodSword;
            index = 0;
            this.content = game.Content;
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
        public void setActive()
        {
            if (myGame.weaponItems is NullSprite)
            {
                myGame.weaponItems.Disable();
            }
            else
            {
                myGame.weaponItems.Activate();
            }
        }

        public void DrawWeaponSprite()
        {
            CurrentMap.Instance.ObjectList().RemoveAll(obj => obj is ILinkSprite && obj != myGame.weaponItems);
            if (myGame.weaponItems != null && myGame.weaponItems.GetType() == GetWeaponType(CurrentItem))
            {
                return; 
            }

            if (myGame.weaponItems != null && !(myGame.weaponItems is NullSprite))
            {
                CurrentMap.Instance.ObjectList().Remove(myGame.weaponItems);
                Debug.WriteLine($"Removed old weapon: {myGame.weaponItems.GetType().Name}");
            }

            ILinkSprite newWeapon = CreateWeaponInstance(CurrentItem);

            if (newWeapon != null)
            {
                myGame.weaponItems = newWeapon;

                if (!CurrentMap.Instance.ObjectList().Contains(myGame.weaponItems))
                {
                    CurrentMap.Instance.ObjectList().Add(myGame.weaponItems);
                    Debug.WriteLine($"Added new weapon: {myGame.weaponItems.GetType().Name}");
                }
            }
        }



        private Type GetWeaponType(Item item)
        {
            return item switch
            {
                Item.WoodSword => typeof(WoodSwordSprite),
                Item.Whitesword => typeof(WhiteSwordSprite),
                Item.MagicRod => typeof(MagicRod),
                Item.WoodArrow => typeof(WoodArrow),
                Item.BlueArrow => typeof(BlueArrowSprite),
                Item.WoodBoomerang => typeof(WoodBoomerangSprite),
                Item.BlueBoomerang => typeof(BlueBoomerangSprite),
                Item.Bomb => typeof(BombSprite),
                Item.Fire => typeof(FireSprite),
                _ => typeof(NullSprite),
            };
        }

   
        private ILinkSprite CreateWeaponInstance(Item item)
        {
            return item switch
            {
                Item.WoodSword => new WoodSwordSprite(myGame.linkSheet,myGame),
                Item.Whitesword => new WhiteSwordSprite(myGame.linkSheet, myGame),
                Item.MagicRod => new MagicRod(myGame.linkSheet, myGame),
                Item.WoodArrow => new WoodArrow(myGame.linkSheet, myGame),
                Item.BlueArrow => new BlueArrowSprite(myGame.linkSheet, myGame),
                Item.WoodBoomerang => new WoodBoomerangSprite(myGame.linkSheet, myGame),
                Item.BlueBoomerang => new BlueBoomerangSprite(myGame.linkSheet, myGame),
                Item.Bomb => new BombSprite(myGame.linkSheet, myGame),
                Item.Fire => new FireSprite(myGame.linkSheet, myGame),
                _ => new NullSprite(myGame.linkSheet, myGame),
            };
        }

    }
}
