using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.NameRegistration
{
    public class SaveFile
    {
        public string Name { get; set; }
        public List<string> Achievements { get; set; } = new List<string>();
        public DateTime LastUsed { get; set; }

        public SaveFile() { }

        public SaveFile(string name)
        {
            Name = name;
            LastUsed = DateTime.Now;
        }
    }
}
