using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class TransitionDirections
    {
        private Dictionary<String, Rectangle> TransitionLinkPlacement = new Dictionary<String, Rectangle>();
        
        public TransitionDirections() { 
            TransitionLinkPlacement.Add("Left", new Rectangle(624, 240, 48, 48));
            TransitionLinkPlacement.Add("Right", new Rectangle(96, 240, 48, 48));
            TransitionLinkPlacement.Add("Up", new Rectangle(350, 384, 48, 48));
            TransitionLinkPlacement.Add("Down", new Rectangle(350, 96, 48, 48));
            TransitionLinkPlacement.Add("Underground", new Rectangle(144, 0, 48, 48));
            TransitionLinkPlacement.Add("Aboveground", new Rectangle(336, 240, 48, 48));
        }

        public Rectangle ReturnPlacement(String transitionDirection)
        {
            Rectangle newLocation = TransitionLinkPlacement[transitionDirection];
            newLocation.Offset(0, 186); // Adjust
            //newLocation.Inflate(); 
            return newLocation;
        }
    }
}
