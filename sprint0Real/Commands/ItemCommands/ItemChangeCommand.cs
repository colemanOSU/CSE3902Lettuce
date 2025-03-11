using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands.ItemCommands
{
    public class ItemChangeCommand : ICommand
    {
        private Game1 _game;
        private int _command;
        public ItemChangeCommand(Game1 game, int commandNum)
        {
            _game = game;
            _command = commandNum;
        }
        public void Execute()
        {
            _game.Link.SetItem(_command, _game);
        }
    }
}
