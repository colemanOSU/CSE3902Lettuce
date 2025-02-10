using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff
{
    public class Octorok
    {
        private OctorokStateMachine stateMachine;
        public Octorok()
        {
            stateMachine = new OctorokStateMachine();
        }
        public void Hit()
        {
            stateMachine.Hit();
        }
        public int getState()
        {
            return stateMachine.getState();
        }
        public void setX(int newval)
        {
            stateMachine.setX(newval);
        }
        public void setY(int newval)
        {
            stateMachine.setY(newval);
        }
        public int getX()
        {
            return stateMachine.getX();
        }
        public int getY()
        {
            return stateMachine.getY();
        }
        // Draw and other methods omitted
    }
    public class OctorokStateMachine
    {
        private int face = 1;//up is 1 clockwise to 4
        private int X;
        private int Y;
        private int health=3;
        private int CD=0;
        private int shoot;
        public void ChangeDirectionL()
        {
            face = 4;
        }
        public void ChangeDirectionR()
        {
            face = 2;
        }
        public void ChangeDirectionU()
        {
            face = 1;
        }
        public void ChangeDirectionD()
        {
            face = 3;
        }
        public int getState()
        {
            return face;
        }
        public void Hit()
        {
            if (health > 2)
            {
                health--;
                face = face + 10;
            }
            //death idk
        }
        public int getY()
        {
            return Y;
        }
        public int getX()
        {
            return X;
        }
        public void setY(int newval)
        {
            Y=newval;
        }
        public void setX(int newval)
        {
            X = newval;
        }
        public void fire()
        {
            //fire rock
        }
        public void Update()
        {
            if (CD <= 0) {
                Random rnd = new Random();
                shoot = rnd.Next(1, 5);//5 is exclusive
                face = rnd.Next(1, 5);//5 is exclusive
                CD = 50;
            }
            if (shoot != 1)
            {
                if (face == 1)
                {
                    Y--;
                }
                if (face == 2)
                {
                    X++;
                }
                if (face == 3)
                {
                    Y++;
                }
                if (face == 4)
                {
                    X--;
                }
            }
            else
            {
                if (CD == 50)
                {
                    fire();
                }
            }
            CD--;
        }
    }
}
