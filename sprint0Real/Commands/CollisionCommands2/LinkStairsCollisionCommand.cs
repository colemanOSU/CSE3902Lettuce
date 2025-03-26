using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands2
{
    public class LinkStairsCollisionCommand : ICollisionCommand2
    {
        private SoundEffect _soundEffect;
        public LinkStairsCollisionCommand(SoundEffect soundEffect)
        {
            this._soundEffect = soundEffect;
        }
        public void Execute(IObject Link, IObject Block, CollisionDirections direction)
        {
            _soundEffect.Play();
        }
    }
}
