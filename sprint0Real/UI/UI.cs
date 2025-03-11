using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;


public class UI : IUI
{
    private Texture2D UITexture;
    private Rectangle DestinationRectangle;
    private Rectangle SourceRectangle;
    private int Scale = Game1.RENDERSCALE;
    public UI(Texture2D uITexture)
    {
        UITexture = uITexture;
        DestinationRectangle = new Rectangle(Game1.SCREENMIDX - (128 * Scale), Game1.SCREENMIDY - (88 * Scale) - 56 * Scale, 256 * Scale, 56 * Scale);
        SourceRectangle = new Rectangle(258, 11, 256, 56);
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(UITexture, DestinationRectangle, SourceRectangle, Color.White);
    }

    public void Update(GameTime gametime, SpriteBatch spriteBatch)
    {
    
    }
}
