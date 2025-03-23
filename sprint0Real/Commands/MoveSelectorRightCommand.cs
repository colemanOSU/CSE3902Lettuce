using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using System.Diagnostics;

namespace sprint0Real.Commands
{
    public class MoveSelectorLeftCommand : ICommand
    {
        private Game1 myGame;
        public MoveSelectorLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.MenuUISprite.MoveSelectorLeft();
        }
    }
}
