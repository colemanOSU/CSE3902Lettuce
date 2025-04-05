using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using System.Diagnostics;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class UnMenuCommand : ICommand
    {
        private Game1 myGame;
        public UnMenuCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //myGame.currentGameState = (myGame.currentGameState == GameState.GameStates.Pause) ? GameState.GameStates.GamePlay : GameState.GameStates.Pause;
            myGame.currentGameState = GameState.GameStates.MenuTransition;
            myGame.InMenu = false;
            myGame.CameraTarget = new Vector2(Game1.SCREENMIDX, Game1.SCREENMIDY);
        }
    }
}
