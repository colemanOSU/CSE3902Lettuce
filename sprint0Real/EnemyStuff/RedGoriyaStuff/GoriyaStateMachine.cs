using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DragonStuff
{
    public class GoriyaStateMachine
    {
        public GoriyaStateMachine() { }

        private enum GoriyaState { Left1, Left2, LeftBlue1};
        private GoriyaState currentState = GoriyaState.Left1;
        private Dragon myDragon;


    }
}
