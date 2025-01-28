using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata.Ecma335;

public class KeyboardController : IController
{
    enum PlayerSpriteState
    {
        StandingInPlacePlayer, RunningInPlacePlayer,
        DeadPlayerMovingUpAndDown, RunningLeftAndRightPlayer
    };
    PlayerSpriteState mySpriteState = PlayerSpriteState.StandingInPlacePlayer;
    int currentFrame = 0;
    int totalFrames = 1;
    int yPos = 0;
    int xPos = 0;
    bool movingUp = false;
    bool movingLeft = false;


    public ISprite Update(ISprite sprite)
    {


        if (Keyboard.GetState().IsKeyDown(Keys.Q) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
        {
            //this.Exit();
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1))
        {
            sprite = new StandingInPlacePlayer();
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.D2) || Keyboard.GetState().IsKeyDown(Keys.NumPad2))
        {

            sprite = new RunningInPlacePlayer();
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.D3) || Keyboard.GetState().IsKeyDown(Keys.NumPad3))
        {
            sprite = new DeadPlayerMovingUpAndDown();
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.D4) || Keyboard.GetState().IsKeyDown(Keys.NumPad4))
        {
            sprite = new RunningLeftAndRightPlayer();
        }

        
        return sprite;
    }
    
}
