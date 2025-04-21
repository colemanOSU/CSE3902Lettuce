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
using sprint0Real.Audio;
using sprint0Real.Items.ItemSprites;

namespace sprint0Real.Commands.CollisionCommands2
{
    internal class DamageEnemyCollisionCommand :ICollisionCommand
    {
        private bool hitPlayed = false;
        public void Execute(IObject enemy, IObject enemyDamage, CollisionDirections direction)
        {
            if (!hitPlayed)
            {
                SoundEffectFactory.Instance.Play(SoundEffectType.EnemyHit);
                hitPlayed = true;
            }
            if (enemy is IEnemy enemyA)
            {
                if (enemyDamage is WoodBoomerangSprite || enemyDamage is BlueBoomerangSprite)
                {
                    enemyA.Stun(TimeSpan.FromSeconds(2));
                }
                else
                {
                    enemyA.TakeDamage(1);
                }
            }
        }
    }
}
