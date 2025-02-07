using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands
{
    public class MoveRightCommand : ICommand
    {
        private Game1 myGame;
        public MoveRightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.getLocation();
            myGame.linkSprite = new MoveRightSprite(myGame.linkSheet, myGame);
        }
    }
}
