using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class OctoAttack
    {
        private int direction;
        private Vector2 location;

        public OctoAttack(Vector2 start, int state)
        {
            location = start;
            direction = state;
        }

        public void Attack()
        {
            EnemyPage.Instance.stagingAdd.Add(new Rock(location, direction));
        }
    }
}
