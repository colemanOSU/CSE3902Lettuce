using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands
{
    public class LinkHitsEnemyFromBottom : ICommand
    {
        private ILink link;
        private IEnemy enemy;

        public LinkHitsEnemyFromBottom(ILink link, IEnemy enemy)
        {
            this.link = link;
            this.enemy = enemy;
        }

        public void Execute()
        {
            Debug.WriteLine("Link hit the enemy from the bottom!");
        }
    }
}
