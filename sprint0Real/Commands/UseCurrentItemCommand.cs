using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.ItemUseSprites;
using sprint0Real.Levels;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands
{
    public class UseCurrentItemCommand : ICommand
    {
        private Game1 myGame;
        public UseCurrentItemCommand(Game1 game)
        {
            myGame = game;

            
        }
        //TODO
        public void Execute()
        {
            if (myGame.Link.CanAttack())
            {
                myGame.Link.SetCanAttack(false);
                myGame.Link.SetCanMove(false);
                
            }

        }
    }
}
