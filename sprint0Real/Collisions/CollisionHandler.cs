using System;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.BlockSprites;
using sprint0Real.Commands.CollisionCommands;
using sprint0Real.Commands.CollisionCommands2;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.Collisions
{
    public class CollisionHandler
    {
        private Dictionary<(String, String), ICollisionCommand2> collisionCommands;
        private Game1 game;
        private SoundEffect playerHurt;
        ContentManager _content;


        // Maybe make these strings
        public CollisionHandler(Game1 game)
        {
            this.game = game;
            collisionCommands = new Dictionary<(String, String), ICollisionCommand2>();

            collisionCommands.Add(("Link", "enemy"),  new LinkEnemyCommand());
            collisionCommands.Add(("Link", "Border"), new LinkBorderCommand());
            collisionCommands.Add(("Link", "RoomTransitionBox"), new RoomTransitionCommand());
            collisionCommands.Add(("Enemy", "LinkWeapon"), new DamageEnemyCollisionCommand());

            collisionCommands.Add(("Link", "FireBall"), new LinkEnemyCommand());
            collisionCommands.Add(("Link", "TreasureItem"), new LinkItemCollisionCommand());
            
            collisionCommands.Add(("Link", "BlockSpriteBlack"), new LinkStairsCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteBricks"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteFloorBlock"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteFloorTile"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteNavy"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteSpecks"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteStatueFaceLeft"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteStatueFaceRight"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteStripes"), new LinkBlockCollisionCommand2());
            collisionCommands.Add(("Link", "BlockSpriteStairs"), new LinkStairsCollisionCommand());

        }

        public void HandleCollision(IObject objA, IObject objB)
        {
            //var key = (GetGeneralType(objA), GetGeneralType(objB));
            string typeA = objA.GetType().Name;
            string typeB;

            CollisionDirections direction = DetectCollisionDirection(objA, objB);

            if (objB is ITreasureItems)
            {
                typeB = "TreasureItem"; //Generalized key for all treasure items
            }
            else if (objB is IEnemy)
            {
                typeB = "enemy";
            }
            else if (objB is ILinkHitboxes)
            {
                typeB = "LinkWeapon";
            }
            else
            {
                typeB = objB.GetType().Name;
            }

            if (collisionCommands.TryGetValue((typeA, typeB), out ICollisionCommand2 command))
            {
                command.Execute(objA, objB, direction);
            }
        }

        public CollisionDirections DetectCollisionDirection(IObject objA, IObject objB)
        {

            Rectangle rectA = objA.Rect;
            Rectangle rectB = objB.Rect;

            CollisionDirections recentCollisionDirection = CollisionDirections.Default;

            //calculate overlap
            int overlapBottom = rectB.Bottom - rectA.Top;
            int overlapTop = rectA.Bottom - rectB.Top;
            int overlapRight = rectB.Right - rectA.Left;
            int overlapLeft = rectA.Right - rectB.Left;

            //find smallest overlap
            int minOverlap = MathHelper.Min(MathHelper.Min(overlapTop, overlapBottom), MathHelper.Min(overlapLeft, overlapRight));

            if (minOverlap == overlapTop)
            {
                recentCollisionDirection = CollisionDirections.Up;
                //Debug.WriteLine("Collision from Top of " + objB.GetType().Name);
            }
            else if (minOverlap == overlapBottom)
            {
                recentCollisionDirection = CollisionDirections.Down;
                //Debug.WriteLine("Collision from Bottom of " + objB.GetType().Name);
            }
            else if (minOverlap == overlapLeft)
            {
                recentCollisionDirection = CollisionDirections.Left;
                //Debug.WriteLine("Collision from Left of " + objB.GetType().Name);

            }
            else if (minOverlap == overlapRight)
            {
                recentCollisionDirection = CollisionDirections.Right;
                //Debug.WriteLine("Collision from Right of " + objB.GetType().Name);
            }
            return recentCollisionDirection;
        }
    }
}
