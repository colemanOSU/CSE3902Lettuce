using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.BlockSprites;
using sprint0Real.Commands.CollisionCommands;
using sprint0Real.Commands.CollisionCommands2;
using sprint0Real.Interfaces;

namespace sprint0Real.Collisions
{
    public class CollisionHandler2
    {
        private Dictionary<(String, String), ICollisionCommand2> collisionCommands;
        private Game1 game;

        // Maybe make these strings
        public CollisionHandler2(Game1 game)
        {
            this.game = game;
            collisionCommands = new Dictionary<(String, String), ICollisionCommand2>();

            collisionCommands.Add(("Link", "Dragon"),  new LinkEnemyCommand());
            /*
            collisionCommands.Add((typeof(IBlock), typeof(ILink)), new LinkBlockCollisionCommand(game));
            collisionCommands.Add((typeof(ILink), typeof(IBlock)), new LinkBlockCollisionCommand(game));

            collisionCommands.Add((typeof(ILink), typeof(WallObject)), new LinkWallCollisionCommand(game));
            collisionCommands.Add((typeof(WallObject), typeof(ILink)), new LinkWallCollisionCommand(game));

            collisionCommands.Add((typeof(ILink), typeof(IEnemy)), new LinkEnemyCollisionCommand(game));
            collisionCommands.Add((typeof(IEnemy), typeof(ILink)), new LinkEnemyCollisionCommand(game));

            collisionCommands.Add((typeof(ILink), typeof(IItemtemp)), new LinkItemCollisionCommand(game));
            collisionCommands.Add((typeof(IItemtemp), typeof(ILink)), new LinkItemCollisionCommand(game));

            collisionCommands.Add((typeof(ILinkSprite),typeof(IEnemy)), new LinkWeaponCollisionCommand(game));
            collisionCommands.Add((typeof(IEnemy), typeof(ILinkSprite)), new LinkWeaponCollisionCommand(game));
            */
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
        public void HandleCollision(IObject objA, IObject objB, CollisionDirections direction)
        {
            //var key = (GetGeneralType(objA), GetGeneralType(objB));

            if (collisionCommands.TryGetValue((objA.GetType().ToString(), objB.GetType().ToString()), out ICollisionCommand2 command))
            {
                command.Execute(objA, objB, direction);
            }
        }
    }
}
