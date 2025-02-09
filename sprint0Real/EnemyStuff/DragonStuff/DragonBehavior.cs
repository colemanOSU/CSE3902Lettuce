using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.EnemyStuff.DragonStuff
{

    public class DragonBehavior
    {
        private Dragon myDragon;

        private float attackDelay = 5f;
        private float attackTimer = 0f;
        private float attackDuration = 2f;
        private bool attackFlag = false;

        private float jukeTimer = 0f;
        private float jukeDelay = 0f;
        
        private Random random = new Random();

        public DragonBehavior(Dragon dragon)
        {
            myDragon = dragon;
        }

        private void SafeJuke()
        {
            if (myDragon.location.X >= Game1.Instance._graphics.PreferredBackBufferWidth - 48)
            {
                jukeTimer = 0;
                myDragon.location.X = Game1.Instance._graphics.PreferredBackBufferWidth - 48;
                myDragon.ChangeDirection();
            }
            else if (myDragon.location.X <= 0)
            {
                jukeTimer = 0;
                myDragon.location.X = 0;
                myDragon.ChangeDirection();
            }
        }
        private void JukeCheck()
        {
            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeDelay = (float)(random.NextDouble() * 1);
                myDragon.ChangeDirection();
            }
        }
        private void AttackCheck()
        {
            if (attackDelay <= attackTimer)
            {
                attackTimer = 0;
                myDragon.Attack();
                attackFlag = true;
            }
        }
        private void AttackFinish()
        {
            if (attackFlag == true && attackTimer >= attackDuration)
            {
                attackTimer = 0;
                myDragon.Idle();
            }
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            attackTimer += (float)time.ElapsedGameTime.TotalSeconds;

            JukeCheck();
            // Gotta make sure the dragon doesn't juke it's way off screen
            SafeJuke();
            AttackCheck();
            AttackFinish();

            if (myDragon.health <= 0)
            {
                EnemyPage.Instance.enemyList.Remove(myDragon);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myDragon.Draw(spriteBatch);
        }
    }
}
