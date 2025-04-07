using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.GameState;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real
{
    public class GameStateMachine
    {
        public GameStates currentGameState;
        private Game1 myGame;
        private bool InMenu = false;
        public GameStateMachine(Game1 game) {
            myGame = game;
        }
        public void Update()
        {
            /**
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

                    collisionDetection.Update(gameTime);

                    //NOTE:
                    //I hate hate hate passing game as a parameter to so many things
                    //Will address when I have the time to
                    //Which is not right now
                     //CollisionChecker.Update(gameTime, this);

                    Link.ApplyMomentum();
                    CurrentMap.Instance.Update(gameTime);
                    

                    break;
            }
            **/
        }

        public void Draw()
        {
            /**
            Matrix transform;
            switch (currentGameState)
            {
                case GameStates.TitleScreen:
                    titleScreen.Draw(_spriteBatch, GraphicsDevice);
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
                        currentGameState = GameStates.GamePlay;
                    }

                    CurrentMap.Instance.Draw(_spriteBatch);
                    linkSprite.Draw(_spriteBatch);
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
                    transform = Matrix.CreateTranslation(-_camera.GetTopLeft().X, -_camera.GetTopLeft().Y, 0);
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transform);
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
                    linkSprite.Update(gameTime, _spriteBatch);
                    linkSprite.Draw(_spriteBatch);

                    UISprite.Update(gameTime, Link);
                    UISprite.Draw(_spriteBatch);

                    _spriteBatch.End();

                    break;
                    
            }
            **/
        }
        /**
        public void RoomTransition()
        {
            if (currentGameState == GameStates.LevelTransition)
            {
                currentGameState = GameStates.GamePlay;
            }
            else
            {
                currentGameState = 
            }
        }
        public void MenuTransition()
        {
            if (currentGameState == GameStates.Menu)
            {
                InMenu = true;
            }
            else
            {
                InMenu = false;
            }
        }**/
    }
}
