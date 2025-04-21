
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;
using sprint0Real;
using sprint0Real.LinkStuff;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using sprint0Real.LinkStuff.LinkSprites;
using System.Security.Cryptography;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.WolfLink;
using sprint0Real.Audio;
public class Link : ILink
{
    private Rectangle destinationRectangle;
    private bool canMove;
    private bool canAttack;
    private bool isDamaged;
    public bool isPhaseActive;
    private LinkStateMachine stateMachine;
    private ItemStateMachine itemStateMachine;
    private Color LinkSpriteColor;
    private Vector2 MomentumVector;
    public Texture2D linkSheet;
    private int actualSpeed;

    public Inventory inventory;
    private int MaxHealth { get; set; }
    private int CurrentHealth { get; set; }

    public const int SPEED = 4;

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
        destinationRectangle = new Rectangle(200, 300, 50, 50);
        canMove = true;
        canAttack = true;
        Facing = Direction.Right;
        stateMachine = new LinkStateMachine(this);
        LinkSpriteColor = Color.White;
        isDamaged = false;
        isPhaseActive = false;
        MomentumVector = new Vector2(0, 0);
        inventory = new Inventory();
        itemStateMachine = new ItemStateMachine(game, inventory);
        MaxHealth = 8;
        CurrentHealth = MaxHealth;
        
    }
    public void TakeDamage()
    {
        if (!isDamaged) //Avoid Damage if already in damageed state
        {
            isDamaged = true;
            stateMachine?.DamageLink();
            SoundEffectFactory.Instance.Play(SoundEffectType.linkHurt);
        }
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

    public void DrawFireball()
    {
        itemStateMachine.DrawFireball();
    }
    public void DrawItemSprite()
    {
        itemStateMachine.DrawItemSprite();
    }

    //Moves Link's rendering rectangle in one of four directions
    public void MoveInDirection(Direction dir)
    {
        
        if (canMove)
        {
            actualSpeed = SPEED;
            if (Wolf.Instance.isUsed())
            {
                actualSpeed = (int)(SPEED * 1.5f); 
            }

            switch (dir)
            {
                case Direction.Up:
                    MomentumVector = new Vector2(0, -actualSpeed);
                    break;
                case Direction.Down:
                    MomentumVector = new Vector2(0, actualSpeed);
                    break;
                case Direction.Left:
                    MomentumVector = new Vector2(-actualSpeed, 0);
                    break;
                case Direction.Right:
                    MomentumVector = new Vector2(actualSpeed, 0);
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
    public void StopMomentumInDirection(Direction dir)
    {   
        
        switch (dir)
        {
            case Direction.Up:
                if (MomentumVector.Y > 0)
                {
                    MomentumVector = new Vector2(MomentumVector.X, 0);
                }
                break;
            case Direction.Down:
                if (MomentumVector.Y < 0)
                {
                    MomentumVector = new Vector2(MomentumVector.X, 0);
                }
                break;
            case Direction.Left:
                if (MomentumVector.X > 0)
                {
                    MomentumVector = new Vector2(0, MomentumVector.Y);
                }
                break;
            case Direction.Right:
                if (MomentumVector.X < 0)
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
    public bool IsPhaseActive()
    {
        return isPhaseActive;
    }
    public void SetIsDamaged(bool ToDamage)
    {
        isDamaged = ToDamage;
    }
    public Rectangle Rect
    {
        get { return destinationRectangle; }
    }

    public void Update(GameTime gameTime)
    {
        itemStateMachine.UpdateEquippedItems(gameTime);
        //need to update IGameObject
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        //need to draw IGameObject
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public int GetCurrentHealth()
    {
        return CurrentHealth;
    }

    public void OffsetCurrentHealth(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        if (CurrentHealth < 0) CurrentHealth = 0;
    }

    public int GetMaxHealth()
    {
        return MaxHealth;
    }

    public void SetMaxHealth(int amount)
    {
        MaxHealth = amount;
    }
    public void RestoreAllHealth()
    {
        CurrentHealth = MaxHealth;
    }
    public void SwitchPhaseActive()
    {
        isPhaseActive = !isPhaseActive;
    }
}
