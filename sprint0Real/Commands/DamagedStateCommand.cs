using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands
{
    public class DamagedStateCommand : ICommand
    {
        private Texture2D _texture;
        private Game1 _game;
        public DamagedStateCommand(Game1 game,Texture2D link) {
            _game = game;
            _texture = link;
        }
        public void Execute()
        {

        }
    }
}
