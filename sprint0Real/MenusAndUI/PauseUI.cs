using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using System.Diagnostics;


public class PauseUI : IUI
{

    private Texture2D texture;

    private readonly Rectangle SourceRectangle = new(426, 72, 87, 36);
    private Rectangle DestinationRectangle;
    public PauseUI(Texture2D uITexture)
    {
        texture = uITexture;
        DestinationRectangle = new Rectangle(Game1.SCREENMIDX - 43 * Game1.RENDERSCALE, Game1.SCREENMIDY + 10 * Game1.RENDERSCALE, 87 * Game1.RENDERSCALE, 36 * Game1.RENDERSCALE);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
    }

    //Static sprite, no need to update
    public void Update(GameTime gametime, ILink l)
    {

    }
}


