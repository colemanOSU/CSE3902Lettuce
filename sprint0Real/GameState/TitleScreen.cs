using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Xna.Framework.Media;

namespace sprint0Real.GameState
{
    //NOTE FROM KELLY:
    //I absolutely adore that we're emulating the visual deloading in the title screen
    //as it would be if it ran on the NES. How whimsical.

    public class TitleScreen
    {
        
        private KeyboardState currentKeyState;
        private KeyboardState previousKeyState;
        private MouseState mouseState;
        private int frameCount = 4;
        private float _frameSpeed = 0.2f;
        private int _currentFrame = 0;
        private Texture2D title;
        private Song introSong;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public bool isAnimating = false;
        private double _timer = 0;
        Game1 _game;
        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            title = content.Load<Texture2D>("TitleScreen");
            introSong = content.Load<Song>("01 - Intro");

        }

        public GameStates Update(GameTime gameTime, Game1 game)
        {
            currentKeyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            _game = game;

            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(introSong);
                MediaPlayer.IsRepeating = true; // Keep it looping if desired
            }

            if (currentKeyState.IsKeyDown(Keys.Q))
            {
                _game.Exit();
            }
            //TEST REMOVE
            if (currentKeyState.IsKeyDown(Keys.R) && previousKeyState.IsKeyUp(Keys.R))
            {
                return GameStates.NameRegistration;
            }


            if (!isAnimating && currentKeyState.IsKeyDown(Keys.Enter) && previousKeyState.IsKeyUp(Keys.Enter) || !isAnimating && mouseState.LeftButton == ButtonState.Pressed)
            {
                isAnimating = true;
            }

                if (isAnimating)
                {
                    _timer += gameTime.ElapsedGameTime.TotalSeconds;

                    if (_timer >= _frameSpeed)
                    {
                        _currentFrame++;
                        _timer -= _frameSpeed;
                    }

                    if (_currentFrame >= frameCount)
                    {
                    _currentFrame = 0;
                    MediaPlayer.Stop();
                    return GameStates.GamePlay;
                }
                }
            
            previousKeyState = currentKeyState;

            return GameStates.TitleScreen;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            if(_currentFrame == 3)
            {
                graphicsDevice.Clear(Color.Black);
            }
            else
            {
                sourceRectangle = new Rectangle(1 + 257 * _currentFrame, 11, 256, 224);
                destinationRectangle = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
                spriteBatch.Draw(title, destinationRectangle, sourceRectangle, Color.White);

            }
            spriteBatch.End();
        }
    }
}