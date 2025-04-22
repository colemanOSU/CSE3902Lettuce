using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.LinkStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.TreasureItemStuff
{
    public class DropManager
    {
        private static DropManager instance;
        private static readonly object padlock = new object();

        private ILink link;
        private Inventory inv;
        
        private static Random rng = new Random();

        private DropManager(ILink link)
        {
            this.link = link;
            inv = link.GetInventory();
        }

        public static void Init(ILink link)
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new DropManager(link);
                }
            }
        }

        public static DropManager Instance
        {
            get
            {
                if (instance == null)
                    throw new Exception();
                return instance;
            }
        }
        public static string GetRandomDrop(bool hasBombs, bool lowHealth)
        {
            List<DropItem> dropTable = new List<DropItem>
            {
            new DropItem("Rupee", 40),
            new DropItem("Heart", lowHealth ? 30 : 10),
            new DropItem("Bomb", hasBombs ? 3 : 0),
            new DropItem("FiveRupies", 10),
            new DropItem("Fairy", lowHealth ? 6 : 2),
            new DropItem("Clock", 3)
            };

            //Filter out zero-weight entries
            var validDrops = dropTable.Where(d => d.Weight > 0).ToList();
            int totalWeight = validDrops.Sum(d => d.Weight);

            int roll = rng.Next(0, totalWeight);
            int cumulative = 0;

            foreach (var drop in validDrops)
            {
                cumulative += drop.Weight;
                if (roll < cumulative)
                    return drop.ItemType;
            }

            return null;
        }

        public void OnDeath(Vector2 position)
        {
            bool hasBombs = inv.BombCount > 0;
            bool lowHealth = link.GetCurrentHealth() < link.GetMaxHealth();

            if (RandomChance(0.7))
            {
                string dropType = GetRandomDrop(hasBombs, lowHealth);
                if (!string.IsNullOrEmpty(dropType))
                {
                    ITreasureItems item = TreasureItemSpriteFactory.CreateItem(dropType, position);
                    item.Spawn();
                }
            }
        }

        private bool RandomChance(double chance)
        {
            return rng.NextDouble() < chance;
        }
    }
}
