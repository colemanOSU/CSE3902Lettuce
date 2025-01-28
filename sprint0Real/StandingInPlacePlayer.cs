using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class StandingInPlacePlayer : ISprite
{
    int currentFrame = 0;
    int totalFrames = 1;
    int yPos = 0;
    int xPos = 0;
    bool movingUp = false;
    bool movingLeft = false;

    public Rectangle sourceRectangle = new Rectangle(0, 8, 15, 15);
    public Rectangle destinationRectangle = new Rectangle(400, 400, 15, 15);

    public void Update(SpriteBatch spriteBatch, Texture2D marioSheet) {
        spriteBatch.Draw(marioSheet, destinationRectangle, sourceRectangle, Color.White);
    }
}
