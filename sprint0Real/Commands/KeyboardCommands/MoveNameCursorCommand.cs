﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.GameState.NameRegistrationandAchievements;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.KeyboardCommands
{
    public class MoveNameCursorCommand : ICommand
    {
        private Game1 _game;
        private int deltaX, deltaY;

        public MoveNameCursorCommand(Game1 game, int dx, int dy)
        {
            _game = game;
            deltaX = dx;
            deltaY = dy;
        }

        public void Execute()
        {
            if(_game.NameScene.currentMode == NameRegistrationScene.RegistrationMode.TypingNew)
            {
                _game.NameScene.MoveCursor(deltaX, deltaY);
            }
            else if (_game.NameScene.currentMode == NameRegistrationScene.RegistrationMode.SelectingRecent)
            {
                int count = SaveManager.RecentNames.Count;
                if(count == 0)
                {
                    return;
                }
                _game.NameScene.recentNameIndex = ((_game.NameScene.recentNameIndex + deltaY) % count + count) % count;
            }
        }
    }
}
