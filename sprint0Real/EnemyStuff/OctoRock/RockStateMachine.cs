using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.EnemyStuff.Fireballs
{
    public class RockStateMachine
    {
        private Rock myPetRock;
        private int speed = 3;
        private float time;
        private float deltaX;
        private float deltaY;
        private float slopeX;
        private float slopeY;
        public RockStateMachine(Rock rock) {
            myPetRock = rock;
            if (myPetRock.direction==1)
            {
                slopeX = 0;
                slopeY = -5;
            }
            if (myPetRock.direction == 2)
            {
                slopeX = 5;
                slopeY = 0;
            }
            if (myPetRock.direction == 3)
            {
                slopeX = 0;
                slopeY = 5;
            }
            if (myPetRock.direction == 4)
            {
                slopeX = -5;
                slopeY = 0;
            }
        }
        public void Despawn()
        {
            EnemyPage.Instance.stagingRemove.Add(myPetRock);
        }
        public void Update()
        {
            myPetRock.location.X = myPetRock.location.X + slopeX;
            myPetRock.location.Y = myPetRock.location.Y + slopeY;
        }
    }
}
