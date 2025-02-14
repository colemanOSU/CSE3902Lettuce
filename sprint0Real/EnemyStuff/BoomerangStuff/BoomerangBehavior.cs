using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.EnemyStuff.BoomerangStuff
{
    public class BoomerangBehavior
    {
        private Boomerang myBoomerang;
        
        private bool caught = false;

        Rectangle bounds = EnemySpriteFactory.Instance.myGame.GraphicsDevice.Viewport.Bounds;

        public BoomerangBehavior(Boomerang Boomerang)
        {
            myBoomerang = Boomerang;
        }

        private void HitBounds()
        {
            if (!bounds.Contains(myBoomerang.location)){
                myBoomerang.IsHit();
            }
        }

        public void Caught()
        {
             caught = true;
        }

        public void Update()
        {
            HitBounds();
            if (caught)
            {
                myBoomerang.Despawn();
            }
            else if (myBoomerang.Hit && myBoomerang.speed >= -myBoomerang.Initialspeed)
            {
                myBoomerang.speed -= myBoomerang.deceeleration;
            }
        }
    }
}
