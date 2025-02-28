using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.RedGoriya;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Levels;

namespace sprint0Real.EnemyStuff.BoomerangStuff
{
    public class BoomerangStateMachine
    {
        private Boomerang myBoomerang;
        private GoriyaState myGoriyaState;
        public BoomerangStateMachine(Boomerang boomerang)
        {
            myBoomerang = boomerang;
        }

        public void Despawn()
        {
            CurrentMap.Instance.DeStage(myBoomerang);
        }

        public void Update()
        {
            switch (myBoomerang.myGoriyaState)
            {
                case GoriyaState.Right:
                    myBoomerang.location.X -= myBoomerang.speed;
                    break;
                case GoriyaState.Left:
                    myBoomerang.location.X += myBoomerang.speed;
                    break;
                case GoriyaState.Up:
                    myBoomerang.location.Y -= myBoomerang.speed;
                    break;
                case GoriyaState.Down:
                    myBoomerang.location.Y += myBoomerang.speed;
                    break;
            }
        }
    }
}
