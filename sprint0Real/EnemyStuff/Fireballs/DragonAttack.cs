using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class DragonAttack
    {
        private Vector2 destitation;
        private Vector2 location;
        private Vector2 destination2;
        private Vector2 destination3;

        public DragonAttack(Vector2 start, Vector2 final)
        {
            location = start;  
            destitation = final;
            destination2 = new Vector2(final.X, final.Y + 10);
            destination3 = new Vector2(final.X, final.Y - 10);
        }

        public void Attack()
        {
            EnemyPage.Instance.stagingAdd.Add(new FireBall(location, destitation));
            EnemyPage.Instance.stagingAdd.Add(new FireBall(location, destination2));
            EnemyPage.Instance.stagingAdd.Add(new FireBall(location, destination3));
        }
    }
}
