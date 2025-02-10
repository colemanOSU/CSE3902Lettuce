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
    public class FireBall : IEnemy
    {
        private FireballBehavior behavior;
        private FireBallStateMachine stateMachine;
        private ISprite2 mySprite;
        public Vector2 destination;
        public Vector2 location;

        public FireBall(Vector2 start, Vector2 final)
        {
            location = start;
            destination = final;
            mySprite = EnemySpriteFactory.Instance.CreateFireballSprite();
            behavior = new FireballBehavior(this);
            stateMachine = new FireBallStateMachine(this);
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
    }
}
