using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using System.Diagnostics;

namespace sprint0Real.Commands
{
    public class PauseCommand : ICommand
    {
        private Game1 myGame;
        public PauseCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentGameState = (myGame.currentGameState == GameState.GameStates.Pause) ? GameState.GameStates.GamePlay : GameState.GameStates.Pause;
        }
    }
}
