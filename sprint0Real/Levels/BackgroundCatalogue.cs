using System;
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
            InteriorCatalogue.Add("Default", new Rectangle(12, 12, 12, 12));
            InteriorCatalogue.Add("EntranceInteior", new Rectangle(12, 12, 12, 12));
            InteriorCatalogue.Add("DungeonInterior", new Rectangle(12, 12, 12, 12));
        }

    }
}
