using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class DamagedStateCommand : ICommand
    {
        private ILink _link;
        private Game1 _game;
        public DamagedStateCommand(Game1 game)
        {
            _link = game.Link;
            _game = game;
        }
        public void Execute()
        {
            _link.SetIsDamaged(true);
            _game.linkSprite = new DamagedSprite(_game, _game.linkSheet);

        }
    }
}
