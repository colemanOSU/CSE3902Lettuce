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
    private int UIXCoord;
    private int UIYCoord;
    public UI(Texture2D uITexture)
    {
        UIXCoord = Game1.SCREENMIDX - (128 * Scale);
        UIYCoord = Game1.SCREENMIDY - (88 * Scale) - 56 * Scale;
        DestinationRectangle = new Rectangle(UIXCoord, UIYCoord, 256 * Scale, 56 * Scale);
        SourceRectangle = new Rectangle(258, 11, 256, 56);

        UITexture = uITexture;
        


    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(UITexture, DestinationRectangle, SourceRectangle, Color.White);

        //Amount set to arbitrary number for testing purposes
        Rectangle[] RupeeDigits = CounterHelper.Helper(05);
        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * Scale, UIYCoord + 16 * Scale, 8 * Scale, 8 * Scale), RupeeDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * Scale, UIYCoord + 16 * Scale, 8 * Scale, 8 * Scale), RupeeDigits[0], Color.White);

        Rectangle[] KeyDigits =  CounterHelper.Helper(99);
        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * Scale, UIYCoord + 32 * Scale, 8 * Scale, 8 * Scale), KeyDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * Scale, UIYCoord + 32 * Scale, 8 * Scale, 8 * Scale), KeyDigits[0], Color.White);

        Rectangle[] BombDigits = CounterHelper.Helper(03);
        //Rupee Counter Ones Digit and Ten Digit
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 104 * Scale, UIYCoord + 40 * Scale, 8 * Scale, 8 * Scale), BombDigits[1], Color.White);
        spriteBatch.Draw(UITexture, new Rectangle(UIXCoord + 112 * Scale, UIYCoord + 40 * Scale, 8 * Scale, 8 * Scale), BombDigits[0], Color.White);
    }

    public void Update(GameTime gametime, SpriteBatch spriteBatch)
    {
    
    }
}


