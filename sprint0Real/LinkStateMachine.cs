using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using sprint0Real.Interfaces;
using System.Data.Common;
namespace sprint0Real
{
    public class LinkStateMachine : ILinkState
    {

        private ILink Link;
        private double DamageFrameCount;

        private int DamageLoops;
        public LinkStateMachine(Game1 game)
        {
            this.Link = game.Link;
            DamageFrameCount = 0;
            DamageLoops = 0;
        }
        public void DamageLink() 
        {
            Link.SetIsDamaged(true);
        }

        public void Update(GameTime gametime)
        {
            if (Link.IsDamaged())
            {
                DamageFrameCount = DamageFrameCount + 0.2;
                switch ((int)DamageFrameCount)
                {
                    case 1:
                        Link.SetLinkColor(Color.White);
                        break;
                    case 2:
                        Link.SetLinkColor(Color.DarkRed);
                        break;
                    case 3:
                        Link.SetLinkColor(Color.Red);
                        break;
                    case 4:
                        Link.SetLinkColor(Color.OrangeRed);
                        break;
                    case 5:
                        DamageFrameCount = 0;
                        DamageLoops++;
                        break;
                }

                if (DamageLoops >= 3)
                {
                    DamageLoops = 0;
                    Link.SetIsDamaged(false);
                    Link.SetLinkColor(Color.White);
                }

            }
        }
    }
}