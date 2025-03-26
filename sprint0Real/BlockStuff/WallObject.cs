using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

public class WallObject : IGameObject
{
    private Rectangle boundingBox;

    public WallObject(Rectangle rectangle)
    {
        boundingBox = rectangle;
    }

    public void Update(GameTime gameTime)
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {

    }

    public Rectangle Rect
    {
        get { return boundingBox; }
    }
}