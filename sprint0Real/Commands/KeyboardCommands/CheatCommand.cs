using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.ItemUseSprites;
using sprint0Real.Levels;
using sprint0Real.LinkStuff.LinkSprites;
using System;
using System.Linq;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class CheatCommand : ICommand
    {
        private Game1 myGame;
        private bool useItem = false;
        int[] ans = { 1, 2, 3, 4, 3, 2, 1 };
        int[] buffer;


        public CheatCommand(Game1 game)
        {
            myGame = game;

        }
        public void Add(int direction)
        {
            int length = buffer.Length;
            if (buffer[length - 1]!= direction)
            {
                int[] temp = { };
                if (buffer.Length == 7)
                {
                    Array.Copy(buffer, 1, temp,0, 6);
                    Array.Copy(temp, 0, buffer, 0, 6);
                    buffer[7] = direction;
                }
                else
                {
                    buffer[length - 1] = direction;
                }
                if (ans.SequenceEqual(buffer))
                {
                    Execute();
                }
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
