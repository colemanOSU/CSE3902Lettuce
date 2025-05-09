﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.GameState.NameRegistrationandAchievements;
using sprint0Real.Interfaces;
using sprint0Real.ItemUseSprites;
using sprint0Real.Levels;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class KamehamehaCommand : ICommand
    {
        private Game1 myGame;
        private bool useItem = false;
        public KamehamehaCommand(Game1 game)
        {
            myGame = game;


        }
        public void Execute()
        {
            if (myGame.Link.CanAttack())
            {
                myGame.Link.SetCanAttack(false);
                myGame.Link.SetCanMove(false);
                myGame.linkSprite = new KamehamehaSprite(myGame.linkSheet, myGame, myGame.Link.GetFacing());
            }
            AchievementManager.Unlock("Kamehame-HA!");

        }
    }
}
