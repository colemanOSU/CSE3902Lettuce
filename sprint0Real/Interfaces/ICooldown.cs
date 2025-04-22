using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0Real.Interfaces
{
    internal interface ICooldown
    {
        public void Update(GameTime gametime, ILink);

        public void Draw(SpriteBatch spriteBatch);
    }
}
