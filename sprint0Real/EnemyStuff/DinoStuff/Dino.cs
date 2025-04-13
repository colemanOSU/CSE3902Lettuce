using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DinoStuff
{
    public class Dino : IEnemy
    {
        private DinoStateMachine DinoStateMachine;
        private DinoBehavior DinoBehavior;
        public ISprite2 mySprite { get; set; }
        public float speed { get; set; }
        public Vector2 location { get; set; }
        public int health { get; set; }

        public Rectangle Rect { get; }

        public Dino(Vector2 location)
        {
            this.location = location;
            speed = 2f;
            health = 10;
        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            // Depends on amount of damage a bomb does
            if (damage > 5)
            {

            }
        }

        public void FinishDamage()
        {

        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
