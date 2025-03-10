using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;


namespace sprint0Real.LinkStuff2
{
    public class LinkStateMachine : IStateMachine
    {
        private LinkState currentState = LinkState.UpStatic;
        private Link myLink;

        public LinkStateMachine(Link link)
        {
            myLink = link;
        }

        public void TakeDamage()
        {

        }

        public void Update()
        {
            switch (currentState)
            {
                case LinkState.UpMoving:
                    myLink.momentumVector = new Vector2(0, -myLink.SPEED);
                    break;
                case LinkState.DownMoving:
                    myLink.momentumVector = new Vector2(0, myLink.SPEED);
                    break;
                case LinkState.LeftMoving:
                    myLink.momentumVector = new Vector2(-myLink.SPEED, 0);
                    break;
                case LinkState.RightMoving:
                    myLink.momentumVector = new Vector2(myLink.SPEED, 0);
                    break;
            }
        }
    }
}
