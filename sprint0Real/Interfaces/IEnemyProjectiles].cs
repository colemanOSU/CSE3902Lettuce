using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.Interfaces
{
    public interface IEnemyProjectile : IGameObject
    {
        void Update(GameTime time);
        void Draw(SpriteBatch spriteBatch);

    }
}