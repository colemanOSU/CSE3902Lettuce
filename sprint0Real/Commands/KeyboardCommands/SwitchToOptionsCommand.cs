using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class SwitchToOptionsCommand : ICommand
    {
        private Game1 _game;

        public SwitchToOptionsCommand(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            _game.NameScene.ChangePlayerChoice();
        }
    }
}
