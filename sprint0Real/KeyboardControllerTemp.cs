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
        private Dictionary<Keys, ICommand> releaseCommands;

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
            blockTexture = _game.Content.Load<Texture2D>("Dungeon_Tileset");

            

            commands.Add(Keys.D0, new QuitCommand(_game));
            commands.Add(Keys.NumPad0, new QuitCommand(_game));
            commands.Add(Keys.Y, new NextBlockCommand(_game, blockTexture));
            commands.Add(Keys.T, new PreviousBlockCommand(_game, blockTexture));
            commands.Add(Keys.D, new MoveRightCommand(_game));
            commands.Add(Keys.A, new MoveLeftCommand(_game));
            commands.Add(Keys.W, new MoveUpCommand(_game));
            commands.Add(Keys.S, new MoveDownCommand(_game));
            commands.Add(Keys.Z, new AttackCommand(_game));
            commands.Add(Keys.N, new AttackCommand(_game));

            //Commands for when key is released. Subject to change.
            releaseCommands = new Dictionary<Keys, ICommand>();

            releaseCommands.Add(Keys.D, new FaceRightCommand(_game));
            releaseCommands.Add(Keys.A, new FaceLeftCommand(_game));
            releaseCommands.Add(Keys.W, new FaceUpCommand(_game));
            releaseCommands.Add(Keys.S, new FaceDownCommand(_game));


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

                if (!isKeyDown && keyPreviouslyPressed[key] && releaseCommands.ContainsKey(key))
                {
                    releaseCommands.GetValueOrDefault(key).Execute();
                }
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
