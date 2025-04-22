using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.GameState.NameRegistrationandAchievements;
using sprint0Real.Interfaces;
using sprint0Real.ItemUseSprites;
using sprint0Real.Levels;
using sprint0Real.LinkStuff.LinkSprites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class CheatCommand : ICommand
    {
        private Game1 myGame;
        private bool useItem = false;
        public int[] ans = { 1, 2, 3, 4, 3, 2, 1 };
        public Queue buffer = new Queue();
        public int lastDirection;
        public bool attackReady = false;
        public int cheatSize = 7;

        public CheatCommand(Game1 game)
        {
            myGame = game;
            lastDirection = 0;
        }
        public void areEqual()
        {
            int count = 0;
            attackReady = false;
            if (buffer.Count >= cheatSize)
            {
                attackReady = true;
                foreach (int direction in buffer)
                {
                    if (direction != ans[count])
                    {
                        attackReady = false;
                    }
                    count++;
                }
            }
        }

        public void Add(int direction)
        {
            if (lastDirection != direction)
            {

                buffer.Enqueue(direction);
                if (buffer.Count > cheatSize)
                {
                    buffer.Dequeue();
                }
                lastDirection = direction;
                areEqual();
            }
        }
        public int whichDirection()
        {
            switch (myGame.Link.GetFacing())
            {
                case Link.Direction.Left:
                    return 4;
                case Link.Direction.Right:
                    return 2;
                case Link.Direction.Up:
                    return 1;
                case Link.Direction.Down:
                    return 3;
            }
            return 0;
        }
        public void Execute()
        {
            int direction = whichDirection();
            if (attackReady)
            {
                attackReady = false;
                lastDirection = 0;
                myGame.linkSprite = new UseFireball(myGame.linkSheet, myGame, useItem);
                AchievementManager.Unlock("???");
            }
            Add(direction);

        }
    }
}
