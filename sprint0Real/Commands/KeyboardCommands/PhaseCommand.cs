﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using System.Diagnostics;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class PhaseCommand : ICommand
    {
        private Game1 myGame;
        public PhaseCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (!myGame.Link.IsPhaseActive())
            {
                myGame.Link.SwitchPhaseActive();

            }
        }
    }
}
