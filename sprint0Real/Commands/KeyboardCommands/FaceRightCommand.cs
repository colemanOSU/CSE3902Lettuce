using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Controllers;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class FaceRightCommand : ICommand
    {
        private readonly Game1 myGame;
        private bool IsMoving;
        public FaceRightCommand(Game1 game, bool MovementKeyIsDown)
        {
            myGame = game;
            IsMoving = MovementKeyIsDown;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove() && !IsMoving)
            {
                myGame.linkSprite = new FaceRightSprite(myGame.linkSheet, myGame);

            }
        }
    }
}
