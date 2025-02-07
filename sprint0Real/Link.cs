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
    //public const int Speed = 2;

    public Link()
	{
        sourceRectangle = new Rectangle(1, 11, 16, 16);
        destinationRectangle = new Rectangle(200, 200, 16, 16);
        canMove = true;
    }


    public void MoveRight()
    {
        sourceRectangle = new Rectangle(35, 11, 16, 16);
        if (canMove)
        {
            destinationRectangle.Offset(1, 0);
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
