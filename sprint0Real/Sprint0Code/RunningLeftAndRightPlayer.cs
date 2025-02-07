using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class RunningLeftAndRightPlayer : ISprite
{
    int currentFrame = 0;
    int totalFrames = 3;
    int yPos = 0;
    int xPos = 0;
    bool movingUp = false;
    bool movingLeft = true;

    public Rectangle sourceRectangle = new Rectangle(20, 8, 15, 15);
    public Rectangle destinationRectangle = new Rectangle(400, 400, 15, 15);

    public void Update(SpriteBatch spriteBatch, Texture2D marioSheet) {
        currentFrame = (currentFrame + 1) % (totalFrames * 8);

        sourceRectangle = new Rectangle(20 + currentFrame / 8 * 18, 8, 15, 15);
        int place = (destinationRectangle.Left > 800) ? -15 : (destinationRectangle.Left + 2);
        destinationRectangle = new Rectangle(place + 2, 400, 15, 15);


        spriteBatch.Draw(marioSheet, destinationRectangle, sourceRectangle, Color.White);
    }
}
