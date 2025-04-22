using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.GameState.NameRegistrationandAchievements
{
    public static class AchievementManager
    {
        public static Dictionary<string, string> AllAchievements = new Dictionary<string, string>
        {
            { "First Time Playing!", "Start the game for the first time." },
            { "Key Collector!", "Gather 5 keys." },
            { "Bomber!", "Use a bomb for the first time." },
            { "Secret Revealer!", "Find hidden door." },
            { "Kamehame-HA!", "Use the Kamehameha for the first time." },
            { "Fairy Catcher!", "Collect a fairy." },
            { "Wolf Rider!", "Use Link's Wolf powerup." },
            { "Dungeon Complete!", "Collect the Triforce." },
            { "???", "Discover Secret Cheat Code Fireball" }
        };
        public static bool Unlock(string title)
        {
            var save = SaveManager.GetSave(Game1.Instance.CurrentPlayerName);
            if (save == null || save.Achievements.Contains(title))
                return false;

            save.Achievements.Add(title);
            SaveManager.Save();

            Game1.Instance?.ShowAchievementPopup(title);

            return true;
        }

        public static bool HasAchievement(string playerName, string achievementId)
        {
            var save = SaveManager.GetSave(playerName);
            return save?.Achievements.Contains(achievementId) ?? false;
        }
    }
}
