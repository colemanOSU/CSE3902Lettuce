using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using sprint0Real.WolfLink;

namespace sprint0Real.Commands.KeyboardCommands
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
                if (Wolf.Instance.isUsed())
                {
                    myGame.linkSprite = new WolfMoveUpSprite(myGame.wolfSheet, myGame);
                }

                else { 
                     myGame.linkSprite = new MoveUpSprite(myGame.linkSheet, myGame);
                }
            }
        }
    }
}
