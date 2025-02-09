using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff
{
    public class DragonStateMachine : IStateMachine
    {
        public DragonStateMachine() { }
        
        private enum DragonState {Idle, Attack, Damaged, Dead};
        private DragonState currentState = DragonState.Idle;
        
        // All the transitions possible
        
        public void Update()
        {
            // Something that draws the current state?
            switch (currentState)
            {
               
                    
            }
        }
    }
}
