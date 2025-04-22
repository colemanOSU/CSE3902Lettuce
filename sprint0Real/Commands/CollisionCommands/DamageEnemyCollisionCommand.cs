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
using sprint0Real.Levels;
using sprint0Real.EnemyStuff.DinoStuff;

namespace sprint0Real.Commands.CollisionCommands2
{
    internal class DamageEnemyCollisionCommand :ICollisionCommand
    {
        private bool hitPlayed = false;
        private void CheckForDinoDamage(Dino dino, IObject enemyDamage)
        {
            if (enemyDamage.GetType().Name == "BombSprite" && !((BombSprite)enemyDamage).IsDetonated())
            {
                dino.TakeDamage(5);
                CurrentMap.Instance.DeStage(enemyDamage);
            }
        }
        public void Execute(IObject enemy, IObject enemyDamage, CollisionDirections direction)
        {
            if (!hitPlayed)
            {
                SoundEffectFactory.Instance.Play(SoundEffectType.EnemyHit);
                hitPlayed = true;
            }
            if (enemy is IEnemy enemyA)
            {
                if (enemyA.GetType().Name == "Dino")
                {
                    CheckForDinoDamage((Dino)enemyA, enemyDamage);
                }
                else if (enemyDamage is WoodBoomerangSprite || enemyDamage is BlueBoomerangSprite)
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
