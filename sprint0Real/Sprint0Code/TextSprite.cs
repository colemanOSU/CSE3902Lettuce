using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static System.Net.Mime.MediaTypeNames;

public class TextSprite 
{
    public void Update(SpriteBatch spriteBatch, SpriteFont font1)
    {
        string output = "Credits:\nProgram Made By: Kelly Coleman\n Sprites from: https://www.spriters-resource.com/nes/supermariobros/sheet/50365/";

        Vector2 fontPos = new Vector2(10, 300);

        spriteBatch.DrawString(font1, output, fontPos, Color.Black);
    }
}
