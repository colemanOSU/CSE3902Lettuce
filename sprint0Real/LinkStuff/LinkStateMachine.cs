﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Commands;
using sprint0Real.Interfaces;
using System.Data.Common;
using System;
using System.Diagnostics;
namespace sprint0Real.LinkStuff
{
    public class LinkStateMachine : ILinkState
    {

        private ILink Link;

        private int phaseCounter;

        private double DamageFrameCount;
        private double PhaseFrameCount;

        private int DamageLoops;
        private int PhaseLoops;
        public LinkStateMachine(ILink link)
        {
            Link = link;
            DamageFrameCount = 0;
            DamageLoops = 0;
            PhaseFrameCount = 0;
            PhaseLoops = 0;
        }
        public void DamageLink()
        {
            Link.OffsetCurrentHealth(-1);
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
            if (Link.IsPhaseActive() & phaseCounter > 500) 
            {
                PhaseFrameCount = PhaseFrameCount + 0.2;
                switch ((int)PhaseFrameCount)
                {
                    case 1:
                        Link.SetLinkColor(Color.Gray);
                        break;
                    case 2:
                        Link.SetLinkColor(Color.White);
                        break;
                    case 3:
                        Link.SetLinkColor(Color.DarkGray);
                        break;
                    case 4:
                        Link.SetLinkColor(Color.White);
                        break;
                    case 5:
                        PhaseFrameCount = 0;
                        PhaseLoops++;
                        break;
                }

                if (PhaseLoops >= 5)
                {
                    phaseCounter = 0;
                    PhaseLoops = 0;
                    Link.SwitchPhaseActive();
                    Link.SetLinkColor(Color.White);
                }

            }
            else if (Link.IsPhaseActive())
            {
                phaseCounter++;
                Link.SwitchPhaseActive();
            }
            else
            {
                phaseCounter++;
            }
        }
    }
}