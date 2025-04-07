using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using System.Diagnostics;
using System;

//Word of Advice: I have spent too much time getting the camera to work
//and it has been fraught with peril. Edit at your own risk.

//NOTE: If you are going to try and use this class for level transitions,
//you'd best be—pardon my french—darn sure you know what you're doing and
//that it doesn't conflict with the menu transition.
//You may want to create a new camera just for the level seperate from
//the one used for the UI.

public class Camera
{
    public Vector2 Center { get; set; }
    public Vector2 target {  get; set; }
    private Vector2 _quarterScreen;
    public Vector2 GetTopLeft() => Center - _quarterScreen;

    private float CamSpeed = 12;
    public Camera()
    {
        _quarterScreen = new Vector2(Game1.SCREENWIDTH / 2, Game1.SCREENHEIGHT / 2);
    }

    //Moves camera a set distance towards target.
    //Returns true when camera reaches target. Best used in while loop
    //where MoveToward is continuously called until target is reached.

    //target is the center of the position you want the camera to move towards.
    public bool MoveToward(Vector2 target)
    {
        //figure out which direction to move the camera,
        //by subtracting the current location from the target's
        Vector2 differenceInPosition = target - Center;

        if ( Math.Abs(differenceInPosition.X) < CamSpeed && Math.Abs(differenceInPosition.Y) < CamSpeed) return true;

        differenceInPosition.Normalize();


        Center = new Vector2(Center.X + differenceInPosition.X * CamSpeed, Center.Y + differenceInPosition.Y * CamSpeed);

        return false;
    }
}


