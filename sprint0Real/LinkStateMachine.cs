using sprint0Real;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using sprint0Real.Interfaces;
using System.Data.Common;

public class LinkStateMachine
{
    private KeyboardControllerTemp keyboardControllerTemp;
    private enum LinkHealth {Normal,Damaged};
    private LinkHealth health = LinkHealth.Normal;
    private Game1 game;
    private Texture2D _texture;
    private SpriteBatch spriteBatch;
    public void Damaged()
    {
         health = LinkHealth.Damaged;
         
    }
    public void Draw(SpriteBatch spritbatch,Texture2D texture)
    {
        _texture = texture;
        if (health == LinkHealth.Damaged)
        {
            Rectangle sourceRectangle = new Rectangle(1, 20, 15, 15);
            Rectangle destinationRectangle = new Rectangle(320, 130, 150, 150);
            spriteBatch.Begin();
            spriteBatch.Draw(_texture,destinationRectangle,sourceRectangle,Color.White);
            spriteBatch.End();
        }
    }
}