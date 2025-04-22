using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands.KeyboardCommands;
using sprint0Real.Interfaces;


namespace sprint0Real.Controllers
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> commands;
        private Dictionary<Keys, ICommand> releaseCommands;
        private Dictionary<Keys, ICommand> MenuCommands;
        private Dictionary<Keys, ICommand> PauseCommands;
        private Dictionary<Keys, ICommand> GameOverCommands;
        private Dictionary<Keys, ICommand> NameRegistrationCommands;
        private Dictionary<Keys, ICommand> AchievementScreenCommands;
        private Dictionary<Keys, ICommand> TitleScreenCommands;

        private Dictionary<Keys, bool> keyPreviouslyPressed;

        private Game1 _game;
        private bool MovementKeyIsDown;

        public KeyboardController(Game1 game)
        {
            commands = new Dictionary<Keys, ICommand>();

            keyPreviouslyPressed = new Dictionary<Keys, bool>();
            _game = game;
            CheatCommand inputBuffer = new CheatCommand(_game);

            commands.Add(Keys.E, new DamageLinkCommand(_game));
            commands.Add(Keys.D, new MultipleCommand(new MoveRightCommand(_game), inputBuffer));
            commands.Add(Keys.A, new MultipleCommand(new MoveLeftCommand(_game), inputBuffer));
            commands.Add(Keys.W, new MultipleCommand(new MoveUpCommand(_game), inputBuffer));
            commands.Add(Keys.S, new MultipleCommand(new MoveDownCommand(_game), inputBuffer));
            commands.Add(Keys.Right, new MultipleCommand(new MoveRightCommand(_game), inputBuffer));
            commands.Add(Keys.Left, new MultipleCommand(new MoveLeftCommand(_game), inputBuffer));
            commands.Add(Keys.Up, new MultipleCommand(new MoveUpCommand(_game), inputBuffer));
            commands.Add(Keys.Down, new MultipleCommand(new MoveDownCommand(_game), inputBuffer));
            commands.Add(Keys.Z, new AttackCommand(_game));
            commands.Add(Keys.N, new AttackCommand(_game));
            commands.Add(Keys.B, new UseCurrentItemCommand(_game));
            commands.Add(Keys.Q, new QuitCommand(_game));
            commands.Add(Keys.R, new ResetCommand(_game));
            commands.Add(Keys.P, new PauseCommand(_game));
            commands.Add(Keys.M, new MenuCommand(_game));
            commands.Add(Keys.L, new GameOverCommand(_game));
            commands.Add(Keys.H, new KamehamehaCommand(_game));
            commands.Add(Keys.OemQuotes, new MuteCommand(_game));
            commands.Add(Keys.Space, new ShowAchievementsCommand(_game));
            commands.Add(Keys.V, new MuteCommand(_game));
            commands.Add(Keys.F, new PhaseCommand(_game));



            //Commands for when key is released.
            releaseCommands = new Dictionary<Keys, ICommand>();

            releaseCommands.Add(Keys.D, new FaceRightCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.A, new FaceLeftCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.W, new FaceUpCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.S, new FaceDownCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Right, new FaceRightCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Left, new FaceLeftCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Up, new FaceUpCommand(_game, MovementKeyIsDown));
            releaseCommands.Add(Keys.Down, new FaceDownCommand(_game, MovementKeyIsDown));

            //Commands for when game is in a menu.
            MenuCommands = new Dictionary<Keys, ICommand>();

            MenuCommands.Add(Keys.Q, new QuitCommand(_game));
            MenuCommands.Add(Keys.M, new UnMenuCommand(_game));
            MenuCommands.Add(Keys.D, new MoveSelectorRightCommand(_game));
            MenuCommands.Add(Keys.A, new MoveSelectorLeftCommand(_game));
            MenuCommands.Add(Keys.W, new MoveSelectorVerticalCommand(_game));
            MenuCommands.Add(Keys.S, new MoveSelectorVerticalCommand(_game));
            MenuCommands.Add(Keys.Right, new MoveSelectorRightCommand(_game));
            MenuCommands.Add(Keys.Left, new MoveSelectorLeftCommand(_game));
            MenuCommands.Add(Keys.Up, new MoveSelectorVerticalCommand(_game));
            MenuCommands.Add(Keys.Down, new MoveSelectorVerticalCommand(_game));
            MenuCommands.Add(Keys.V, new MuteCommand(_game));

            //Commands for when game is Paused.
            PauseCommands = new Dictionary<Keys, ICommand>();

            PauseCommands.Add(Keys.P, new PauseCommand(_game));
            PauseCommands.Add(Keys.Q, new QuitCommand(_game));


            TitleScreenCommands = new Dictionary<Keys, ICommand>();
            TitleScreenCommands.Add(Keys.Q, new QuitCommand(_game));
            TitleScreenCommands.Add(Keys.V, new MuteCommand(_game));

            NameRegistrationCommands = new Dictionary<Keys, ICommand>
            {
                { Keys.Right, new MoveNameCursorCommand(_game, 1, 0) },
                { Keys.Left, new MoveNameCursorCommand(_game, -1, 0) },
                { Keys.Up, new MoveNameCursorCommand(_game, 0, -1) },
                { Keys.Down, new MoveNameCursorCommand(_game, 0, 1) },
                { Keys.D, new MoveNameCursorCommand(_game, 1, 0) },
                { Keys.A, new MoveNameCursorCommand(_game, -1, 0) },
                { Keys.W, new MoveNameCursorCommand(_game, 0, -1) },
                { Keys.S, new MoveNameCursorCommand(_game, 0, 1) },
                { Keys.Enter, new SelectLetterCommand(_game) },
                { Keys.Back, new BackspaceLetterCommand(_game) },
                { Keys.Tab, new SwitchToOptionsCommand(_game) },
                { Keys.Q, new QuitCommand(_game) },
                { Keys.V, new MuteCommand(_game) }
            };

            AchievementScreenCommands = new Dictionary<Keys, ICommand>();
            AchievementScreenCommands.Add(Keys.Space, new ShowAchievementsCommand(_game));
            AchievementScreenCommands.Add(Keys.Escape, new ShowAchievementsCommand(_game));
            AchievementScreenCommands.Add(Keys.Q, new QuitCommand(_game));
            AchievementScreenCommands.Add(Keys.R, new ResetCommand(_game));
            AchievementScreenCommands.Add(Keys.V, new MuteCommand(_game));

            foreach (Keys key in NameRegistrationCommands.Keys)
            {
                keyPreviouslyPressed[key] = false;
            }

            foreach (Keys key in TitleScreenCommands.Keys)
            {
                keyPreviouslyPressed[key] = false;
            }

            foreach (Keys key in AchievementScreenCommands.Keys)
            {
                keyPreviouslyPressed[key] = false;
            }

            foreach (Keys key in commands.Keys)
            {
                keyPreviouslyPressed[key] = false;
            }

            foreach (Keys key in MenuCommands.Keys)
            {
                keyPreviouslyPressed[key] = false;
            }

            foreach (Keys key in PauseCommands.Keys)
            {
                keyPreviouslyPressed[key] = false;
            }
        }
        public void Update(GameTime gameTime)
        {
            var KeyboardState = Keyboard.GetState();
            

            //Uh oh! Ugly Game State handling!
            //Only executes commands for current game state (i.e. Paused or not)

            if (_game.currentGameState == GameState.GameStates.Pause)
            {
                foreach (var command in PauseCommands)
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

            if (_game.currentGameState == GameState.GameStates.TitleScreen || _game.currentGameState == GameState.GameStates.Dying || _game.currentGameState == GameState.GameStates.Winning || _game.currentGameState == GameState.GameStates.GameOver)
            {
                foreach (var command in TitleScreenCommands)
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

            else if (_game.currentGameState == GameState.GameStates.AchievementScreen)
            {
                foreach (var command in AchievementScreenCommands)
                {
                    Keys key = command.Key;
                    bool isKeyDown = KeyboardState.IsKeyDown(key);

                    if (isKeyDown && !keyPreviouslyPressed[key])
                    {
                        command.Value.Execute();
                    }

                    keyPreviouslyPressed[key] = isKeyDown;
                }
            }
            else if (_game.currentGameState == GameState.GameStates.NameRegistration)
            {
                foreach (var command in NameRegistrationCommands)
                {
                    Keys key = command.Key;
                    bool isKeyDown = KeyboardState.IsKeyDown(key);

                    if (isKeyDown && !keyPreviouslyPressed[key])
                    {
                        command.Value.Execute();
                    }

                    keyPreviouslyPressed[key] = isKeyDown;
                }
            }
            else if (_game.currentGameState == GameState.GameStates.Menu)
            {
                foreach (var command in MenuCommands)
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
            else {

                MovementKeyIsDown = KeyboardState.IsKeyDown(Keys.A) || KeyboardState.IsKeyDown(Keys.S) || KeyboardState.IsKeyDown(Keys.D) || KeyboardState.IsKeyDown(Keys.W) ||
                    KeyboardState.IsKeyDown(Keys.Right) || KeyboardState.IsKeyDown(Keys.Left) || KeyboardState.IsKeyDown(Keys.Down) || KeyboardState.IsKeyDown(Keys.Up);

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
            //End of Switch
            

           
        }
    }
}
