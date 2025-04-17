using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.CollisionBoxes;
using sprint0Real.Collisions;
using sprint0Real.GameState.NameRegistrationandAchievements;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;

namespace sprint0Real.Commands.CollisionCommands
{
    public class BombBreachableWallCollisionCommand : ICollisionCommand
    {
        private SoundEffect secret;

        public void Execute(IObject border, IObject bomb, CollisionDirections direction)
        {
            secret = SoundEffectFactory.Instance.getSecretSound();

           if (bomb.GetType().Name == "BombSprite")
            {
                BombSprite Bomb = (BombSprite)bomb;
                if (Bomb.IsDetonated())
                {
                    ((BreachableTransitionBox)border).Unlock();
                    secret.Play();

                    var save = SaveManager.GetSave(Game1.Instance.CurrentPlayerName);
                    if (save == null) return;
                    AchievementManager.Unlock("Secret Revealer!");
                    SaveManager.Save();
                }
            }
        }
    }
}
