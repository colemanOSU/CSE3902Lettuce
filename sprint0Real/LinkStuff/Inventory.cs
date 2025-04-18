using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Audio;
using sprint0Real.GameState.NameRegistrationandAchievements;
using sprint0Real.WolfLink;

namespace sprint0Real.LinkStuff
{
    public class Inventory
    {
        //That is the question:
        //Whether tis nobler in the mind to suffer the slings and arrows of outrageous fortune,
        //Or to take arms against a sea of troubles, And by opposing end them

        private Dictionary<Items, Boolean> InventoryList = [];
        private static Inventory instance = new Inventory();
        public static Inventory Instance { get { return instance; } }
        //Keeps track of currently equipped item.
        //Starts as set to null.
        public Items CurrentItem { get; set; }
        public Swords CurrentSword { get; set; }

        public int KeyCount { get; private set; }

        public int RupeeCount { get; set; }

        public int BombCount { get; set; }

        //Original game has ability to increase max bombs
        //Hell if we're implementing that though
        private const int MAXBOMBS = 12;

        private const int MAXRUPEES = 99;

        public enum Swords
        {
            Wood_Sword,
            White_Sword,
            Magic_Sword
        }
        public enum Items
        {
            NONE,
            Boomerang,
            M_Boomerang,
            Bomb,
            Arrow,
            Silver_Arrow,
            Blue_Candle,
            Red_Candle,
            Flute,
            Meat,
            Note,
            Blue_Potion,
            Red_Potion,
            WolfBubble,
            Staff
        }

        public bool HasMap { get; set; }

        public bool HasCompass { get; set; }

        public Inventory()
        {
            //All items set to true by default for testing
            foreach (Items item in Enum.GetValues(typeof(Items)))
            {
                InventoryList.Add(item, false);
            }
            HasMap = false;
            HasCompass = false;
            CurrentItem = Items.NONE;
            CurrentSword = Swords.Wood_Sword;
            KeyCount = 0;
            RupeeCount = 0;

            //We'll give 'em some bombs to play with.
            PickUpBomb();
        }

        //Marks item as accessible within inventory
        //No need to have functionality to remove items
        public void ObtainItem(Items item)
        {
            InventoryList.Remove(item);
            InventoryList.Add(item, true);
        }

        //Checks if item is accesible within inventory
        public bool HasItem(Items item)
        {
            return InventoryList.GetValueOrDefault(item);
        }

        public void KeyGet()
        {
            KeyCount++;

            var save = SaveManager.GetSave(Game1.Instance.CurrentPlayerName);
            if (save == null) return;

            if (save.KeyCollectCount < 5)
            {
                save.KeyCollectCount++;
            }

            if (save.KeyCollectCount >= 5)
            {
                AchievementManager.Unlock("Key Collector!");
            }

            SaveManager.Save();
        }

        public void KeyUse()
        {
            SoundEffectFactory.Instance.Play(SoundEffectType.doorUnlock);

            if (KeyCount <= 0)
            {
                throw new NotImplementedException();
            }
            KeyCount--;
        }

        public void PickUpBomb()
        {
            BombCount += 4;
            if (BombCount > MAXBOMBS) BombCount = MAXBOMBS;
            if (!HasItem(Items.Bomb))
            {
                ObtainItem(Items.Bomb);
            }
        }

        public void BombUse()
        {
            BombCount--;
            //Just for insurance
            if (BombCount < 0) BombCount = 0;
        }

        public void PickUpRupee(int amount)
        {
            RupeeCount += amount;
            if (RupeeCount > MAXRUPEES) RupeeCount = MAXRUPEES;
        }

        public void RupeeUse(int amount)
        {
            RupeeCount -= amount;
            if (RupeeCount < 0) RupeeCount = 0;
        }
    }
}
