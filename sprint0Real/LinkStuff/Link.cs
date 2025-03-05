
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;
using sprint0Real;
using sprint0Real.LinkStuff;
public class Link : ILink
{
    private Rectangle destinationRectangle;
    private bool canMove;
    private bool canAttack;
    private bool isDamaged;
    private LinkStateMachine stateMachine;
    private ItemStateMachine itemStateMachine;
    private Color LinkSpriteColor;
    private Vector2 MomentumVector;

    public const int SPEED = 2;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }



    private Direction Facing;

    public Link(Game1 game)
	{
        destinationRectangle = new Rectangle(200, 200, 50, 50);
        canMove = true;
        canAttack = true;
        Facing = Direction.Right;
        //stateMachine = new LinkStateMachine(this);
        itemStateMachine = new ItemStateMachine(game);
        LinkSpriteColor = Color.White;
        isDamaged = false;
        MomentumVector = new Vector2(0, 0);
    }
    public void Damaged()
    {
            
    }

    public Color GetLinkColor()
    {
        return LinkSpriteColor;
    }

    public void SetLinkColor(Color color)
    {
        LinkSpriteColor = color;
    }

    //ItemStateMachine
    public void SetItem(int num, Game1 game)
    {
        itemStateMachine.SetItem(num,game);
    }
    public void DrawWeaponSprite()
    {
        itemStateMachine.DrawWeaponSprite();
    }

    //Moves Link's rendering rectangle in one of four directions
    public void MoveInDirection(Direction dir)
    {
        
        if (canMove)
        {
            switch (dir)
            {
                //case Direction.Up:
                //    destinationRectangle.Offset(0, -SPEED);
                //break;
                //case Direction.Down:
                //    destinationRectangle.Offset(0, SPEED);
                //break;
                //case Direction.Left:
                //    destinationRectangle.Offset(-SPEED, 0);
                //break;
                //case Direction.Right:
                //    destinationRectangle.Offset(SPEED, 0);
                //break;

                case Direction.Up:
                    MomentumVector = new Vector2(0, -SPEED);
                    break;
                case Direction.Down:
                    MomentumVector = new Vector2(0, SPEED);
                    break;
                case Direction.Left:
                    MomentumVector = new Vector2(-SPEED, 0);
                    break;
                case Direction.Right:
                    MomentumVector = new Vector2(SPEED, 0);
                    break;
            }   
        }
    }

    //Applies movement from momentum as final update action
    public void ApplyMomentum()
    {
        destinationRectangle.Offset(MomentumVector);
        MomentumVector = new Vector2(0, 0);

    }

    //Used to handle collision
    public void SetMomentumInDirection(Direction dir, bool IsMoving)
    {   

        switch (dir)
        {
            case Direction.Up:
                if (MomentumVector.Y < 0)
                {
                    MomentumVector = new Vector2(MomentumVector.X, 0);
                }
                break;
            case Direction.Down:
                if (MomentumVector.Y > 0)
                {
                    MomentumVector = new Vector2(MomentumVector.X, 0);
                }
                break;
            case Direction.Left:
                if (MomentumVector.X < 0)
                {
                    MomentumVector = new Vector2(0, MomentumVector.Y);
                }
                break;
            case Direction.Right:
                if (MomentumVector.X > 0)
                {
                    MomentumVector = new Vector2(0, MomentumVector.Y);
                }
                break;
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

    // Make the compiler happy
    public void NextItem()
    {
    }

    public void LastItem()
    {
    }

    public void DamageLink()
    {
    
    }

    public bool IsDamaged()
    {
        return isDamaged;
    }

    public void SetIsDamaged(bool ToDamage)
    {
        isDamaged = ToDamage;
    }
    public Rectangle Rect
    {
        get { return destinationRectangle; }
    }
}
