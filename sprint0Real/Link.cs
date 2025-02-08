using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Commands;
using System;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
public class Link : ILink
{
    public Rectangle sourceRectangle;
    public Rectangle destinationRectangle;
    public bool canMove;
    public const int SPEED = 2;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Link()
	{
        sourceRectangle = new Rectangle(1, 11, 16, 16);
        destinationRectangle = new Rectangle(200, 200, 16, 16);
        canMove = true;
    }

    //Moves Link's rendering rectangle in one of four directions
    public void MoveInDirection(Direction dir)
    {
        
        if (canMove)
        {
            switch (dir)
            {
                case Direction.Up:
                    destinationRectangle.Offset(0, -SPEED);
                break;
                case Direction.Down:
                    destinationRectangle.Offset(0, SPEED);
                break;
                case Direction.Left:
                    destinationRectangle.Offset(-SPEED, 0);
                break;
                case Direction.Right:
                    destinationRectangle.Offset(SPEED, 0);
                break;
            }   
        }
    }

    public Rectangle getLocation()
    {
        return destinationRectangle;
    }

    public void setLocation(Rectangle rectangle)
    {
        destinationRectangle = rectangle;
    }

}
