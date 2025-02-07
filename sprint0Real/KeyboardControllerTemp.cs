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
        private Dictionary<Keys, bool> keyPreviouslyPressed;
        private int currentBlock = 1;
        private Game1 _game;
        private ILink _Link;
        private Texture2D blockTexture;

        public KeyboardControllerTemp(Game1 game)
        {
            commands = new Dictionary<Keys, ICommand>();
            keyPreviouslyPressed = new Dictionary<Keys, bool>();
            _game = game;
            blockTexture = _game.Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            


            commands.Add(Keys.D0, new QuitCommand(_game));
            commands.Add(Keys.NumPad0, new QuitCommand(_game));
            commands.Add(Keys.Y, new NextBlockCommand(_game, blockTexture));
            commands.Add(Keys.T, new PreviousBlockCommand(_game, blockTexture));
            commands.Add(Keys.D, new MoveRightCommand(_game));

            foreach (Keys key in commands.Keys )
            {
                keyPreviouslyPressed[key] = false;
            }

        }
        public void Update(GameTime gameTime)
        {
            var KeyboardState = Keyboard.GetState();
            foreach(var command in commands)
            {
                Keys key = command.Key;
                bool isKeyDown = KeyboardState.IsKeyDown(key);

                if (isKeyDown && !keyPreviouslyPressed[key])
                {
                    command.Value.Execute();
                }

                //update state
                keyPreviouslyPressed[key] = isKeyDown;
            }
        }
    }
}
