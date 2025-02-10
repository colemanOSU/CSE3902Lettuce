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
        Rectangle bounds = EnemySpriteFactory.Instance.myGame.GraphicsDevice.Viewport.Bounds;
        
        public FireballBehavior(FireBall fireball)
        {
            myFireball = fireball;
        }
        public void Update()
        {
            if (!bounds.Contains(myFireball.location))
                {
                    myFireball.Despawn();
            }  
        }
    }
}
