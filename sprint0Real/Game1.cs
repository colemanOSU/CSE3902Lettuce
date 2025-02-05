using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;
using System.Collections.Generic;

namespace sprint0Real
{
    public class Game1 : Game
    {  
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D marioSheet;
        Texture2D blockSheet;
        SpriteFont font1;
        public int currentBlockIndex;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            currentBlockIndex = 1;
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

            //Loading Block Content
            blockSheet = Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            currentBlock = new BlockSprite1(blockSheet);
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
            

            currentBlock.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            string output = "Credits:\nProgram Made By: Kelly Coleman\n Sprites from: https://www.spriters-resource.com/nes/supermariobros/sheet/50365/";

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            currentBlock.Draw(_spriteBatch);
            sprite.Update(_spriteBatch, marioSheet);
            text.Update(_spriteBatch, font1);
            _spriteBatch.End();

            

            base.Draw(gameTime);
        }
    }
}
