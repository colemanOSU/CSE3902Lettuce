using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.Interfaces
{
    public interface IMap
    {
        public void Stage(IEnemy enemy);
        public void DeStage(IEnemy enemy);
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
