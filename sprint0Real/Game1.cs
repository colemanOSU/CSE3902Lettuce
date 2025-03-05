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

namespace sprint0Real
{
    public class Game1 : Game
    {  

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;


        public Texture2D linkSheet;
        Texture2D blockSheet;
        Texture2D itemSheet;
        
        SpriteFont font1;
        public int currentBlockIndex;
        public int currentItemIndex;

        private GameStates currentGameState;
        private TitleScreen titleScreen;

        public ILink Link;
        public ILinkSprite linkSprite;

        public ILinkSprite weaponItems;

        //temp
        public IItem tempItem;
        public IItemSprite itemSprite;

        //temp

        public IBlock currentBlock;
        public IItemtemp currentItem;

        List<IController> controllerList;

        public ILinkState LinkState;

        public ICollision CollisionChecker;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            currentBlockIndex = 1;
            Link = new Link(this);
            currentItemIndex = 1;
        }

        protected override void Initialize()
        {

            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            currentGameState = GameStates.TitleScreen;
            titleScreen = new TitleScreen();
            LinkState = new LinkStateMachine(this);
            CollisionChecker = new CollisionDetection();
            

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

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadGame(this);
            LevelLoader.Instance.LoadLevels();

            ResetGame();

            tempItem = null;
        }

        protected override void Update(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameStates.TitleScreen:
                    currentGameState = titleScreen.Update(gameTime, this);
                    break;

                case GameStates.GamePlay:

                    //TEMP
                    List<IGameObject> tempList = new List<IGameObject>();
                    tempList.Add(currentBlock);
                    tempList.Add(Link);
                    tempList.Add(currentItem);
                    CollisionChecker.UpdateRoomObjects(tempList);
                    //TEMP
                    //TODO: DELETE TEMPORARY CODE

                    foreach (IController controller in controllerList)
                     {
                         //sprite = controller.Update(sprite);
                         controller.Update(gameTime);

                     }
                     currentBlock.Update(gameTime);
                     currentItem.Update(gameTime);
                     LinkState.Update(gameTime);

                    //NOTE:
                    //I hate hate hate passing game as a parameter to so many things
                    //Will address when I have the time to
                    //Which is not right now
                     CollisionChecker.Update(gameTime, this);

                    Link.ApplyMomentum();

                    CurrentMap.Instance.Update(gameTime);

                    break;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (currentGameState)
            {
                case GameStates.TitleScreen:
                    titleScreen.Draw(_spriteBatch, GraphicsDevice);
                    break;

                case GameStates.GamePlay:
                 
                _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);


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
                currentItem.Draw(_spriteBatch);



                linkSprite.Update(gameTime, _spriteBatch);
                linkSprite.Draw(_spriteBatch);

                weaponItems.Update(gameTime,_spriteBatch);
                weaponItems.Draw(_spriteBatch);

                CurrentMap.Instance.Draw(_spriteBatch);

                _spriteBatch.End();

                        break;
            }

            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            this.titleScreen.isAnimating = false;
            currentGameState = GameStates.TitleScreen;

            currentBlock = new BlockSpriteFloorTile(blockSheet, new Vector2(300,300));
            currentItem = new Heart(itemSheet);
            linkSprite = new ResetLink(linkSheet, this);
            weaponItems = new NullSprite(linkSheet, this);
            currentBlockIndex = 1;
            Link = new Link(this);
            currentItemIndex = 1;
            LinkState = new LinkStateMachine(this);

            //Update with other objects in game...

        }
    }
}
