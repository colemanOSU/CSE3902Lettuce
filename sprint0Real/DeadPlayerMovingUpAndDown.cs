using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

public class DeadPlayerMovingUpAndDown : ISprite
{
    int currentFrame = 0;
    int totalFrames = 1;
    int yPos = 0;
    int xPos = 0;
    bool movingUp = true;
    bool movingLeft = false;
    int counter = 0;

    public Rectangle sourceRectangle = new Rectangle(116, 8, 15, 15);
    public Rectangle destinationRectangle = new Rectangle(400, 400, 15, 15);

    public void Update(SpriteBatch spriteBatch, Texture2D marioSheet) {


        counter++;
        if (counter > 50)
        {
            destinationRectangle.Offset(0, 2);
        }
        else
        {
            destinationRectangle.Offset(0, -1);
        }
        


        spriteBatch.Draw(marioSheet, destinationRectangle, sourceRectangle, Color.White);
    }
}
