using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.EnemyStuff.DragonStuff
{

    public class DragonBehavior
    {
        private Dragon myDragon;
        private float jukeDelay = 0f;
        private float attackDelay = 5f;
        private float jukeTimer = 0f;
        private float attackTimer = 0f;
        private Random random = new Random();

        public DragonBehavior(Dragon dragon)
        {
            myDragon = dragon;
        }

        public void Update(GameTime time)
        {
            jukeTimer += (float)time.ElapsedGameTime.TotalSeconds;
            attackTimer += (float)time.ElapsedGameTime.TotalSeconds;

            if (jukeDelay <= jukeTimer)
            {
                jukeTimer = 0;
                jukeTimer = (float)(random.NextDouble() * 0.5);
                myDragon.ChangeDirection();
            }

            // Gotta make the dragon doesn't juke it's way off screen
            if (myDragon.location.X >= Game1.Instance._graphics.PreferredBackBufferWidth)
            {
                jukeTimer = 0;
                myDragon.ChangeDirection();
            }

            if (attackDelay <= attackTimer)
            {
                attackTimer = 0;
                myDragon.Attack();
            }
        }
    }
}
