﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using sprint0Real.WolfLink;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class FaceUpCommand : ICommand
    {
        private Game1 myGame;
        private bool IsMoving;
        public FaceUpCommand(Game1 game, bool MovementKeyIsDown)
        {
            myGame = game;
            bool IsMoving = MovementKeyIsDown;
        }

        public void Execute()
        {
            if (myGame.Link.CanMove() && !IsMoving)
            {
                if (Wolf.Instance.isUsed())
                {
                    myGame.linkSprite = new WolfFaceUpSprite(myGame.wolfSheet, myGame);

                }
                else
                {
                    myGame.linkSprite = new FaceUpSprite(myGame.linkSheet, myGame);
                }
            }
        }
    }
}
