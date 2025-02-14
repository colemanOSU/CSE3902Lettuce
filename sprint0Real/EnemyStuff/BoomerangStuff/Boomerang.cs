using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.Fireballs;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.BoomerangStuff
{
    public class Boomerang : IEnemy
    {
        private BoomerangBehavior behavior;
        private BoomerangStateMachine stateMachine;
        private ISprite2 mySprite;
        public float deceeleration = 0.1f;
        public float speed = 3f;
        public Vector2 destination;
        public Vector2 location;

        public Boomerang(Vector2 start, GoriyaState goriyaState)
        {
            mySprite = EnemySpriteFactory.Instance.CreateBoomerangSprite();
            behavior = new BoomerangBehavior(this);
            stateMachine = new BoomerangStateMachine(this);
            stateMachine.Attack(goriyaState);
        }

        public void Despawn()
        {
            //stateMachine.Despawn();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime time)
        {
            behavior.Update();
            mySprite.Update();
            stateMachine.Update();
        }
    }
}
