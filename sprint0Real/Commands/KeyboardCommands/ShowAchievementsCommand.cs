using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class ShowAchievementsCommand : ICommand
    {
        private Game1 game;
        public ShowAchievementsCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.currentGameState == GameState.GameStates.AchievementScreen)
            {
                game.currentGameState = GameState.GameStates.GamePlay;
            }
            else
            {
                game.currentGameState = GameState.GameStates.AchievementScreen;
            }
        }
    }
}
