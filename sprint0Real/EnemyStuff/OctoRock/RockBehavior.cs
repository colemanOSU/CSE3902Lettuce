using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class RockBehavior
    {
        private Rock myPetRock;
        
        public RockBehavior(Rock rock)
        {
            myPetRock = rock;
        }
        public void Update()
        {
                if (myPetRock.location.X <= 0 || myPetRock.location.X >= EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferWidth || myPetRock.location.Y <= 0 || myPetRock.location.Y >= EnemySpriteFactory.Instance.myGame._graphics.PreferredBackBufferHeight)
                {
                myPetRock.Despawn();
            }  
        }
    }
}
