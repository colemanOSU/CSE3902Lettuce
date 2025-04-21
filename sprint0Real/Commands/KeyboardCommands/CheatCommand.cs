using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.ItemUseSprites;
using sprint0Real.Levels;
using sprint0Real.LinkStuff.LinkSprites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class CheatCommand : ICommand
    {
        private Game1 myGame;
        private bool useItem = false;
        int[] ans = {1,2,3,4,3,2,1};
        Queue buffer = new Queue();
        int lastDirection=2;
        bool attackReady = false;
        int cheatSize = 7;

        public CheatCommand(Game1 game,  int direction)
        {
            myGame = game;
            Add(direction);

        }
        public bool areEqual()
        {
            int count = 0;
            bool equality = false;
            if (buffer.Count == cheatSize) 
            {
                equality = true;
                foreach (int direction in buffer)
                {
                    if (direction != ans[count])
                    {
                    equality = false;
                    }
                count++;
                }
            }
            return equality;
        }

        public void Add(int direction)
        {
            if(lastDirection != direction)
            {
                buffer.Enqueue(direction);
                if (buffer.Count > cheatSize)
                {
                    buffer.Dequeue();
                }
                if (attackReady)
                {
                    Execute();
                }
                lastDirection = direction;
                if (areEqual())
                {
                    attackReady = true;
                }
            }
        }
        public void Execute()
        {
            switch (myGame.Link.GetFacing())
            {
                //case Link.Direction.Left:
                //    myGame.linkSprite = new UseLeftSprite(myGame.linkSheet, myGame, useItem);
                //    break;
                //case Link.Direction.Right:
                //    myGame.linkSprite = new UseRightSprite(myGame.linkSheet, myGame, useItem);
                //    break;
                //case Link.Direction.Up:
                //    myGame.linkSprite = new UseUpSprite(myGame.linkSheet, myGame, useItem);
                //    break;
                //case Link.Direction.Down:
                //    myGame.linkSprite = new UseDownSprite(myGame.linkSheet, myGame, useItem);
                //    break;
            }

        }
    }
}
