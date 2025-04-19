using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using sprint0Real.Audio;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;
using System.Collections.Generic;

namespace sprint0Real.GameState
{
    internal class WinningState
    {
        private int screenWidth;
        private int screenHeight;
        private int blackBarWidth;
        private int maxBarWidth;
        private float animationSpeed = 5f;

        private bool isFinished;
        private Texture2D blackTexture;
        private Texture2D linksheet;
        private PickUpSprite pickUpSprite;
        private Triforce triforce;
        private Game1 game;

        private Rectangle sourceRect;

        private double animationElapsedTime = 0;
        private const double animationTotalDuration = 3.0; // seconds until game resets
        private bool hasReset = false;

        public WinningState(Game1 game)
        {
            this.game = game;
            this.linksheet = game.linkSheet;

            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;
            blackBarWidth = 0;
            maxBarWidth = screenWidth / 2;

            blackTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            blackTexture.SetData(new[] { Color.Black });

            Rectangle linkPos = game.Link.GetLocation();
            Vector2 triforcePos = new Vector2(
                linkPos.X + (linkPos.Width / 2) - 15,
                linkPos.Y - 32
            );

            triforce = new Triforce(triforcePos);
            pickUpSprite = new PickUpSprite(linksheet, game);
            if (MediaPlayer.State != MediaState.Playing)
            {
                SoundEffectFactory.Instance.PlaySong(SongType.Winning, true);
            }
        }

        public void Update(GameTime gameTime)
        {
            animationElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (!isFinished)
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
                game.ResetGame();
            }
            triforce.Update(gameTime);
            pickUpSprite.Update(gameTime, null); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);

            spriteBatch.Draw(blackTexture, new Rectangle(0, 0, blackBarWidth, screenHeight), Color.Black);
            spriteBatch.Draw(blackTexture, new Rectangle(screenWidth - blackBarWidth, 0, blackBarWidth, screenHeight), Color.Black);

            pickUpSprite.Draw(spriteBatch);
            triforce.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}