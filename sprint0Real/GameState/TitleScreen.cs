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
namespace sprint0Real.GameState
{

    internal class TitleScreen
    {
        
        private KeyboardState currentKeyState;
        private KeyboardState previousKeyState;
        private int frameCount = 4;
        private float _frameSpeed = 0.2f;
        private int _currentFrame = 0;
        private Texture2D title;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public bool isAnimating = false;
        private double _timer = 0;
        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            title = content.Load<Texture2D>("TitleScreen");
        }

        public GameStates Update(GameTime gameTime)
        {
            currentKeyState = Keyboard.GetState();

            if (!isAnimating && currentKeyState.IsKeyDown(Keys.Enter) && previousKeyState.IsKeyUp(Keys.Enter))
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
                    return GameStates.GamePlay;
                }
                }
            
            previousKeyState = currentKeyState;

            return GameStates.TitleScreen;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Begin();

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