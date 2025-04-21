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
using System.Windows.Input;
using ICommand = sprint0Real.Interfaces.ICommand;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class MultipleCommand : ICommand
    {
        private ICommand first;
        private ICommand second;
        public MultipleCommand(ICommand firstCommand, ICommand secondCommand)
        {
            first = firstCommand;
            second = secondCommand;
        }
        public void Execute()
        {
            first.Execute();
            second.Execute();
        }
    }
}
