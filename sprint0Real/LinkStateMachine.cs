using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using sprint0Real.Interfaces;
using System.Data.Common;
namespace sprint0Real
{
    public class LinkStateMachine
    {
        private enum LinkHealth { Normal, Damaged };
        private LinkHealth health = LinkHealth.Normal;
        private Game1 _game;
        private ILinkSprite _sprite;
        public LinkStateMachine()
        {
        }
        public void Damaged()
        {
            health = LinkHealth.Damaged;
        }
    }
}