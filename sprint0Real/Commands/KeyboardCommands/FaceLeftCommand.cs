using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using sprint0Real.WolfLink;

namespace sprint0Real.Commands.KeyboardCommands
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
            if (Wolf.Instance.isUsed())
            {
                myGame.linkSprite = new WolfFaceLeftSprite(myGame.wolfSheet, myGame);

            }
            else
            {
                myGame.linkSprite = new FaceLeftSprite(myGame.linkSheet, myGame);
            }
        }
    }
}
