using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.EnemyStuff
{
    public class Dragon
    {
        private ISprite mySprite;
        private DragonStateMachine stateMachine;

        public Dragon()
        {
            stateMachine = new DragonStateMachine();
        }
    }
}
