using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.Fireballs;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class Octo : IEnemy
    {
        private OctoStateMachine stateMachine;

        public ISprite2 mySprite;
        public Vector2 location;
        public int speed = 2;
        public int health = 1;
        public int state=1;
        public OctoAttack attack;

        public Octo(Vector2 placement)
        {
            location = placement;
            stateMachine = new OctoStateMachine(this);
            mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
        }

        public void ChangeDirectionL()
        {
            stateMachine.ChangeDirectionL();
        }
        public void ChangeDirectionR()
        {
            stateMachine.ChangeDirectionR();
        }
        public void ChangeDirectionU()
        {
            stateMachine.ChangeDirectionU();
        }
        public void ChangeDirectionD()
        {
            stateMachine.ChangeDirectionD();
        }
        public void TakeDamage()
        {
            stateMachine.TakeDamage();
        }

        public void Attack()
        {
            attack = new OctoAttack(location, stateMachine.GetState());//wtf
            attack.Attack();
            stateMachine.Attack();
        }

        public void Idle()
        {
            stateMachine.Idle();
        }

        public void Update(GameTime time)
        {
            // Updates the location
            stateMachine.Update();
            // Moves onto the next frame in animation
            mySprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(spriteBatch, location);
        }
        
        public Rectangle Rect
        {
            get
            {
                //TODO: WRONG RECT!!
                return new Rectangle((int)location.X, (int)location.Y, 48, 64);
            }
        }
    }
}
