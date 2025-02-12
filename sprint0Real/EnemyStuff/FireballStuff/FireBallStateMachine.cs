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
        private float time;
        private float deltaX;
        private float deltaY;
        private float slopeX;
        private float slopeY;
        public FireBallStateMachine(FireBall fireball) { 
            myFireball = fireball;
            deltaX = fireball.destination.X - myFireball.location.X;
            deltaY = fireball.destination.Y - myFireball.location.Y;
            time = (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)) / speed;
            slopeX = deltaX / time;
            slopeY = deltaY / time;
        }
        public void Despawn()
        {
            CurrentMap.Instance.DeStage(myFireball);
        }
        public void Update()
        {
            myFireball.location.X = myFireball.location.X + slopeX;
            myFireball.location.Y = myFireball.location.Y + slopeY;
        }
    }
}
