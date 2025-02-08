using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class RunningInPlacePlayer : ISprite
{
    int currentFrame = 0;
    int totalFrames = 3;
    int scale = 8;
    int yPos = 0;
    int xPos = 0;
    bool movingUp = false;
    bool movingLeft = false;

    public Rectangle sourceRectangle = new Rectangle(20, 8, 15, 15);
    public Rectangle destinationRectangle = new Rectangle(400, 400, 15, 15);

    public void Update(SpriteBatch spriteBatch, Texture2D marioSheet)
    {
        currentFrame = (currentFrame + 1) % (totalFrames * 8);

        sourceRectangle = new Rectangle(20 + currentFrame / 8 * 18, 8, 15, 15);

        spriteBatch.Draw(marioSheet, destinationRectangle, sourceRectangle, Color.White);
    }
}
