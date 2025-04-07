using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff;
using System;
using System.Diagnostics;


public class UI : IUI
{
    private Texture2D UITexture;
    private Rectangle DestinationRectangle;
    private readonly Rectangle SourceRectangle = new Rectangle(258, 11, 256, 56);

    private const int SCALE = Game1.RENDERSCALE;

    private int UIXCoord;
    private int UIYCoord;
    private Rectangle[] RupeeDigits;
    private Rectangle[] KeyDigits;
    private Rectangle[] BombDigits;
    private Rectangle[] HealthBar;

    private int CompassFrameCounter;
    private readonly Rectangle CompassRedSource = new Rectangle(537, 126, 3, 3);
    private readonly Rectangle CompassBlueSource = new Rectangle(546, 126, 3, 3);
    private Rectangle CompassSource;
    private readonly Rectangle CompassDestination;

    private ILink link;

    private readonly Rectangle LinkMarkerSource = new Rectangle(519, 126, 3, 3);
    private Point LinkMarkerOffset;

    private Inventory.Swords CurrentSword;
    private Inventory.Items CurrentItem;
    public UI(Texture2D uITexture, ILink link)
    {
        UIXCoord = Game1.SCREENMIDX - (128 * SCALE);
        UIYCoord = Game1.SCREENMIDY - (88 * SCALE) - 56 * SCALE + 30 * SCALE;
        DestinationRectangle = new Rectangle(UIXCoord, UIYCoord, 256 * SCALE, 56 * SCALE);

        UITexture = uITexture;

        RupeeDigits = UIHelper.CounterHelper(00);
        KeyDigits = UIHelper.CounterHelper(00);
        BombDigits = UIHelper.CounterHelper(00);

        HealthBar = UIHelper.HealthbarHelper(link.GetMaxHealth(), link.GetCurrentHealth());
        this.link = link;
        CompassDestination = new Rectangle(UIXCoord + 66 * SCALE, UIYCoord + 28 * SCALE, 3 * SCALE, 3 * SCALE);

        CompassSource = CompassBlueSource;
        CompassFrameCounter = 0;

        LinkMarkerOffset = new Point(0, 0);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(UITexture, DestinationRectangle, SourceRectangle, Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord, UIYCoord - 8 * SCALE, 256 * SCALE, 8 * SCALE), new Rectangle(258, 59, 256, 8), Color.White);

        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * SCALE, UIYCoord + 16 * SCALE, 8 * SCALE, 8 * SCALE), RupeeDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * SCALE, UIYCoord + 16 * SCALE, 8 * SCALE, 8 * SCALE), RupeeDigits[0], Color.White);

        
        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * SCALE, UIYCoord + 32 * SCALE, 8 * SCALE, 8 * SCALE), KeyDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * SCALE, UIYCoord + 32 * SCALE, 8 * SCALE, 8 * SCALE), KeyDigits[0], Color.White);

        
        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * SCALE, UIYCoord + 40 * SCALE, 8 * SCALE, 8 * SCALE), BombDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * SCALE, UIYCoord + 40 * SCALE, 8 * SCALE, 8 * SCALE), BombDigits[0], Color.White);

        //Health Bar
        for (int i = 0; i < link.GetMaxHealth() / 2; i++)
        {
            spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 176 * SCALE + (i * 8 * SCALE), UIYCoord + 32 * SCALE, 8 * SCALE, 8 * SCALE), HealthBar[i], Color.White);
        }

        //Sword Sprite
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 152 * SCALE, UIYCoord + 24 * SCALE, 8 * SCALE, 16 * SCALE), new Rectangle(555 + ((int)CurrentSword) * 9, 137, 8, 16), Color.White);

        //Current Item Sprite
        //Don't bother rendering if no item is equipped
        if (CurrentItem != 0)
        {
            spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 128 * SCALE, UIYCoord + 24 * SCALE, 8 * SCALE, 16 * SCALE), UIHelper.ItemSpriteHelper(CurrentItem), Color.White);
        }

        if (link.GetInventory().HasMap)
        {
            spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 16 * SCALE, UIYCoord + 8 * SCALE, 64 * SCALE, 40 * SCALE), new Rectangle(650, 1, 64, 40), Color.White);
        }

        if (link.GetInventory().HasCompass)
        {
            spriteBatch.Draw(UITexture, CompassDestination, CompassSource, Color.White);
        }

        //Draw Link's marker on the map
        //Is drawn even if the Map is not obtained
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + (42 + 8 * LinkMarkerOffset.X) * SCALE, UIYCoord + (44 - 4 * LinkMarkerOffset.Y) * SCALE, 3 * SCALE, 3 * SCALE), LinkMarkerSource, Color.White);


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

        if (inv.HasCompass)
        {
            if (CompassFrameCounter >= 32) CompassFrameCounter = 0;
            CompassFrameCounter++;
            CompassSource = (CompassFrameCounter / 16 == 0) ? CompassBlueSource : CompassRedSource;
        }
    }

    public void MoveLinkMapMarker(Link.Direction direction)
    {
        switch (direction)
        {
            case Link.Direction.Up:
                LinkMarkerOffset = new Point(LinkMarkerOffset.X, LinkMarkerOffset.Y + 1);
                break;
            case Link.Direction.Down:
                LinkMarkerOffset = new Point(LinkMarkerOffset.X, LinkMarkerOffset.Y - 1);
                break;
            case Link.Direction.Right:
                LinkMarkerOffset = new Point(LinkMarkerOffset.X + 1, LinkMarkerOffset.Y);
                break;
            case Link.Direction.Left:
                LinkMarkerOffset = new Point(LinkMarkerOffset.X - 1, LinkMarkerOffset.Y);
                break;
        }

    }

    internal void MoveLinkMapMarker(Func<Link.Direction> toLinkDirection)
    {
        throw new NotImplementedException();
    }
}


