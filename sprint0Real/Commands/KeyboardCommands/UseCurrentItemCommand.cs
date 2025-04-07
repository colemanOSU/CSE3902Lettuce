using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.ItemUseSprites;
using sprint0Real.Levels;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class UseCurrentItemCommand : ICommand
    {
        private Game1 myGame;
        private bool useItem = true;
        public UseCurrentItemCommand(Game1 game)
        {
            myGame = game;


        }
        public void Execute()
        {
            if (myGame.Link.CanAttack())
            {
                myGame.Link.SetCanAttack(false);
                myGame.Link.SetCanMove(false);
                switch (myGame.Link.GetFacing())
                {
                    case Link.Direction.Left:
                        myGame.linkSprite = new UseLeftSprite(myGame.linkSheet, myGame, useItem);
                        break;
                    case Link.Direction.Right:
                        myGame.linkSprite = new UseRightSprite(myGame.linkSheet, myGame, useItem);
                        break;
                    case Link.Direction.Up:
                        myGame.linkSprite = new UseUpSprite(myGame.linkSheet, myGame, useItem);
                        break;
                    case Link.Direction.Down:
                        myGame.linkSprite = new UseDownSprite(myGame.linkSheet, myGame, useItem);
                        break;
                }

            }

        }
    }
}
