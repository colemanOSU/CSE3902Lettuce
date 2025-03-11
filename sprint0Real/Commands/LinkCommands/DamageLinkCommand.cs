using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;

namespace sprint0Real.Commands.LinkCommands
{
    public class DamageLinkCommand : ICommand
    {
        private Game1 myGame;
        public DamageLinkCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.DamageLink();
            myGame.LinkState.DamageLink();
        }
    }
}
