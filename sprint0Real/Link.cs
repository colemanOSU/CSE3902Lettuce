using sprint0Real;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;
using System.Collections.Generic;


namespace sprint0Real
{
    public class Link
    {
        private LinkStateMachine stateMachine;
        public Link(Game1 game)
        {
            stateMachine = new LinkStateMachine(game);
        }
        public void Damaged()
        {
            stateMachine.Damaged();
        }
    }
}