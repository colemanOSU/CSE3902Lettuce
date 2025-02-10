using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;
using System;

public class StandingInPlacePlayer : ISprite
{
    private Texture2D _link;
    public Rectangle sourceRectangle = new Rectangle(0, 10, 15, 15);
    public Rectangle destinationRectangle = new Rectangle(350, 150, 50, 50);
    
    public StandingInPlacePlayer()
    {
    }
    
    public void Update(SpriteBatch spritebatch,Texture2D mariosheet)
    {
        
    }
}
