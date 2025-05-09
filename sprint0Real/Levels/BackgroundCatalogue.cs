﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.Levels
{
    public class BackgroundCatalogue
    {
        public Dictionary<String, Rectangle> InteriorCatalogue;
        public Dictionary<String, Rectangle> ExteriorCatalogue;
        public Dictionary<String, Rectangle> LeftDoorCatalogue;
        public Dictionary<String, Rectangle> RightDoorCatalogue;
        public Dictionary<String, Rectangle> UpDoorCatalogue;
        public Dictionary<String, Rectangle> DownDoorCatalogue;
        public BackgroundCatalogue()
        {
            InteriorCatalogue = new Dictionary<String, Rectangle>();
            ExteriorCatalogue = new Dictionary<String, Rectangle>();
            LeftDoorCatalogue = new Dictionary<String, Rectangle>();
            RightDoorCatalogue = new Dictionary<String, Rectangle>();
            UpDoorCatalogue = new Dictionary<String, Rectangle>();
            DownDoorCatalogue = new Dictionary<String, Rectangle>();

            InteriorCatalogue.Add("Default", new Rectangle(1, 192, 192, 112));
            InteriorCatalogue.Add("EntranceInterior", new Rectangle(196, 192, 192, 112));
            InteriorCatalogue.Add("SandInterior", new Rectangle(586, 421, 192, 112));
            InteriorCatalogue.Add("SolidBlack", new Rectangle(975, 880, 192, 112));
            InteriorCatalogue.Add("Level4", new Rectangle(585, 307, 192, 112));
            InteriorCatalogue.Add("Level5", new Rectangle(196, 422, 192, 112));
            InteriorCatalogue.Add("Level13", new Rectangle(780, 306, 192, 112));
            InteriorCatalogue.Add("Level14", new Rectangle(975, 308, 192, 112));
            InteriorCatalogue.Add("Nil", Rectangle.Empty);

            ExteriorCatalogue.Add("Dungeon", new Rectangle(421, 1009, 256, 160));
            ExteriorCatalogue.Add("Default", new Rectangle(521, 11, 256, 176));

            UpDoorCatalogue.Add("Default", new Rectangle(815, 11, 32, 32));
            UpDoorCatalogue.Add("Open", new Rectangle(848, 11, 32, 32));
            UpDoorCatalogue.Add("Locked", new Rectangle(881, 11, 32, 32));
            UpDoorCatalogue.Add("Sealed", new Rectangle(914, 11, 32, 32));
            UpDoorCatalogue.Add("Breached", new Rectangle(947, 11, 32, 32));
            UpDoorCatalogue.Add("Nil", Rectangle.Empty);

            LeftDoorCatalogue.Add("Default", new Rectangle(815, 44, 32, 32));
            LeftDoorCatalogue.Add("Open", new Rectangle(848, 44, 32, 32));
            LeftDoorCatalogue.Add("Locked", new Rectangle(881, 44, 32, 32));
            LeftDoorCatalogue.Add("Sealed", new Rectangle(914, 44, 32, 32));
            LeftDoorCatalogue.Add("Breached", new Rectangle(947, 44, 32, 32));
            LeftDoorCatalogue.Add("Nil", Rectangle.Empty);


            RightDoorCatalogue.Add("Default", new Rectangle(815, 77, 32, 32));
            RightDoorCatalogue.Add("Open", new Rectangle(848, 77, 32, 32));
            RightDoorCatalogue.Add("Locked", new Rectangle(881, 77, 32, 32));
            RightDoorCatalogue.Add("Sealed", new Rectangle(914, 77, 32, 32));
            RightDoorCatalogue.Add("Breached", new Rectangle(947, 77, 32, 32));
            RightDoorCatalogue.Add("Nil", Rectangle.Empty);


            DownDoorCatalogue.Add("Default", new Rectangle(815, 110, 32, 32));
            DownDoorCatalogue.Add("Open", new Rectangle(848, 110, 32, 32));
            DownDoorCatalogue.Add("Locked", new Rectangle(881, 110, 32, 32));
            DownDoorCatalogue.Add("Sealed", new Rectangle(914, 110, 32, 32));
            DownDoorCatalogue.Add("Breached", new Rectangle(947, 110, 32, 32));
            DownDoorCatalogue.Add("Nil", Rectangle.Empty);

        }

    }
}
