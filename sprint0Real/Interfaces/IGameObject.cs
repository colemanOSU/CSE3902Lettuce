using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.Interfaces
{
    public interface IGameObject
    {
        //included in individual interfaces
        
        void Update(GameTime gameTime);
        
        void Draw(SpriteBatch spriteBatch);
        
        Rectangle Rect { get; }
    }
}
