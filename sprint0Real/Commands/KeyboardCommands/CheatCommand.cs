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

namespace sprint0Real.Commands.KeyboardCommands
{
    public class CheatCommand : ICommand
    {
        private Game1 myGame;
        private bool useItem = false;
        Queue ans = new Queue();
        Queue buffer = new Queue();
        int lastDirection=2;
        bool attackReady = false;

        public CheatCommand(Game1 game)
        {
            myGame = game;
            ans.Enqueue(1);
            ans.Enqueue(2);
            ans.Enqueue(3);
            ans.Enqueue(4);
            ans.Enqueue(3);
            ans.Enqueue(2);
            ans.Enqueue(1);

        }
        public void Add(int direction)
        {
            if(lastDirection != direction)
            {
                buffer.Enqueue(direction);
                if (buffer.Count > 7)
                {
                    buffer.Dequeue();
                }
                if (ans.Equals(buffer))
                {
                    attackReady = true;
                }
                if (attackReady)
                {
                    Execute();
                }
                lastDirection = direction;
            }
        }
        public void Execute()
        {
            switch (myGame.Link.GetFacing())
            {
                case Link.Direction.Left:
                    myGame.linkSprite = new UseLeftSprite(myGame.linkSheet, myGame, useItem);
                    break;
                case Link.Direction.Right:
                    myGame.linkSprite = new UseRightSprite(myGame.linkSheet, myGame, useItem);
                    break;
                case Link.Direction.Up:
                    myGame.linkSprite = new UseUpSprite(myGame.linkSheet, myGame, useItem);
                    break;
                case Link.Direction.Down:
                    myGame.linkSprite = new UseDownSprite(myGame.linkSheet, myGame, useItem);
                    break;
            }

        }
    }
}
