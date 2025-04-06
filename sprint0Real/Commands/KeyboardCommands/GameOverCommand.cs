using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class GameOverCommand : ICommand
    {
        private Game1 _game;
        public GameOverCommand(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            _game.currentGameState = GameState.GameStates.GameOver;
        }
    }
}
