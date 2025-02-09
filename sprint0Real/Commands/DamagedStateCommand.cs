using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands
{
    public class DamagedStateCommand : ICommand
    {
        private Link _link;
        private Game1 _game;
        private ISprite _sprite;
        public DamagedStateCommand(Game1 game) {
            _link = game.link;
            _game = game;
            _sprite = game.sprite;

        }
        public void Execute()
        {
            Console.WriteLine("Updatding");
            _link.Damaged();

        }
    }
}
