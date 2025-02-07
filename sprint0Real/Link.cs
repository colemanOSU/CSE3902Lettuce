using sprint0Real;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Link
{
    private LinkStateMachine stateMachine;
    private KeyboardControllerTemp keyboardControllerTemp;
    public Link()
    {
        stateMachine = new LinkStateMachine();
    }
        public void Damaged()
    {
        stateMachine.Damaged();
    }

}
