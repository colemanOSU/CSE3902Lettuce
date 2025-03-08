using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.LinkStuff2.Interface
{
    public interface ILinkSprite
    {
        void Update();
        void Draw(Color LinkSpriteColor, SpriteBatch spriteBatch, Point location);
    }
}
