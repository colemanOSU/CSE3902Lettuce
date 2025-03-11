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
using sprint0Real.ItemTempSprites;
using sprint0Real.GameState;
using sprint0Real.Collisions;
using sprint0Real.LinkStuff;
using sprint0Real.Levels;
using System.Reflection.Metadata;
using sprint0Real.TreasureItemSprites;
using sprint0Real.LinkSprites;
using sprint0Real.Commands;

namespace sprint0Real
{
    public class Game1 : Game
    {  

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        public Texture2D linkSheet;
        public Texture2D UISheet;

        Texture2D blockSheet;
        Texture2D itemSheet;
        
        SpriteFont font1;
        public int currentBlockIndex;
        public int currentItemIndex;

        //TEMP SET PUBLIC UNTIL BETTER SOLUTION FOUND
        public GameStates currentGameState;
        private TitleScreen titleScreen;

        public ILink Link;
        public ILinkSpriteTemp linkSprite;

        //For menus and UIs
        public IUI UISprite;
        public IUI MenuUISprite;

        public ILinkSprite weaponItems;

        //temp
        public IItem tempItem;
        public IItemSprite itemSprite;

        //temp

        public IBlock currentBlock;
        public IItemtemp currentItem;

        List<IController> controllerList;

        public ILinkState LinkState;

        public CollisionDetection collisionDetection;

        private ItemStateMachine itemStateMachine;

        //The screen height is specifically calculated to match the original game's height
        //Important for menu transitions to function properly.
        //The screen width is mostly arbitrary. 

        public const int SCREENHEIGHT = 912;
        public const int SCREENWIDTH = 1042;
        public const int SCREENMIDX = SCREENWIDTH / 2;
        public const int SCREENMIDY = SCREENHEIGHT / 2;
        public const int RENDERSCALE = 3;

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
            currentBlockIndex = 1;
            Link = new Link(this);  
            currentItemIndex = 1;

            //TEMP PAUSE
            isPaused = false;
        }

        protected override void Initialize()
        {

            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            currentGameState = GameStates.TitleScreen;
            titleScreen = new TitleScreen();
            LinkState = new LinkStateMachine(Link);
            itemStateMachine = new ItemStateMachine(this);

            //collisionDetection = new CollisionDetection(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            titleScreen.LoadContent(GraphicsDevice, Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            font1 = Content.Load<SpriteFont>("MyMenuFont");
           
            //Load Sprite Sheets
            blockSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            itemSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons");
            linkSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Link");
            UISheet = Content.Load<Texture2D>("NES - The Legend of Zelda - HUD & Pause Screen");

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadGame(this);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            TreasureItemSpriteFactory.Instance.LoadAllTextures(Content);
            LevelLoader.Instance.LoadLevels();

            ResetGame();
            collisionDetection.UpdateRoomObjects(CurrentMap.Instance.MapList(), Link, weaponItems);
            tempItem = null;
        }

        protected override void Update(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameStates.TitleScreen:
                    currentGameState = titleScreen.Update(gameTime, this);
                    break;
                case GameStates.Pause:
                    foreach (IController controller in controllerList)
                    {
                        //sprite = controller.Update(sprite);
                        controller.Update(gameTime);

                    }
                    break;
                case GameStates.GamePlay:

                    itemStateMachine.setActive();
                    //TEMP
                    /*
                    List<IGameObject> tempList = new List<IGameObject>();
                    tempList.Add(currentBlock);
                    tempList.Add(Link);
                    tempList.Add(currentItem);
                    CollisionChecker.UpdateRoomObjects(tempList);*/
                    //TEMP
                    //TODO: DELETE TEMPORARY CODE

                    foreach (IController controller in controllerList)
                     {
                         //sprite = controller.Update(sprite);
                         controller.Update(gameTime);

                     }
                     currentBlock.Update(gameTime);
                     //currentItem.Update(gameTime);
                     LinkState.Update(gameTime);

                    collisionDetection.Update(gameTime);
                    // Reset executed collisions to allow new collisions to be handled in the next frame
                    collisionDetection.ResetExecutedCollisions();

                    //NOTE:
                    //I hate hate hate passing game as a parameter to so many things
                    //Will address when I have the time to
                    //Which is not right now
                     //CollisionChecker.Update(gameTime, this);

                    Link.ApplyMomentum();
                    CurrentMap.Instance.Update(gameTime);

                    break;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            switch (currentGameState)
            {
                case GameStates.TitleScreen:
                 
                    titleScreen.Draw(_spriteBatch, GraphicsDevice);
                    break;

                case GameStates.Pause:
                    //We still want things to be drawn, just not updated
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
                    CurrentMap.Instance.Draw(_spriteBatch);

                    //TEMP ITEM
                    if (tempItem != null)
                    {
                        tempItem.Draw(_spriteBatch);
                    }

                    if (itemSprite != null)
                    {
                        itemSprite.Draw(_spriteBatch);
                    }

                    currentBlock.Draw(_spriteBatch);
                    //currentItem.Draw(_spriteBatch);
                    linkSprite.Draw(_spriteBatch);
                    UISprite.Draw(_spriteBatch);
                    MenuUISprite.Draw(_spriteBatch);

                    _spriteBatch.End();
                    break;
                case GameStates.GamePlay:
                    
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
                    CurrentMap.Instance.Draw(_spriteBatch);

                //TEMP ITEM
                if (tempItem != null)
                {
                    tempItem.Draw(_spriteBatch);
                }

                if (itemSprite != null)
                {
                    itemSprite.Draw(_spriteBatch);
                    itemSprite.Update(gameTime, _spriteBatch);
                }

                currentBlock.Draw(_spriteBatch);
                //currentItem.Draw(_spriteBatch);
                linkSprite.Update(gameTime, _spriteBatch);
                linkSprite.Draw(_spriteBatch);

                    UISprite.Update(gameTime, _spriteBatch);
                UISprite.Draw(_spriteBatch);

                    MenuUISprite.Update(gameTime, _spriteBatch);
                    MenuUISprite.Draw(_spriteBatch);

                    _spriteBatch.End();

                    break;
            }

            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            this.titleScreen.isAnimating = false;
            currentGameState = GameStates.TitleScreen;

            currentBlock = new BlockSpriteFloorTile(new Vector2(300,300));
            //currentItem = new Heart(new Vector2(0, 0));
            linkSprite = new ResetLink(linkSheet, this);
            UISprite = new UI(UISheet);
            MenuUISprite = new MenuUI(UISheet);
            weaponItems = new NullSprite(linkSheet, this);
            currentBlockIndex = 1;
            Link = new Link(this);
            currentItemIndex = 1;
            LinkState = new LinkStateMachine(Link);

            collisionDetection = new CollisionDetection(this);

            //Update with other objects in game...

        }
    }
}
