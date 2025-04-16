using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.GameState.NameRegistrationandAchievements
{
    public class SaveFile
    {
        public string Name { get; set; }
        public DateTime LastUsed { get; set; }
        public int KeyCollectCount { get; set; } = 0;
        public List<string> Achievements { get; set; } = new();
    }
}
