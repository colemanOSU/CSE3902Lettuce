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
            mySprite.Update();
            // Only remove when the death animation is complete.
            if (mySprite is DeathSprite deathSprite && deathSprite.AnimationComplete)
            {
                CurrentMap.Instance.DeStage(this);
            }
        }

        public Rectangle Rect
        {
            get
            {
                return destinationRectangle;
            }
        }
    }
}
