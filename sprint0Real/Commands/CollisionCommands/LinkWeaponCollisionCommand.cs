using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff.LinkSprites;

namespace sprint0Real.Commands.CollisionCommands
{
    public class LinkWeaponCollisionCommand : ICollisionCommand
    {
        private readonly ILinkSprite weapon;
        private readonly IEnemy enemy;

        public LinkWeaponCollisionCommand(ILinkSprite weapon, IEnemy enemy)
        {
            this.weapon = weapon;
            this.enemy = enemy;
        }

        public void Execute(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {
            Console.WriteLine($"Weapon {weapon.GetType().Name} hit enemy {enemy.GetType().Name}!");
        }
    }
}
