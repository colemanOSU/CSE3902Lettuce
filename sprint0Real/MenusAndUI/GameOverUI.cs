using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real;
using sprint0Real.Audio;
using sprint0Real.Interfaces;
using System;
using System.Diagnostics;
using System.Xml.Linq;


public class GameOverUI
{

    private Texture2D texture;

    const int SCALE = Game1.RENDERSCALE;
    private readonly Rectangle BackgroundSourceRectangle = new(260, 42, 1, 1);
    private readonly Rectangle TextSourceRectangle = new(259, 72, 130, 22);
    private readonly Rectangle BackgroundDestination = new(0, 0, Game1.SCREENWIDTH, Game1.SCREENHEIGHT);
    private readonly Rectangle TextDestination = new(Game1.SCREENMIDX - 65 * SCALE, Game1.SCREENMIDY - 11 * SCALE, 130 * SCALE, 22 * SCALE);

    private Rectangle DestinationRectangle;

    private TimeSpan PassedTime;
    private readonly TimeSpan ScreenLength = TimeSpan.FromSeconds(3);
    private bool FirstTime;

    public GameOverUI(Texture2D uITexture)
    {
        texture = uITexture;
        FirstTime = true;
        PassedTime = TimeSpan.Zero;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
        spriteBatch.Draw(texture, BackgroundDestination, BackgroundSourceRectangle, Color.White);

        spriteBatch.Draw(texture, TextDestination, TextSourceRectangle, Color.White);
        spriteBatch.End();
    }

    //Static sprite, no need to update
    public void Update(GameTime gametime, Game1 Game)
    {
        if (FirstTime)
        {
            PassedTime += gametime.ElapsedGameTime;
            if (TimeSpan.Compare(PassedTime, ScreenLength) != -1)
            {
                Game.ResetGame();
            }

        }
    }
}


