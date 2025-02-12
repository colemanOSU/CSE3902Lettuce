using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands
{
    public class PreviousEnemy : ICommand
    {
        private Game1 myGame;
        public PreviousEnemy(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.EnemyCycle.PreviousEnemy();
        }
    }
}
