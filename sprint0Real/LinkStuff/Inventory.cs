using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.LinkStuff
{
    public class Inventory
    {
        //That is the question:
        //Whether tis nobler in the mind to suffer the slings and arrows of outrageous fortune,
        //Or to take arms against a sea of troubles, And by opposing end them

        private Dictionary<Items, Boolean> InventoryList = [];

        //Keeps track of currently equipped item.
        //Starts as set to null.
        public Items CurrentItem { get; set; }
        public Swords CurrentSword { get; set; }

        public int KeyCount { get; private set; }

        public int RupeeCount { get; set; }

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
            Staff
        }

        public Inventory()
        {
            //All items set to true by default for testing
            foreach (Items item in Enum.GetValues(typeof(Items)))
            {
                InventoryList.Add(item, true);
            }
            ObtainItem(Items.Boomerang);
            CurrentItem = Items.Boomerang;
            CurrentSword = Swords.Wood_Sword;
            KeyCount = 0;
            RupeeCount = 0;
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
        }

        public void KeyUse()
        {
            if (KeyCount <= 0)
            {
                throw new NotImplementedException();
            }
            KeyCount--;
        }
    }
}
