using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Update()
        {
            switch (currentState)
            {
                case LinkState.UpMoving:
                    //myLink.destinationRectangle.Offset(myLink.SPEED);
                    break;
            }
        }
    }
}
