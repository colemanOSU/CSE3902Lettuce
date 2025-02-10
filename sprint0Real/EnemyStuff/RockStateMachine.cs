using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff
{
    public class OctoRock
    {
        private OctoRockStateMachine stateMachine;
        public OctoRock()
        {
            stateMachine = new OctoRockStateMachine();
        }
        public void Hit()
        {
            stateMachine.Hit();
        }
        public int getDirection()
        {
            return stateMachine.getDirection();
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
        public void ChangeDirectionU()
        {
            stateMachine.ChangeDirectionU();
        }
        public void ChangeDirectionD()
        {
            stateMachine.ChangeDirectionD();
        }
        public void ChangeDirectionL()
        {
            stateMachine.ChangeDirectionL();
        }
        public void ChangeDirectionR()
        {
            stateMachine.ChangeDirectionR();
        }
        // Draw and other methods omitted
    }
    public class OctoRockStateMachine
    {
        private int face = 1;//up is 1 clockwise to 4
        private int X;
        private int Y;
        private int countdown = 1000;
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
        public int getDirection()
        {
            return face;
        }
        public void Hit()
        {
            //delete rock
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
        public void Update()
        {
            // if-else logic based on the current values of facingLeft and health to determine how to move
            countdown = countdown - 1;
            if (face==1)
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
            if (countdown <= 0)
            {
                Hit();
            }
        }
    }
}
