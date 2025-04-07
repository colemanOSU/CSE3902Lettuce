using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class NextItemCommand : ICommand
    {
        private Game1 _game;
        private int _command;
        private Game1 game;

        public NextItemCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            _game.Link.NextItem();
        }
    }
}
