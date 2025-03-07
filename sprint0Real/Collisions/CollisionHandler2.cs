using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.BlockSprites;
using sprint0Real.Commands.CollisionCommands;
using sprint0Real.Interfaces;

namespace sprint0Real.Collisions
{
    public class CollisionHandler2
    {
        private Dictionary<(Type, Type), ICollisionCommand> collisionCommands;
        private Game1 game;

        public CollisionHandler2(Game1 game)
        {
            this.game = game;

            collisionCommands = new Dictionary<(Type, Type), ICollisionCommand>();
            collisionCommands.Add((typeof(IBlock), typeof(ILink)), new LinkBlockCollisionCommand(game));
            collisionCommands.Add((typeof(ILink), typeof(IBlock)), new LinkBlockCollisionCommand(game));

            collisionCommands.Add((typeof(ILink), typeof(IEnemy)), new LinkEnemyCollisionCommand(game));
            collisionCommands.Add((typeof(IEnemy), typeof(ILink)), new LinkEnemyCollisionCommand(game));

            collisionCommands.Add((typeof(ILink), typeof(IItemtemp)), new LinkItemCollisionCommand(game));
            collisionCommands.Add((typeof(IItemtemp), typeof(ILink)), new LinkItemCollisionCommand(game));

            collisionCommands.Add((typeof(ILinkSprite),typeof(IEnemy)), new LinkWeaponCollisionCommand(game));
            collisionCommands.Add((typeof(IEnemy), typeof(ILinkSprite)), new LinkWeaponCollisionCommand(game));
        }
        private Type GetGeneralType(IGameObject obj)
        {
            if (obj is IEnemy) return typeof(IEnemy);  
            if (obj is IItemtemp) return typeof(IItemtemp); 
            if (obj is ILink) return typeof(ILink); 
            if (obj is IBlock) return typeof(IBlock);
            if (obj is ILinkSprite) return typeof(ILinkSprite);
            return obj.GetType();                      //Default to concrete type for anything else
        }
        public void HandleCollision(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {
            var key = (GetGeneralType(objA), GetGeneralType(objB));

            if (collisionCommands.TryGetValue(key, out ICollisionCommand command))
            {
                command.Execute(objA, objB, direction);
            }
        }
    }
}
