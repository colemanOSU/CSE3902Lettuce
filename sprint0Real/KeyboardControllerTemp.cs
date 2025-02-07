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
        private int currentBlock = 1;
        private Game1 _game;
        private ILink _Link;
        private Texture2D blockTexture;

        public KeyboardControllerTemp(Game1 game)
        {
            commands = new Dictionary<Keys, ICommand>();
            _game = game;
            blockTexture = _game.Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            


            commands.Add(Keys.D0, new QuitCommand(_game));
            commands.Add(Keys.NumPad0, new QuitCommand(_game));
            commands.Add(Keys.Y, new NextBlockCommand(_game, blockTexture));
            commands.Add(Keys.T, new PreviousBlockCommand(_game, blockTexture));
            commands.Add(Keys.D, new MoveRightCommand(_game));

        }
        public void Update(GameTime gameTime)
        {
            var KeyboardState = Keyboard.GetState();
            foreach(var command in commands)
            {
                if (KeyboardState.IsKeyDown(command.Key))
                {
                    command.Value.Execute();
                }
            }
        }
    }
}
