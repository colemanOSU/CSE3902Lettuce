using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands
{
    public class FaceLeftCommand : ICommand
    {
        private Game1 myGame;
        public FaceLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove())
            {
                myGame.linkSprite = new FaceLeftSprite(myGame.linkSheet, myGame);
            }
        }
    }
}
