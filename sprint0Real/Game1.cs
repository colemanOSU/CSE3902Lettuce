using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.EnemyStuff;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;
using System.Collections.Generic;

namespace sprint0Real
{
    public class Game1 : Game
    {  
        private static Game1 instance = new Game1();
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        Texture2D marioSheet;
        Texture2D blockSheet;
        
        SpriteFont font1;
        public int currentBlockIndex;

        public ILink Link = new Link();
        public ILinkSprite linkSprite;
        public EnemyPage enemyPage;

        public Texture2D linkSheet;

        //temp
        public IItem tempItem;
        //temp

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            currentBlockIndex = 1;
        }

        public static Game1 Instance
        {
            get { return instance; }
        }

        ISprite sprite = new StandingInPlacePlayer();
        public IBlock currentBlock;
        TextSprite text = new TextSprite();
        List<IControllerTemp> controllerList;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controllerList = new List<IControllerTemp>();
            controllerList.Add(new KeyboardControllerTemp(this));
            //controllerList.Add(new MouseController());

            base.Initialize();
        }
        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font1 = Content.Load<SpriteFont>("MyMenuFont");
            // TODO: use this.Content to load your game content here
            marioSheet = Content.Load<Texture2D>("mario");

            // State sprite factory
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            EnemyPage.Instance.AddEnemies();

            //Loading Block Content
            blockSheet = Content.Load<Texture2D>("Dungeon_Tileset");
            currentBlock = new BlockSprite1(blockSheet);

            linkSheet = Content.Load<Texture2D>("Link");
            linkSprite = new FaceRightSprite(linkSheet, this);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            tempItem = null;
        }


        protected override void Update(GameTime gameTime)
        {

            foreach (IControllerTemp controller in controllerList)
            {
                //sprite = controller.Update(sprite);
                controller.Update(gameTime);

            }
            

            if ((Keyboard.GetState().IsKeyDown(Keys.D0) || Keyboard.GetState().IsKeyDown(Keys.NumPad0) || (Mouse.GetState().RightButton == ButtonState.Pressed)))
            {
                this.Exit();
            }
            
            EnemyPage.Instance.Update(gameTime);

            currentBlock.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();


            //TEMP ITEM
            if (tempItem != null)
            {
                tempItem.Draw(_spriteBatch);
            }

            currentBlock.Draw(_spriteBatch);
            sprite.Update(_spriteBatch, marioSheet);

            linkSprite.Update(gameTime, _spriteBatch);

            linkSprite.Draw(_spriteBatch);

            EnemyPage.Instance.Draw(_spriteBatch);

            text.Update(_spriteBatch, font1);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
