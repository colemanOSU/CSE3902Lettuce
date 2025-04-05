using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;
using sprint0Real.LinkStuff;
using sprint0Real.MenusAndUI;
using System.Diagnostics;


public class MenuUI
{
    private Texture2D UITexture;
    private Rectangle MapDestinationRectangle;
    private Rectangle MapSourceRectangle;
    private Rectangle ItemDestinationRectangle;
    private Rectangle ItemSourceRectangle;

    private Rectangle ItemSelectSourceRectangle;
    private Rectangle ItemSelectDestinationRectangle;
    private Rectangle ItemSelectRed = new Rectangle(519, 137, 16, 16);
    private Rectangle ItemSelectBlue = new Rectangle(536, 137, 16, 16);

    private int Scale = Game1.RENDERSCALE;
    private int UIXCoord;
    private int UIYCoord;
    private int ItemYCoord;
    private int ItemSelectFrameCount;

    private bool HasMap = false;
    private bool HasCompass = false;

    private Inventory.Items CurrentItem;
    private Inventory inv;

    private int XSelect, YSelect;
    private Inventory.Items[,] DisplayInventory;

    public MenuUI(Texture2D uITexture)
    {
        UITexture = uITexture;
        MapSourceRectangle = new Rectangle(258, 112, 256, 88);
        ItemSourceRectangle = new Rectangle(1, 11, 256, 88);
        ItemSelectSourceRectangle = ItemSelectRed;

        UIXCoord = Game1.SCREENMIDX - (128 * Scale);
        UIYCoord = Game1.SCREENMIDY - (88 + 56 + 88 - 30) * Scale;
        MapDestinationRectangle = new Rectangle(UIXCoord, UIYCoord, 256 * Scale, 88 * Scale);

        ItemYCoord = UIYCoord - 88 * Scale;
        ItemDestinationRectangle = new Rectangle(UIXCoord, ItemYCoord, 256 * Scale, 88 * Scale);

        XSelect = 0;
        YSelect = 0;
        ItemSelectFrameCount = 1;

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(UITexture, MapDestinationRectangle, MapSourceRectangle, Color.White);
        spriteBatch.Draw(UITexture, ItemDestinationRectangle, ItemSourceRectangle, Color.White);

        spriteBatch.Draw(UITexture, ItemSelectDestinationRectangle, ItemSelectSourceRectangle, Color.White);



        //Current Item Sprite
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 68 * Scale, ItemYCoord + 48 * Scale, 8 * Scale, 16 * Scale), UIHelper.ItemSpriteHelper(CurrentItem), Color.White);


        //Inventory.Items[,] DisplayInventory = MenuToDisplay.MenuRealizer(inv);

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (!DisplayInventory[i,j].Equals(Inventory.Items.Arrow) && !DisplayInventory[i, j].Equals(Inventory.Items.Silver_Arrow))
                {
                    spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + Scale * (132 + 24 * j), ItemYCoord + Scale * (48 + 16 * i), 8 * Scale, 16 * Scale), UIHelper.ItemSpriteHelper(DisplayInventory[i, j]), Color.White);
                } else
                {
                    spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + Scale * (184), ItemYCoord + Scale * (48), 8 * Scale, 16 * Scale), new Rectangle(633, 137, 8, 16), Color.White);
                    if (DisplayInventory[i, j].Equals(Inventory.Items.Arrow)) {
                        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + Scale * (176), ItemYCoord + Scale * (48), 8 * Scale, 16 * Scale), new Rectangle(615, 137, 8, 16), Color.White);
                    } else
                    {
                        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + Scale * (176), ItemYCoord + Scale * (48), 8 * Scale, 16 * Scale), new Rectangle(624, 137, 8, 16), Color.White);
                    }
                }
            }
        }

        if (HasMap)
        {
            spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + Scale * (48), UIYCoord + Scale * (24), 8 * Scale, 16 * Scale), new Rectangle(601, 156, 8, 16), Color.White);
        }

        if (HasCompass)
        {
            spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + Scale * (44), UIYCoord + Scale * (64), 15 * Scale, 16 * Scale), new Rectangle(612, 156, 15, 16), Color.White);
        }



    }

    public void Update(GameTime gametime, ILink link)
    {
        inv = link.GetInventory();
        DisplayInventory = MenuToDisplay.MenuRealizer(inv);

        CurrentItem = inv.CurrentItem;


        ItemSelectDestinationRectangle = new Rectangle(UIXCoord + Scale * (128 + XSelect * 24), ItemYCoord + Scale * (48 + YSelect * 16), 16 * Scale, 16 * Scale);

        if (!HasMap && inv.HasMap) HasMap = true;
        if (!HasCompass && inv.HasCompass) HasCompass = true;

        if (ItemSelectFrameCount <= 20) ItemSelectSourceRectangle = ItemSelectRed;
        else if (ItemSelectFrameCount <= 40) ItemSelectSourceRectangle = ItemSelectBlue;
        if (ItemSelectFrameCount >= 41) ItemSelectFrameCount = 0;
        ItemSelectFrameCount++;
    }

    public void MoveSelectorRight()
    {
        int TempXSelect = XSelect;
        for (int i = 0; i < 3; i++)
        {
            TempXSelect++;
            if (TempXSelect >= 4) TempXSelect = 0;

            if (DisplayInventory[YSelect, TempXSelect] != 0)
            {
                XSelect = TempXSelect;
                inv.CurrentItem = DisplayInventory[YSelect, XSelect];
                return;
            }
        }
        //Only does this if there are no other items in row;
        //Allows items to be switched even without contiguous inventory.
        YSelect = (YSelect == 0) ? 1 : 0;
        TempXSelect = XSelect;
        for (int i = 0; i < 3; i++)
        {
            TempXSelect++;
            if (TempXSelect >= 4) TempXSelect = 0;

            if (DisplayInventory[YSelect, TempXSelect] != 0)
            {
                XSelect = TempXSelect;
                inv.CurrentItem = DisplayInventory[YSelect, XSelect];
                return;
            }
        }
        YSelect = (YSelect == 0) ? 1 : 0;
    }

    public void MoveSelectorLeft()
    {
        int TempXSelect = XSelect;
        for (int i = 0; i < 3; i++)
        {
            TempXSelect--;
            if (TempXSelect < 0) TempXSelect = 3;

            if (DisplayInventory[YSelect, TempXSelect] != 0)
            {
                XSelect = TempXSelect;
                inv.CurrentItem = DisplayInventory[YSelect, XSelect];
                return;
            }
        }
        //Only does this if there are no other items in row;
        //Allows items to be switched even without contiguous inventory.
        YSelect = (YSelect == 0) ? 1 : 0;
        TempXSelect = XSelect;
        for (int i = 0; i < 3; i++)
        {
            TempXSelect--;
            if (TempXSelect < 0) TempXSelect = 3;

            if (DisplayInventory[YSelect, TempXSelect] != 0)
            {
                XSelect = TempXSelect;
                inv.CurrentItem = DisplayInventory[YSelect, XSelect];
                return;
            }
        }
        YSelect = (YSelect == 0) ? 1 : 0;
    }

    public void MoveSelectorVertical()
    {
        int TempYSelect = (YSelect == 0) ? 1 : 0;
    
        if (DisplayInventory[TempYSelect, XSelect] != 0)
        {
            YSelect = TempYSelect; 
            inv.CurrentItem = DisplayInventory[YSelect, XSelect];
                
        }

    }


}


