using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.Interfaces
{
    public interface ISprite3
    {
        public void Update();
        void Draw(SpriteBatch spriteBatch, Rectangle location);
    }
}
