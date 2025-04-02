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
            TransitionLinkPlacement.Add("Left", new Rectangle(10, 109, 50, 50));
            TransitionLinkPlacement.Add("Right", new Rectangle(10, 109, 50, 50));
            TransitionLinkPlacement.Add("Up", new Rectangle(10, 109, 50, 50));
            TransitionLinkPlacement.Add("Down", new Rectangle(10, 109, 50, 50));
            TransitionLinkPlacement.Add("Underground", new Rectangle(10, 109, 50, 50));
            TransitionLinkPlacement.Add("Aboveground", new Rectangle(10, 109, 50, 50));
        }

        public Rectangle ReturnPlacement(String transitionDirection)
        {
            return TransitionLinkPlacement[transitionDirection];
        }
    }
}
