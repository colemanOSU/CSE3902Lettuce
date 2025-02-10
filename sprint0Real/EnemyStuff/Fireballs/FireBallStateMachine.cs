using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class FireBallStateMachine
    {
        private FireBall myFireball;
        private int speed = 3;
        private float slope;
        private float deltaX;
        private float deltaY;
        public FireBallStateMachine(FireBall fireball) { 
            myFireball = fireball;
            deltaX = fireball.destination.X - myFireball.location.X;
            deltaY = fireball.destination.Y - myFireball.location.Y;
            slope = deltaY / deltaX;
        }
        public void Despawn()
        {
            EnemyPage.Instance.stagingRemove.Add(myFireball);
        }
        public void Update()
        {
            myFireball.location.X = myFireball.location.X + speed;
            myFireball.location.Y = myFireball.location.Y + speed * slope;
        }
    }
}
