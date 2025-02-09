using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class StandingInPlacePlayer : ISprite
{
    private Texture2D _link;
    public Rectangle sourceRectangle = new Rectangle(0, 10, 15, 15);
    public Rectangle destinationRectangle = new Rectangle(350, 150, 50, 50);
    
    public StandingInPlacePlayer(Texture2D linkSheet)
    {
        _link = linkSheet;
    }
    
    public void Update(GameTime gametime, SpriteBatch spritebatch)
    {
        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_link, destinationRectangle, sourceRectangle, Color.White);
    }
}
