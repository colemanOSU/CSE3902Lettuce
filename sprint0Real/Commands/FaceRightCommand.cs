using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Controllers;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands
{
    public class FaceRightCommand : ICommand
    {
        private readonly Game1 myGame;
        public FaceRightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove())
            {
                myGame.linkSprite = new FaceRightSprite(myGame.linkSheet, myGame);

            }
        }
    }
}
