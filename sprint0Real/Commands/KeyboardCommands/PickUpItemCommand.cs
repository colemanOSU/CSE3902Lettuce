using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.ItemUseSprites;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class PickUpItem : ICommand
    {
        private Game1 myGame;
        private int itemSelection;
        public PickUpItem(Game1 game)
        {
            myGame = game;


        }
        public void Execute()
        {
            myGame.Link.SetCanAttack(false);
            myGame.Link.SetCanMove(false);
            myGame.linkSprite = new PickUpSprite(myGame.linkSheet, myGame);
        }
    }
}
