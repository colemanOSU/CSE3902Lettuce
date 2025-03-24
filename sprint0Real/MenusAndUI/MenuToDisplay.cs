using sprint0Real.LinkStuff;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.MenusAndUI
{
    static public class MenuToDisplay
    {
        
        static public Inventory.Items[,] MenuRealizer(Inventory inv)
        {
            Inventory.Items[,] Menu = new Inventory.Items[2, 4];

            if (inv.HasItem(Inventory.Items.M_Boomerang))
            {
                Menu[0, 0] = Inventory.Items.M_Boomerang;
                
            }
            else if (inv.HasItem(Inventory.Items.Boomerang))
            {
                Menu[0, 0] = Inventory.Items.Boomerang;
            }

            if (inv.HasItem(Inventory.Items.Bomb))
            {
                Menu[0, 1] = Inventory.Items.Bomb;
            }

            if (inv.HasItem(Inventory.Items.Silver_Arrow))
            {
                Menu[0, 2] = Inventory.Items.Silver_Arrow;
            }
            else if (inv.HasItem(Inventory.Items.Arrow))
            {
                Menu[0, 2] = Inventory.Items.Arrow;
            }

            if (inv.HasItem(Inventory.Items.Red_Candle))
            {
                Menu[0, 3] = Inventory.Items.Red_Candle;
            }
            else if (inv.HasItem(Inventory.Items.Blue_Candle))
            {
                Menu[0, 3] = Inventory.Items.Blue_Candle;
            }

            if (inv.HasItem(Inventory.Items.Flute))
            {
                Menu[1, 0] = Inventory.Items.Flute;
            }

            if (inv.HasItem(Inventory.Items.Meat))
            {
                Menu[1, 1] = Inventory.Items.Meat;
            }

            if (inv.HasItem(Inventory.Items.Red_Potion))
            {
                Menu[1, 2] = Inventory.Items.Red_Potion;
            }
            else if (inv.HasItem(Inventory.Items.Blue_Potion))
            {
                Menu[1, 2] = Inventory.Items.Blue_Potion;
            }

            if (inv.HasItem(Inventory.Items.Staff))
            {
                Menu[1, 3] = Inventory.Items.Staff;
            }

            return Menu;
        }

    }
}
