using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff;
using System.Diagnostics;


public class UI : IUI
{
    private Texture2D UITexture;
    private Rectangle DestinationRectangle;
    private Rectangle SourceRectangle;
    private int Scale = Game1.RENDERSCALE;
    private int UIXCoord;
    private int UIYCoord;
    private Rectangle[] RupeeDigits;
    private Rectangle[] KeyDigits;
    private Rectangle[] BombDigits;
    private Rectangle[] HealthBar;

    private ILink link;

    private Inventory.Swords CurrentSword;
    private Inventory.Items CurrentItem;
    public UI(Texture2D uITexture, ILink link)
    {
        UIXCoord = Game1.SCREENMIDX - (128 * Scale);
        UIYCoord = Game1.SCREENMIDY - (88 * Scale) - 56 * Scale + 30 * Game1.RENDERSCALE;
        DestinationRectangle = new Rectangle(UIXCoord, UIYCoord, 256 * Scale, 56 * Scale);
        SourceRectangle = new Rectangle(258, 11, 256, 56);

        UITexture = uITexture;

        RupeeDigits = UIHelper.CounterHelper(00);
        KeyDigits = UIHelper.CounterHelper(00);
        BombDigits = UIHelper.CounterHelper(00);

        HealthBar = UIHelper.HealthbarHelper(link.GetMaxHealth(), link.GetCurrentHealth());
        this.link = link;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(UITexture, DestinationRectangle, SourceRectangle, Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord, UIYCoord - 8 * Scale, 256 * Scale, 8 * Scale), new Rectangle(258, 59, 256, 8), Color.White);

        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * Scale, UIYCoord + 16 * Scale, 8 * Scale, 8 * Scale), RupeeDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * Scale, UIYCoord + 16 * Scale, 8 * Scale, 8 * Scale), RupeeDigits[0], Color.White);

        
        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * Scale, UIYCoord + 32 * Scale, 8 * Scale, 8 * Scale), KeyDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * Scale, UIYCoord + 32 * Scale, 8 * Scale, 8 * Scale), KeyDigits[0], Color.White);

        
        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * Scale, UIYCoord + 40 * Scale, 8 * Scale, 8 * Scale), BombDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * Scale, UIYCoord + 40 * Scale, 8 * Scale, 8 * Scale), BombDigits[0], Color.White);

        //Health Bar
        for (int i = 0; i < link.GetMaxHealth() / 2; i++)
        {
            spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 176 * Scale + (i * 8 * Scale), UIYCoord + 32 * Scale, 8 * Scale, 8 * Scale), HealthBar[i], Color.White);
        }

        //Sword Sprite
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 152 * Scale, UIYCoord + 24 * Scale, 8 * Scale, 16 * Scale), new Rectangle(555 + ((int)CurrentSword) * 9, 137, 8, 16), Color.White);

        //Current Item Sprite
        //Don't bother rendering if no item is equipped
        if (CurrentItem != 0)
        {
            spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 128 * Scale, UIYCoord + 24 * Scale, 8 * Scale, 16 * Scale), UIHelper.ItemSpriteHelper(CurrentItem), Color.White);
        }
    }

    public void Update(GameTime gametime, ILink link)
    {
        Inventory inv = link.GetInventory();

        RupeeDigits = UIHelper.CounterHelper(inv.RupeeCount);
        KeyDigits = UIHelper.CounterHelper(inv.KeyCount);
        BombDigits = UIHelper.CounterHelper(inv.BombCount);



        HealthBar = UIHelper.HealthbarHelper(link.GetMaxHealth(), link.GetCurrentHealth());

        CurrentSword = inv.CurrentSword;
        CurrentItem = inv.CurrentItem;
    }
}


