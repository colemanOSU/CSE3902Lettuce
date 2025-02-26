using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands
{
    public class FaceLeftCommand : ICommand
    {
        private Game1 myGame;
        private bool IsMoving;
        public FaceLeftCommand(Game1 game, bool MovementKeyIsDown)
        {
            myGame = game;
            IsMoving = MovementKeyIsDown;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove() && !IsMoving)
            {
                myGame.linkSprite = new FaceLeftSprite(myGame.linkSheet, myGame);
            }
        }
    }
}
