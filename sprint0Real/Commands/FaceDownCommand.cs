using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands
{
    public class FaceDownCommand : ICommand
    {
        private Game1 myGame;
        public FaceDownCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove())
            {
                myGame.linkSprite = new FaceDownSprite(myGame.linkSheet, myGame);
            }
        }
    }
}
