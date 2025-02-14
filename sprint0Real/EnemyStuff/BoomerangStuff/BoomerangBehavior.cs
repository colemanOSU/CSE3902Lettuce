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
        private bool Hit = false;
        private bool Caught = false;

        Rectangle bounds = EnemySpriteFactory.Instance.myGame.GraphicsDevice.Viewport.Bounds;

        public BoomerangBehavior(Boomerang Boomerang)
        {
            myBoomerang = Boomerang;
        }

        private void HitBounds()
        {
            if (!bounds.Contains(myBoomerang.location)){
                Hit = true;
            }
            
        }

        private void IsCaught()
        {
            if (myBoomerang.location == new Vector2(0,0))
            {
                Caught = true;
            }
        }

        public void Update()
        {
            HitBounds();
            IsCaught();
            if (Caught)
            {
                myBoomerang.Despawn();
            }
            else if (Hit && myBoomerang.speed >= -myBoomerang.speed)
            {
                myBoomerang.speed -= myBoomerang.deceeleration;
            }
        }
    }
}
