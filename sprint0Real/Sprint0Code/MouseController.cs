/*using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

public class MouseController : IController
{
	public ISprite Update(ISprite sprite)
	{
        MouseState mouse = Mouse.GetState();
        if (Mouse.GetState().RightButton == ButtonState.Pressed)
        {
            sprite = new DeadPlayerMovingUpAndDown();
            //this.Exit();
        }
        else if (Mouse.GetState().X < 200 && Mouse.GetState().Y < 200 && (mouse.LeftButton == ButtonState.Pressed))
        {
            sprite = new StandingInPlacePlayer();
        }
        else if (Mouse.GetState().X > 200 && Mouse.GetState().Y < 200 && (mouse.LeftButton == ButtonState.Pressed))
        {

            sprite = new RunningInPlacePlayer();
        }
        else if (Mouse.GetState().X > 200 && Mouse.GetState().Y > 200 && (mouse.LeftButton == ButtonState.Pressed))
        {
            sprite = new DeadPlayerMovingUpAndDown();
        }
        else if (Mouse.GetState().X < 200 && Mouse.GetState().Y > 200 && (mouse.LeftButton == ButtonState.Pressed))
        {
            sprite = new RunningLeftAndRightPlayer();
        }

        return sprite;
	}
}
*/