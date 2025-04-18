using sprint0Real.Levels;
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
        private static Wolf instance = new Wolf();
        public bool isused = false;
        public static Wolf Instance
        {
            get
            {
                return instance;
            }
        }
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
        public bool isUsed()
        {
            return isused;
        }
        public void setUsed(bool iscurrent)
        {
            isused = iscurrent;
        }
        
    }
    
}
