using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using System.Diagnostics;


public class MenuUI : IUI
{
    private Texture2D UITexture;
    private Rectangle DestinationRectangle;
    private Rectangle SourceRectangle;
    private int Scale = Game1.RENDERSCALE;
    private int UIXCoord;
    private int UIYCoord;

    public MenuUI(Texture2D uITexture)
    {
        UITexture = uITexture;
        SourceRectangle = new Rectangle(258, 112, 256, 88);
        UIXCoord = Game1.SCREENMIDX - (128 * Scale);
        UIYCoord = Game1.SCREENMIDY - (88 + 56 + 88) * Scale;
        DestinationRectangle = new Rectangle(UIXCoord, UIYCoord, 256 * Scale, 88 * Scale);

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(UITexture, DestinationRectangle, SourceRectangle, Color.White);
    }

    public void Update(GameTime gametime, SpriteBatch spriteBatch)
    {

    }
}


