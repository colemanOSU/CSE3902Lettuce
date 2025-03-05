using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using System.Diagnostics.Metrics;
using sprint0Real.Levels;

namespace sprint0Real.EnemyStuff.DeathSprites
{
    public class Death : IGameObject
    {
        public ISprite2 mySprite;
        public Rectangle destinationRectangle;
        private int counter;

        public Death(Vector2 start)
        {
            mySprite = EnemySpriteFactory.Instance.CreateDeathSprite();
            destinationRectangle.Location = new Point((int)start.X, (int)start.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, new Vector2(destinationRectangle.X, destinationRectangle.Y));
        }

        public void Update(GameTime time)
        {
            if (counter != 4)
            {
                counter++;
                mySprite.Update();
            }
            CurrentMap.Instance.DeStage(this);
        }
    }
}
