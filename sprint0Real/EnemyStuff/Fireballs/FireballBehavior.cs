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
        //private Rectangle bound = Game1.Instance.GraphicsDevice.Viewport.Bounds;
        
        public FireballBehavior(FireBall fireball)
        {
            myFireball = fireball;
        }
        public void Update()
        {

            /*    if (!bound.Contains(myFireball.location))
                {
                    myFireball.Despawn();
            }  */
        }
    }
}
