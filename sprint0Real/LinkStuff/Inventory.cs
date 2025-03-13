using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.LinkStuff
{
    class Inventory
    {
        //That is the question:
        //Whether tis nobler in the mind to suffer the slings and arrows of outrageous fortune,
        //Or to take arms against a sea of troubles, And by opposing end them

        private Dictionary<Items, Boolean> InventoryList;
        public Items? CurrentItem { get; set; }
        public enum Items
        {
            Boomerang,
            M_Boomerang,
            Bomb,
            Bow,
            Candle,
            Flute,
            Meat,
            Potion,
            Staff
        }

        public Inventory()
        {
            foreach (Items item in Enum.GetValues(typeof(Items)))
            {
                InventoryList.Add(item, false);
            }
            CurrentItem = null;
        }

        public void ObtainItem(Items item)
        {
            InventoryList.Remove(item);
            InventoryList.Add(item, true);
        }

        public bool HasItem(Items item)
        {
            return InventoryList.GetValueOrDefault(item);
        }
        
        
    }
}
