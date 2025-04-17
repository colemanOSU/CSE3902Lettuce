using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.WolfLink
{
    public class Wolf
    {
        private WolfStateMachine wolfstatemachine;
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        }
        public Wolf()
        {
            wolfstatemachine = new WolfStateMachine();
        }
        
    }
    
}
