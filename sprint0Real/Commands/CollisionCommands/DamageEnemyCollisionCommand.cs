using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.EnemyStuff.DragonStuff;
using System.Diagnostics;

namespace sprint0Real.Commands.CollisionCommands2
{
    internal class DamageEnemyCollisionCommand :ICollisionCommand
    {
        private SoundEffect enemyHit;
        private bool hitPlayed = false;
        public void Execute(IObject enemy, IObject enemyDamage, CollisionDirections direction)
        {
            //enemyHit = SoundEffectFactory.Instance.getEnemyHit();
            if (!hitPlayed)
            {
                enemyHit.Play();
                hitPlayed = true;
            }
            if (enemy is Dragon enemyA)
            {
                enemyA.TakeDamage(1);
            }
            if(enemyDamage is Dragon enemyB)
            {
                enemyB.TakeDamage(1);
            }
        }
    }
}
