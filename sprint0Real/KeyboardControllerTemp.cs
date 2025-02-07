using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using sprint0Real.Interfaces;

namespace sprint0Real
{
    public class KeyboardControllerTemp : IControllerTemp
    {
        private Dictionary<Keys, ICommand> commands;
        private int currentBlock;

        public KeyboardControllerTemp(Game1 game)
        {
            commands = new Dictionary<Keys, ICommand>();
            currentBlock = 1;

            if (Keyboard.GetState().Equals(Keys.Y))
            {
                currentBlock++;
            }

            commands.Add(Keys.D0, new QuitCommand(game));
            commands.Add(Keys.NumPad0, new QuitCommand(game));
            commands.Add(Keys.Y, new NextBlockCommand(game, currentBlock, game.Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset")));
            commands.Add(Keys.E, new DamagedStateCommand(game, game.Content.Load<Texture2D>("zelda")));

        }
        public void Update(GameTime gameTime)
        {
            var KeyboardState = Keyboard.GetState();
            foreach(var commands in commands)
            {
                if (KeyboardState.IsKeyDown(commands.Key))
                {
                    commands.Value.Execute();
                }
            }
        }
    }
}
