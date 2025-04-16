using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.NameRegistration;

namespace sprint0Real.NameRegistrationandAchievements
{
    public static class AchievementManager
    {
        public static void Unlock(string playerName, string achievementId)
        {
            if (string.IsNullOrEmpty(playerName)) return;

            var save = SaveManager.GetSave(playerName);
            if (save == null) return;

            if (!save.Achievements.Contains(achievementId))
            {
                save.Achievements.Add(achievementId);
                SaveManager.Save();
            }

            Game1.Instance?.ShowAchievementPopup(achievementId);
        }

        public static bool HasAchievement(string playerName, string achievementId)
        {
            var save = SaveManager.GetSave(playerName);
            return save?.Achievements.Contains(achievementId) ?? false;
        }
    }
}
