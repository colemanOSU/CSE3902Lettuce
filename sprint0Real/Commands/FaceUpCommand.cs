using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands
{
    public class FaceUpCommand : ICommand
    {
        private Game1 myGame;
        private bool IsMoving;
        public FaceUpCommand(Game1 game, bool MovementKeyIsDown)
        {
            myGame = game;
            bool IsMoving = MovementKeyIsDown;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove() && !IsMoving)
            {
                myGame.linkSprite = new FaceUpSprite(myGame.linkSheet, myGame);
            }
        }
    }
}
