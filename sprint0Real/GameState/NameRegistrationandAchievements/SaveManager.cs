using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace sprint0Real.GameState.NameRegistrationandAchievements
{
    public class SaveManager
    {
        private static readonly string saveDirectory = Path.Combine(AppContext.BaseDirectory, "sprint0Real", "GameState", "NameRegistrationandAchievements");
        private static readonly string savePath = Path.Combine(saveDirectory, "playerData.json");

        public static Dictionary<string, SaveFile> AllSaves = new();
        public static List<string> RecentNames = new(); //Most recent 3

        public static void Load()
        {
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                var wrapper = JsonSerializer.Deserialize<SaveWrapper>(json) ?? new SaveWrapper();
                AllSaves = wrapper.AllSaves ?? new();
                RecentNames = wrapper.RecentNames ?? new();
            }
            else
            {
                Save();
            }
        }

        public static void Save()
        {
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            var wrapper = new SaveWrapper { AllSaves = AllSaves, RecentNames = RecentNames };
            var json = JsonSerializer.Serialize(wrapper, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(savePath, json);
        }

        public static void UsePlayer(string name)
        {
            if (!AllSaves.ContainsKey(name))
            {
                AllSaves[name] = new SaveFile { Name = name};
            }

            AllSaves[name].LastUsed = DateTime.Now;

            //Move to front of recent list
            RecentNames.Remove(name);
            RecentNames.Insert(0, name);

            //Trim to 3
            if (RecentNames.Count > 3)
            {
                RecentNames.RemoveAt(3);
            }

            Save();
        }

        public static SaveFile GetSave(string name)
        {
            return AllSaves.TryGetValue(name, out var save) ? save : null;
        }

        private class SaveWrapper
        {
            public Dictionary<string, SaveFile> AllSaves { get; set; }
            public List<string> RecentNames { get; set; }
        }
    }
}
