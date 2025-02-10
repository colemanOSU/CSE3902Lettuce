using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class FireballBehavior
    {
        private FireBall myFireball;
        
        public FireballBehavior(FireBall fireball)
        {
            myFireball = fireball;
        }
        public void Update()
        {
                if (myFireball.location.X <= 0 || myFireball.location.X >= Game1.Instance._graphics.PreferredBackBufferWidth || myFireball.location.Y <= 0 || myFireball.location.Y >= Game1.Instance._graphics.PreferredBackBufferHeight)
                {
                    myFireball.Despawn();
            }  
        }
    }
}
