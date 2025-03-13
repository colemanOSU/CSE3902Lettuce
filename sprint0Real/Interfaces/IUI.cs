using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.Interfaces
{
    public interface IUI
    {
        public void Update(GameTime gametime, ILink link);

        public void Draw(SpriteBatch spriteBatch);
    }
}
