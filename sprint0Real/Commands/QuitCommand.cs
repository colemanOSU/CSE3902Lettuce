using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands
{
    public class QuitCommand : ICommand
    {
        private Game1 _game;
        public QuitCommand(Game1 game)
        {
           _game = game;
        }

        public void Execute()
        {
            _game.Exit();
        }
    }
}
