using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.TreasureItemStuff
{
    public class DropItem
    {
        public string ItemType { get; set; }
        public int Weight { get; set; }

        public DropItem(string itemType, int weight)
        {
            ItemType = itemType;
            Weight = weight;
        }
    }
}
