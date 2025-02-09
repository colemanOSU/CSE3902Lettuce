using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;

public interface ISprite
{
    public void Update(SpriteBatch spriteBatch, Texture2D marioSheet);
    void Draw(SpriteBatch spriteBatch, Vector2 location);
}
