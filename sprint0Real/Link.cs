
﻿using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Commands;
using System;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real;
using sprint0Real.LinkSprites;
public class Link : ILink
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private bool canMove;
    private bool canAttack;
    private LinkStateMachine stateMachine;
    private ItemStateMachine itemStateMachine;

    public const int SPEED = 2;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    

    
    private Direction Facing;

    public Link()
	{
        sourceRectangle = new Rectangle(1, 11, 16, 16);
        destinationRectangle = new Rectangle(200, 200, 50, 50);
        canMove = true;
        canAttack = true;
        Facing = Direction.Right;
        stateMachine = new LinkStateMachine();
        itemStateMachine = new ItemStateMachine();
    }
    public void Damaged()
    {
            stateMachine.Damaged();
    }

    //ItemStateMachine
    public void SetItem()
    {
        itemStateMachine.SetItem();
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

    public Rectangle GetLocation()
    {
        return destinationRectangle;
    }

    public void SetLocation(Rectangle rectangle)
    {
        destinationRectangle = rectangle;
    }

    public bool CanMove()
    {
        return canMove;
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }

    public bool CanAttack()
    {
        return canAttack;
    }

    public void SetCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }

    public Direction GetFacing()
    {
        return Facing;
    }

    public void SetFacing(Direction facing)
    {
        Facing = facing;
    }
}
