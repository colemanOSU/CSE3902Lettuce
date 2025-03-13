using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using System.Diagnostics;


public class MenuUI : IUI
{
    private Texture2D UITexture;
    private Rectangle MapDestinationRectangle;
    private Rectangle MapSourceRectangle;
    private Rectangle ItemDestinationRectangle;
    private Rectangle ItemSourceRectangle;
    private int Scale = Game1.RENDERSCALE;
    private int UIXCoord;
    private int UIYCoord;

    public MenuUI(Texture2D uITexture)
    {
        UITexture = uITexture;
        MapSourceRectangle = new Rectangle(258, 112, 256, 88);
        ItemSourceRectangle = new Rectangle(1, 11, 256, 88);
        UIXCoord = Game1.SCREENMIDX - (128 * Scale);
        UIYCoord = Game1.SCREENMIDY - (88 + 56 + 88) * Scale;
        MapDestinationRectangle = new Rectangle(UIXCoord, UIYCoord, 256 * Scale, 88 * Scale);
        ItemDestinationRectangle = new Rectangle(UIXCoord, UIYCoord - 88 * Scale, 256 * Scale, 88 * Scale);

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(UITexture, MapDestinationRectangle, MapSourceRectangle, Color.White);
        spriteBatch.Draw(UITexture, ItemDestinationRectangle, ItemSourceRectangle, Color.White);
    }

    public void Update(GameTime gametime, SpriteBatch spriteBatch)
    {

    }
}


