using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.Interfaces
{
    public interface ILinkSprite : IGameObject
    {
        public bool IsActive { get;
        }
        void Activate();
        void Disable();
        public new void Update(GameTime gametime);

        public new void Draw(SpriteBatch spriteBatch);
    }
}
