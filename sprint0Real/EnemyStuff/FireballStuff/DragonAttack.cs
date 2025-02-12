using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class DragonAttack
    {
        private Vector2 destitation;
        private Vector2 location;
        private Vector2 destination2;
        private Vector2 destination3;
        private IMap map;

        public DragonAttack(Vector2 start, Vector2 final)
        {
            location = start;  
            destitation = final;
            destination2 = new Vector2(final.X, final.Y + 100);
            destination3 = new Vector2(final.X, final.Y - 100);
        }

        public void Attack()
        {
            CurrentMap.Instance.Stage(new FireBall(location, destitation));
            CurrentMap.Instance.Stage(new FireBall(location, destination2));
            CurrentMap.Instance.Stage(new FireBall(location, destination3));
        }
    }
}
