using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using sprint0Real.Interfaces;

namespace sprint0Real.Controllers
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> commands;
        private Vector2 location;
        private Dictionary<Keys, ICommand> releaseCommands;

        private Dictionary<Keys, bool> keyPreviouslyPressed;

        private Game1 _game;
        private ILink _Link;
        private Texture2D blockTexture;
        private Texture2D itemTexture;
        private bool MovementKeyIsDown;

        public KeyboardController(Game1 game)
        {
            commands = new Dictionary<Keys, ICommand>();

            keyPreviouslyPressed = new Dictionary<Keys, bool>();
            _game = game;
            blockTexture = _game.Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            itemTexture = _game.Content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons");


            commands.Add(Keys.Y, new NextBlockCommand(_game, blockTexture));
            commands.Add(Keys.T, new PreviousBlockCommand(_game, blockTexture));
            commands.Add(Keys.I, new ShowNextItemCommand(_game,  itemTexture));
            commands.Add(Keys.U, new ShowPreviousItemCommand(_game, itemTexture));
            commands.Add(Keys.E, new DamageLinkCommand(_game));
            commands.Add(Keys.D, new MoveRightCommand(_game));
            commands.Add(Keys.A, new MoveLeftCommand(_game));
            commands.Add(Keys.W, new MoveUpCommand(_game));
            commands.Add(Keys.S, new MoveDownCommand(_game));
            commands.Add(Keys.Right, new MoveRightCommand(_game));
            commands.Add(Keys.Left, new MoveLeftCommand(_game));
            commands.Add(Keys.Up, new MoveUpCommand(_game));
            commands.Add(Keys.Down, new MoveDownCommand(_game));
            commands.Add(Keys.Z, new AttackCommand(_game));
            commands.Add(Keys.N, new AttackCommand(_game));
            commands.Add(Keys.Q, new QuitCommand(_game));
            commands.Add(Keys.R, new ResetCommand(_game));
            commands.Add(Keys.D1, new ItemChangeCommand(_game, 1));
            commands.Add(Keys.D2, new ItemChangeCommand(_game, 2));
            commands.Add(Keys.D3, new ItemChangeCommand(_game, 3));
            commands.Add(Keys.D4, new ItemChangeCommand(_game, 4));
            commands.Add(Keys.D5, new ItemChangeCommand(_game, 5));
            commands.Add(Keys.D6, new ItemChangeCommand(_game, 6));
            commands.Add(Keys.D7, new ItemChangeCommand(_game, 7));
            commands.Add(Keys.D8, new ItemChangeCommand(_game, 8));
            commands.Add(Keys.D9, new ItemChangeCommand(_game, 9));
            commands.Add(Keys.D0, new ItemChangeCommand(_game, 0));



            //Commands for when key is released. Subject to change.
            releaseCommands = new Dictionary<Keys, ICommand>();

            releaseCommands.Add(Keys.D, new FaceRightCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.A, new FaceLeftCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.W, new FaceUpCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.S, new FaceDownCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Right, new FaceRightCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Left, new FaceLeftCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Up, new FaceUpCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Down, new FaceDownCommand(_game, MovementKeyIsDown));


            foreach (Keys key in commands.Keys)
            {
                keyPreviouslyPressed[key] = false;
            }

        }
        public void Update(GameTime gameTime)
        {
            var KeyboardState = Keyboard.GetState();

            //This variable is to help with logic when two movement keys are pressed simultaneously.
            MovementKeyIsDown = KeyboardState.IsKeyDown(Keys.A) || KeyboardState.IsKeyDown(Keys.W) || KeyboardState.IsKeyDown(Keys.S) || KeyboardState.IsKeyDown(Keys.D)
                || KeyboardState.IsKeyDown(Keys.Left) || KeyboardState.IsKeyDown(Keys.Up) || KeyboardState.IsKeyDown(Keys.Down) || KeyboardState.IsKeyDown(Keys.Right);

            

            foreach (var command in commands)
            {
                Keys key = command.Key;
                bool isKeyDown = KeyboardState.IsKeyDown(key);

                if (!isKeyDown && keyPreviouslyPressed[key] && releaseCommands.ContainsKey(key) && !MovementKeyIsDown)
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
