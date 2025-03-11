using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.LinkCommands
{
    public class MoveUpCommand : ICommand
    {
        private Game1 myGame;
        public MoveUpCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove())
            {
                myGame.Link.SetFacing(Link.Direction.Up);
                myGame.linkSprite = new MoveUpSprite(myGame.linkSheet, myGame);
            }
        }
    }
}
