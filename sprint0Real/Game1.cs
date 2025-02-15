using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Items.ItemSprites;
using sprint0Real.Interfaces;
using System;
using sprint0Real.LinkSprites;
using System.Collections.Generic;
using System.Diagnostics;
using sprint0Real.Controllers;
using sprint0Real.EnemyStuff;
using sprint0Real.ItemTempSprites;

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


        public ILink Link;
        public ILinkSprite linkSprite;

        public ILinkSprite weaponItems;

        //temp
        public IItem tempItem;
        //temp

        public EnemyCycleExample EnemyCycle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            currentBlockIndex = 1;
            Link = new Link(this);
            currentItemIndex = 1;
        }

        public IBlock currentBlock;
        public IItemtemp currentItem;
        
        TextSprite text = new TextSprite();
        List<IController> controllerList;

        public ILinkState LinkState;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            //controllerList.Add(new MouseController());

            LinkState = new LinkStateMachine(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            font1 = Content.Load<SpriteFont>("MyMenuFont");
            // TODO: use this.Content to load your game content here
           
            //Loading Block Content
            blockSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            currentBlock = new BlockSpriteFloorTile(blockSheet);

            //Loading Item Content
            itemSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons");
            currentItem = new Heart(itemSheet);

            linkSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Link");
            linkSprite = new FaceRightSprite(linkSheet, this);
            weaponItems = new NullSprite(linkSheet, this);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadGame(this);
            EnemyCycle = new EnemyCycleExample();

            // Don't need EnemyPage yet
            // EnemyPage.Instance.AddEnemies();

            tempItem = null;
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (IController controller in controllerList)
            {
                //sprite = controller.Update(sprite);
                controller.Update(gameTime);

            }

            currentBlock.Update(gameTime);
            currentItem.Update(gameTime);
            LinkState.Update(gameTime);
            

            //EnemyPage.Instance.Update(gameTime);
            EnemyCycle.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);


            //TEMP ITEM
            if (tempItem != null)
            {
                tempItem.Draw(_spriteBatch);
            }

            currentBlock.Draw(_spriteBatch);
            currentItem.Draw(_spriteBatch);
            //text.Update(_spriteBatch, font1);

            linkSprite.Update(gameTime, _spriteBatch);

            linkSprite.Draw(_spriteBatch);
            weaponItems.Update(gameTime,_spriteBatch);
            weaponItems.Draw(_spriteBatch);

            //EnemyPage.Instance.Draw(_spriteBatch);
            EnemyCycle.Draw(_spriteBatch);

            text.Update(_spriteBatch, font1);
            _spriteBatch.End();

            

            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            currentBlock = new BlockSpriteFloorTile(blockSheet);
            currentItem = new Heart(itemSheet);
            linkSprite = new ResetLink(linkSheet, this);
            EnemyCycle = new EnemyCycleExample();
            currentBlockIndex = 1;
            Link = new Link(this);
            currentItemIndex = 1;
            LinkState = new LinkStateMachine(this);
            //Update with other objects in game...

        }
    }
}
