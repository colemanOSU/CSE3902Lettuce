using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.BTrapStuff;
using sprint0Real.Interfaces;
using System;

namespace sprint0Real.EnemyStuff.BTrapStuff
{
    public class BTrapStateMachine : IStateMachine
    {
        private enum BTrapStates { Neutral, LeftAttack, RightAttack, UpAttack, DownAttack, LeftReturn, RightReturn, UpReturn, DownReturn}
        private bool ret = false;
        private BTrapStates currentState = BTrapStates.Neutral;
        private BTrap myBTrap;
        private Random random = new Random();

        public BTrapStateMachine(BTrap BTrap)
        {
            myBTrap = BTrap;
        }
        public void hitWall()
        {
            if (ret)
            {
                ret = false;
            }
            else
            {
                ret = true;
                Return();
            }
        }
        public void Return()
        {
            switch (currentState)
            {
                case BTrapStates.RightAttack:
                    currentState = BTrapStates.LeftReturn;
                    break;
                case BTrapStates.LeftAttack:
                    currentState = BTrapStates.RightReturn;
                    break;
                case BTrapStates.UpAttack:
                    currentState = BTrapStates.DownReturn;
                    break;
                case BTrapStates.DownAttack:
                    currentState = BTrapStates.UpReturn;
                    break;
            }
        }

        public void Returned()
        {
            currentState = BTrapStates.Neutral;
        }

        private bool ToSide(Rectangle linkLocation)
        {
            return (linkLocation.Top <= myBTrap.Rect.Bottom && linkLocation.Bottom >= myBTrap.Rect.Bottom) || (linkLocation.Bottom >= myBTrap.Rect.Top && linkLocation.Top <= myBTrap.Rect.Top);
        }

        private bool IsAboveOrBelow(Rectangle linkLocation)
        {
            return (linkLocation.Left <= myBTrap.Rect.Right && linkLocation.Right >= myBTrap.Rect.Right) || (linkLocation.Right >= myBTrap.Rect.Left && linkLocation.Left <= myBTrap.Rect.Left);
        }

        private void CheckAttack()
        {
            Rectangle linkLocation = EnemySpriteFactory.Instance.myGame.Link.GetLocation();
            if (currentState == BTrapStates.Neutral)
            {
                
                if (ToSide(linkLocation) && linkLocation.Left >= myBTrap.Rect.Right)
                {
                    currentState = BTrapStates.RightAttack;
                }else if (ToSide(linkLocation) && linkLocation.Right <= myBTrap.Rect.Left)
                {
                    currentState = BTrapStates.LeftAttack;
                }else if (IsAboveOrBelow(linkLocation) && linkLocation.Top >= myBTrap.Rect.Bottom)
                {
                    currentState = BTrapStates.DownAttack;
                }
                else if (IsAboveOrBelow(linkLocation) && linkLocation.Bottom <= myBTrap.Rect.Top)
                {
                    currentState = BTrapStates.UpAttack;
                }
            }
        }

        public void Update()
        {
            // Check if to attack 
            CheckAttack();
            switch (currentState)
            {
                case BTrapStates.RightAttack:
                    myBTrap.location = new Vector2(myBTrap.location.X + myBTrap.speed, myBTrap.location.Y);
                    break;
                case BTrapStates.LeftAttack:
                    myBTrap.location = new Vector2(myBTrap.location.X - myBTrap.speed, myBTrap.location.Y);
                    break;
                case BTrapStates.UpAttack:
                    myBTrap.location = new Vector2(myBTrap.location.X, myBTrap.location.Y - myBTrap.speed);
                    break;
                case BTrapStates.DownAttack:
                    myBTrap.location = new Vector2(myBTrap.location.X, myBTrap.location.Y + myBTrap.speed);
                    break;
                case BTrapStates.LeftReturn:
                    myBTrap.location = new Vector2(myBTrap.location.X - myBTrap.speed / 2, myBTrap.location.Y);
                    break;
                case BTrapStates.RightReturn:
                    myBTrap.location = new Vector2(myBTrap.location.X + myBTrap.speed / 2, myBTrap.location.Y);
                    break;
                case BTrapStates.DownReturn:
                    myBTrap.location = new Vector2(myBTrap.location.X, myBTrap.location.Y + myBTrap.speed / 2);
                    break;
                case BTrapStates.UpReturn:
                    myBTrap.location = new Vector2(myBTrap.location.X, myBTrap.location.Y - myBTrap.speed / 2);
                    break;
            }
        }
    }
}