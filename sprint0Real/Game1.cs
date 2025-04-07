using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Items.ItemSprites;
using sprint0Real.Interfaces;
using System;
using sprint0Real.LinkStuff.LinkSprites;
using System.Collections.Generic;
using System.Diagnostics;
using sprint0Real.Controllers;
using sprint0Real.EnemyStuff;
using sprint0Real.GameState;
using sprint0Real.Collisions;
using sprint0Real.LinkStuff;
using sprint0Real.Levels;
using System.Reflection.Metadata;
using sprint0Real.LinkSprites;
using sprint0Real.Commands;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using sprint0Real.TreasureItemStuff;

namespace sprint0Real
{
    public class Game1 : Game
    {  

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        public Texture2D linkSheet;
        public Texture2D UISheet;

        SpriteFont font1;

        //TEMP SET PUBLIC UNTIL BETTER SOLUTION FOUND
        public GameStates currentGameState;
        public TitleScreen titleScreen;
        public GameOverUI GameOverScreen;
        public Song Dungeon;
        public Song GameOverMusic;

        public ILink Link;
        public ILinkSpriteTemp linkSprite;

        //For menus and UIs
        public UI UISprite;
        public MenuUI MenuUISprite;
        public IUI PauseUISprite;

        public ILinkSprite weaponItemsA;
        public ILinkSprite weaponItemsB;

        //temp
        public IItem tempItem;
        public IItemSprite itemSprite;

        List<IController> controllerList;

        public ILinkState LinkState;

        public CollisionDetection collisionDetection;
        public CollisionHandler collisionHandler;

        public ItemStateMachine itemStateMachine;

        //TEMP CAMERA
        public Camera _camera;
        public Vector2 CameraTarget;
        public bool InMenu;
        public Vector2 transitionOffset;

        private bool TempDying;

        private TimeSpan DyingTime;
        private TimeSpan Span;

        //The screen height is specifically calculated to match the original game's
        //Important for menu transitions to function properly.
        //The screen width is mostly arbitrary.


        //This number determines the scale at which sprites will load in on the coordinate plane
        //If I cared more we would have it set up so that everything renders on a 1:1 basis and
        //would simply zoom in the camera to size it as we pleased. Alas.
        public const int RENDERSCALE = 3;

        //As levels render relative to center of screen alongside camera transitions being
        //hardcoded numbers, I would not mess with these numbers unless you really know
        //what you're doing!

        //Someone didn't heed my comment. Woe!
        public const int SCREENHEIGHT = 240 * RENDERSCALE;
        public const int SCREENWIDTH = 256 * RENDERSCALE;
        public const int SCREENMIDX = SCREENWIDTH / 2;
        public const int SCREENMIDY = SCREENHEIGHT / 2;


        //TEMP PAUSE
        public bool isPaused;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            //Code to change resolution of game.

            _graphics.PreferredBackBufferWidth = SCREENWIDTH;
            _graphics.PreferredBackBufferHeight = SCREENHEIGHT;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Link = new Link(this); 

            //TEMP PAUSE
            isPaused = false;
            CameraTarget = new Vector2(SCREENMIDX, SCREENMIDY);
            InMenu = false;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = SCREENWIDTH;
            _graphics.PreferredBackBufferHeight = SCREENHEIGHT;
            _graphics.ApplyChanges();
            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            currentGameState = GameStates.TitleScreen;
            titleScreen = new TitleScreen();
            LinkState = new LinkStateMachine(Link);
            itemStateMachine = new ItemStateMachine(this, Link.GetInventory());
            collisionHandler = new CollisionHandler(this);
            collisionDetection = new CollisionDetection(this, collisionHandler);
            DropManager.Init(Link);


            base.Initialize();
            _camera = new Camera();
            _camera.Center = new Vector2(SCREENMIDX, SCREENMIDY);
        }

        protected override void LoadContent()
        {
            titleScreen.LoadContent(GraphicsDevice, Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            font1 = Content.Load<SpriteFont>("MyMenuFont");

           
            //Load Sprite Sheets
            linkSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Link");
            UISheet = Content.Load<Texture2D>("NES - The Legend of Zelda - HUD & Pause Screen");

            Dungeon = Content.Load<Song>("04 - Dungeon");
            GameOverMusic = Content.Load<Song>("07 - Game Over");

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadGame(this);
            SoundEffectFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            TreasureItemSpriteFactory.Instance.LoadAllTextures(Content);
            LevelLoader.Instance.LoadLevels();

            ResetGame();
            collisionHandler.LoadCommands();
            collisionDetection.Load(Link);
            tempItem = null;
            
            //Uncomment for a cacaphony 

            /*
            // For mp3 files use song
            Song song = Content.Load<Song>("01 - Intro");
            MediaPlayer.Play(song);
            // For .wav files use SoundEffect
            SoundEffect soundEffect = Content.Load<SoundEffect>("LOZ_Secret");
            // To make the soundEffect loop, make a soundEffectInstance
            SoundEffectInstance soundEffectInstance = soundEffect.CreateInstance();
            soundEffectInstance.IsLooped = true;
            soundEffectInstance.Play();
            */
        }

        protected override void Update(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameStates.TitleScreen:
                    currentGameState = titleScreen.Update(gameTime, this);
                    break;
                case GameStates.Dying:

                    break;
                case GameStates.GameOver:
                    MediaPlayer.Stop();
                    GameOverScreen.Update(gameTime, this);
                    foreach (IController controller in controllerList)
                    {
                        controller.Update(gameTime);

                    }
                    break;
                case GameStates.Pause:
                    foreach (IController controller in controllerList)
                    {
                        //sprite = controller.Update(sprite);
                        controller.Update(gameTime);

                    }
                    break;
                case GameStates.Menu:
                    foreach (IController controller in controllerList)
                    {
                        //sprite = controller.Update(sprite);
                        controller.Update(gameTime);
                        MenuUISprite.Update(gameTime, Link);
                        UISprite.Update(gameTime, Link);

                    }

                    break;

                case GameStates.MenuTransition:
                    MenuUISprite.Update(gameTime, Link);
                    UISprite.Update(gameTime, Link);
                    break;

                case GameStates.LevelTransition:

                    break;

                case GameStates.GamePlay:

                    if (MediaPlayer.Queue.ActiveSong != Dungeon)
                    {
                        MediaPlayer.Stop(); // Stop any currently playing song
                        MediaPlayer.Play(Dungeon);
                        MediaPlayer.IsRepeating = true; // Loop the dungeon music
                    }

                    itemStateMachine.setActive();
                    Link.Update(gameTime);

                    foreach (IController controller in controllerList)
                     {
                         //sprite = controller.Update(sprite);
                         controller.Update(gameTime);

                     }
                     LinkState.Update(gameTime);

                    //NOTE:
                    //I hate hate hate passing game as a parameter to so many things
                    //Will address when I have the time to
                    //Which is not right now
                     //CollisionChecker.Update(gameTime, this);

                    Link.ApplyMomentum();
                    collisionDetection.Update(gameTime);
                    CurrentMap.Instance.Update(gameTime);

                    if (Link.GetCurrentHealth() == 0) currentGameState = GameStates.Dying;

                    break;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Matrix transform;
            switch (currentGameState)
            {
                case GameStates.TitleScreen:
                    titleScreen.Draw(_spriteBatch, GraphicsDevice);
                    break;
                case GameStates.Dying:
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);

                    if (TempDying)
                    {
                        linkSprite = new DeathSprite(linkSheet, this);
                        DyingTime = TimeSpan.Zero;
                        MediaPlayer.Play(GameOverMusic);
                        TempDying = false;
                    }

                    DyingTime += gameTime.ElapsedGameTime;


                    linkSprite.Update(gameTime, _spriteBatch);
                    linkSprite.Draw(_spriteBatch);

                    if (TimeSpan.Compare(DyingTime, TimeSpan.FromSeconds(2.7)) != -1)
                    {
                        currentGameState = GameStates.GameOver;
                    }

                    _spriteBatch.End();
                    break;
                case GameStates.GameOver:
                    GameOverScreen.Draw(_spriteBatch);
                    break;
                case GameStates.Pause:
                    //We still want things to be drawn, just not updated
                    transform = Matrix.CreateTranslation(-_camera.GetTopLeft().X, -_camera.GetTopLeft().Y, 0);
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transform);
                    _camera.MoveToward(_camera.Center);


                    CurrentMap.Instance.Draw(_spriteBatch);
                    linkSprite.Draw(_spriteBatch);
                    UISprite.Draw(_spriteBatch);

                    PauseUISprite.Draw(_spriteBatch);

                    _spriteBatch.End();
                    break;
                case GameStates.MenuTransition:
                    //We still want things to be drawn, just not updated
                    transform = Matrix.CreateTranslation(-_camera.GetTopLeft().X, -_camera.GetTopLeft().Y, 0);
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transform);

                    if (_camera.MoveToward(CameraTarget))
                    {
                        currentGameState = (InMenu) ? GameStates.Menu : GameStates.GamePlay;
                    }

                    CurrentMap.Instance.Draw(_spriteBatch);
                    linkSprite.Draw(_spriteBatch);
                    UISprite.Draw(_spriteBatch);
                    MenuUISprite.Update(gameTime, Link);
                    MenuUISprite.Draw(_spriteBatch);

                    _spriteBatch.End();
                    break;
                case GameStates.LevelTransition:
                    //We still want things to be drawn, just not updated
                    transform = Matrix.CreateTranslation(-_camera.GetTopLeft().X, -_camera.GetTopLeft().Y, 0);
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transform);

                    if (_camera.MoveToward(_camera.target))
                    {
                        _camera.Center = new Vector2(SCREENMIDX, SCREENMIDY);
                        currentGameState = GameStates.GamePlay;
                    }

                    CurrentMap.Instance.DrawBackground(_spriteBatch, transitionOffset);
                    CurrentMap.Instance.DrawPreviousBackground(_spriteBatch);
                    _spriteBatch.End();

                    // Don't want an offset for the UI so a separate spriteBatch is used
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
                    UISprite.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;
                case GameStates.Menu:
                    //We still want things to be drawn, just not updated
                    transform = Matrix.CreateTranslation(-_camera.GetTopLeft().X, -_camera.GetTopLeft().Y, 0);
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transform);
                    _camera.MoveToward(_camera.Center);

                    CurrentMap.Instance.Draw(_spriteBatch);
                    linkSprite.Draw(_spriteBatch);
                    UISprite.Draw(_spriteBatch);

                    MenuUISprite.Update(gameTime, Link);
                    MenuUISprite.Draw(_spriteBatch);

                    _spriteBatch.End();
                    break;
                case GameStates.GamePlay:
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
                    CurrentMap.Instance.Draw(_spriteBatch);

                    if (itemSprite != null)
                    {
                        itemSprite.Draw(_spriteBatch);
                        itemSprite.Update(gameTime, _spriteBatch);
                    }
                    linkSprite.Update(gameTime, _spriteBatch);
                    linkSprite.Draw(_spriteBatch);

                    UISprite.Update(gameTime, Link);
                    UISprite.Draw(_spriteBatch);

                    _spriteBatch.End();

                    base.Draw(gameTime);
                    break;
            }
        }

        public void ResetGame()
        {
           
            this.titleScreen.isAnimating = false;
            currentGameState = GameStates.TitleScreen;

            CurrentMap.Instance.SetMap(LevelLoader.Instance.RetrieveMap("Entrance"));

            linkSprite = new ResetLink(linkSheet, this);
            Link = new Link(this);
            collisionDetection.Load(Link);
            LinkState = new LinkStateMachine(Link);
            UISprite = new UI(UISheet, Link);
            MenuUISprite = new MenuUI(UISheet);
            PauseUISprite = new PauseUI(UISheet);
            GameOverScreen = new GameOverUI(UISheet);

            weaponItemsA = new NullSprite(linkSheet, this);
            weaponItemsB = new NullSprite(linkSheet, this);

            TempDying = true;

            DyingTime = TimeSpan.Zero;

            collisionDetection.UpdateRoomObjects();
            

        }

        public void MuteMusic()
        {
            MediaPlayer.Stop();
        }
    }

}
