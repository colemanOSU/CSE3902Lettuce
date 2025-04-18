using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using sprint0Real.WolfLink;

namespace sprint0Real.Commands.KeyboardCommands
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
            if (myGame.Link.CanMove())
            {
                myGame.Link.SetFacing(Link.Direction.Right);
                if (Wolf.Instance.isUsed())
                {
                    myGame.linkSprite = new WolfMoveRightSprite(myGame.wolfSheet, myGame);
                }
                else
                {
                    myGame.linkSprite = new MoveRightSprite(myGame.linkSheet, myGame);
                }
            }
        }
    }
}
