using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class Rock : IEnemy
    {
        private RockBehavior behavior;
        private RockStateMachine stateMachine;
        private ISprite2 mySprite;
        public int direction;
        public Vector2 location;

        public Rock(Vector2 start, int state)
        {
            location = start;
            direction = state;
            mySprite = EnemySpriteFactory.Instance.CreateFireballSprite();
            behavior = new RockBehavior(this);
            stateMachine = new RockStateMachine(this);
        }

        public void Despawn()
        {
            stateMachine.Despawn();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime time)
        {
            behavior.Update();
            stateMachine.Update();
            mySprite.Update();
        }
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, 7, 9);
            }
        }
    }
}
