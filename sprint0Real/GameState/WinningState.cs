using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.LinkStuff.LinkSprites;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;
using sprint0Real;
using sprint0Real.Levels;
using Microsoft.Xna.Framework.Media;
using sprint0Real.GameState.NameRegistrationandAchievements;

internal class WinningState
{
    private int screenWidth;
    private int screenHeight;
    private int blackBarWidth;
    private int maxBarWidth;
    private float animationSpeed = 1.5f;

    private bool isFinished;
    private Texture2D blackTexture;
    private Texture2D whiteTexture;
    private Texture2D linksheet;
    private PickUpSprite pickUpSprite;
    private Triforce triforce;
    private Game1 game;
    private SpriteFont winFont;

    private Texture2D SpriteSheet;


    private double animationElapsedTime = 0;
    private const double animationTotalDuration = 8; 
    private bool hasReset = false;

    // Flash 
    private double flashDuration = 0.2;
    private int numFlashes = 6;
    private double flashElapsedTime = 0;

    public WinningState(Game1 game, Texture2D _texture)
    {
        this.game = game;
        this.linksheet = game.linkSheet;

        screenWidth = game.GraphicsDevice.Viewport.Width;
        screenHeight = game.GraphicsDevice.Viewport.Height;
        blackBarWidth = 0;
        maxBarWidth = screenWidth / 2;

        blackTexture = new Texture2D(game.GraphicsDevice, 1, 1);
        blackTexture.SetData(new[] { Color.Black });

        whiteTexture = new Texture2D(game.GraphicsDevice, 1, 1); 
        whiteTexture.SetData(new[] { Color.White });         

        pickUpSprite = new PickUpSprite(linksheet, game);

        Rectangle linkPos = pickUpSprite.GetDestinationRectangle();
        Vector2 triforcePos = new Vector2(
           linkPos.X + (linkPos.Width - 30) / 2,
           linkPos.Y - 30
        );
        triforce = new Triforce(triforcePos);
        winFont = game.Content.Load<SpriteFont>("WinFont");

        SpriteSheet = _texture;
    }

    public void Update(GameTime gameTime)
    {
        pickUpSprite.Update(gameTime, null);
        AchievementManager.Unlock("Dungeon Complete!");
        Rectangle linkPos = pickUpSprite.GetDestinationRectangle();

        Vector2 triforcePos = new Vector2(
            linkPos.X + (linkPos.Width - 30) / 2,
            linkPos.Y - 30
        );
        triforce.SetPosition(triforcePos);

        triforce.Update(gameTime);

        animationElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        flashElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

        // Curtain animation starts only after flashing is done
        if (!isFinished && flashElapsedTime >= flashDuration * numFlashes)
        {
            blackBarWidth += (int)(animationSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10);
            if (blackBarWidth >= maxBarWidth)
            {
                blackBarWidth = maxBarWidth;
                isFinished = true;
            }
        }

        if (animationElapsedTime >= animationTotalDuration && !hasReset)
        {
            hasReset = true;
            MediaPlayer.Stop();
            game.ResetGame();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);

        bool isFlashingPhase = flashElapsedTime < flashDuration * numFlashes;
        bool showWhiteFlash = isFlashingPhase && ((int)(flashElapsedTime / flashDuration) % 2 == 0);

        // Draw background
        CurrentMap.Instance.DrawBackground(spriteBatch, Vector2.Zero);

       
        if (!isFlashingPhase)
        {
            spriteBatch.Draw(blackTexture, new Rectangle(0, 0, blackBarWidth, screenHeight), Color.Black);
            spriteBatch.Draw(blackTexture, new Rectangle(screenWidth - blackBarWidth, 0, blackBarWidth, screenHeight), Color.Black);
        }

        pickUpSprite.Draw(spriteBatch);
        triforce.Draw(spriteBatch);

        // Draw white flash
        if (showWhiteFlash)
        {
            spriteBatch.Draw(whiteTexture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
        }
        if (isFinished)
        {
            string message = "YOU WON!";
            Vector2 size = winFont.MeasureString(message);
            Vector2 position = new Vector2(
                (screenWidth - size.X) / 2,
                (screenHeight - size.Y) / 2
            );
            spriteBatch.Draw(SpriteSheet, new Rectangle(Game1.SCREENMIDX - 82 * Game1.RENDERSCALE, Game1.SCREENMIDY - 4 * Game1.RENDERSCALE, 164 * Game1.RENDERSCALE, 9 * Game1.RENDERSCALE), new Rectangle(258, 98, 164, 9), Color.White);

        }
        spriteBatch.End();
    }
}