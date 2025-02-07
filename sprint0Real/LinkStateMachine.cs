using sprint0Real;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using sprint0Real.Interfaces;

public class LinkStateMachine
{
    private KeyboardControllerTemp keyboardControllerTemp;
    private enum LinkHealth {Normal,Damaged};
    private LinkHealth health = LinkHealth.Normal;
    public void Damaged()
    {
        
    }
}