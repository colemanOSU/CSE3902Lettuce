using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands
{
    public class AttackCommand : ICommand
    {
        private Game1 myGame;
        private int itemSelection;
        public AttackCommand(Game1 game)
        {
            myGame = game;

            
        }
        public void Execute()
        {
            if (myGame.Link.CanAttack())
            {

                switch (myGame.Link.GetFacing())
                {
                    case Link.Direction.Left:
                        myGame.linkSprite = new UseLeftSprite(myGame.linkSheet, myGame);
                        break;
                    case Link.Direction.Right:
                        myGame.linkSprite = new UseRightSprite(myGame.linkSheet, myGame);
                        break;
                    case Link.Direction.Up:
                        myGame.linkSprite = new UseUpSprite(myGame.linkSheet, myGame);
                        break;
                    case Link.Direction.Down:
                        myGame.linkSprite = new UseDownSprite(myGame.linkSheet, myGame);
                        break;
                }
                
                //temp
                //myGame.tempItem = new WoodSwordSprite(myGame.linkSheet, myGame);
                //temp
            }

        }
    }
}
