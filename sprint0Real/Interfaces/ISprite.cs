using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.Numerics;

public interface ISprite
{
    public void Update(SpriteBatch spriteBatch, Texture2D marioSheet);
}
