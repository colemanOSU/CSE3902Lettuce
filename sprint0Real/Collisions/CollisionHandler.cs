using System;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.BlockSprites;
using sprint0Real.Commands.CollisionCommands2;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.TreasureItemStuff;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;
using sprint0Real.Commands.CollisionCommands;

namespace sprint0Real.Collisions
{
    public class CollisionHandler
    {
        private Dictionary<(String, String), ICollisionCommand> collisionCommands;
        private Game1 game;
        public bool isPhaseActive = false;


        // Maybe make these strings
        public CollisionHandler(Game1 game)
        {
            this.game = game;
            collisionCommands = new Dictionary<(String, String), ICollisionCommand>();
        }
        public void LoadCommands()
        {
            collisionCommands.Add(("Link", "Enemy"),  new LinkEnemyCommand(game));
            collisionCommands.Add(("Link", "Border"), new LinkBorderCommand());
            collisionCommands.Add(("Link", "RoomTransitionBox"), new RoomTransitionCommand(game));
            collisionCommands.Add(("LinkWeapon", "Border"), new StopLinkWeaponCommand(game));
            collisionCommands.Add(("Enemy", "LinkWeapon"), new DamageEnemyCollisionCommand());
            collisionCommands.Add(("Enemy", "Enemy"), new EnemyEnemyCollisionCommand());
            collisionCommands.Add(("OldManSprite", "LinkWeapon"), new OldManCollisionCommand());

            collisionCommands.Add(("Link", "EnemyProjectile"), new LinkEnemyCommand(game));
            collisionCommands.Add(("Link", "TreasureItem"), new LinkItemCollisionCommand());

            collisionCommands.Add(("Link", "BlockSpriteBlack"), new LinkStairsCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteBricks"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteFloorBlock"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteFloorTile"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteNavy"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteSpecks"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteStatueFaceLeft"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteStatueFaceRight"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteStripes"), new LinkBlockCollisionCommand());
            collisionCommands.Add(("Link", "BlockSpriteStairs"), new LinkStairsCollisionCommand());
            collisionCommands.Add(("Enemy", "Border"), new EnemyBorderCommand());
            collisionCommands.Add(("Enemy", "BlockSpriteFloorBlock"), new EnemyBlockCommand());

            collisionCommands.Add(("Enemy", "RoomTransitionBox"), new EnemyTransitionBoxes());
            collisionCommands.Add(("Link", "SealedTransitionBox"), new LinkLockedTransitionBoxCollisionCommand());
            collisionCommands.Add(("Enemy", "SealedTransitionBox"), new EnemyTransitionBoxes());
            collisionCommands.Add(("Link", "LockedTransitionBox"), new LinkLockedTransitionBoxCollisionCommand());
            collisionCommands.Add(("Enemy", "LockedTransitionBox"), new EnemyTransitionBoxes());
            collisionCommands.Add(("Link", "BreachableTransitionBox"), new LinkLockedTransitionBoxCollisionCommand());
            collisionCommands.Add(("Enemy", "BreachableTransitionBox"), new EnemyTransitionBoxes());
            collisionCommands.Add(("BreachableTransitionBox", "LinkWeapon"), new BombBreachableWallCollisionCommand());

            collisionCommands.Add(("Link", "HandVicinitySpawner"), new LinkHandSpawnerCollisionCommand());
        }

        public void HandleCollision(IObject objA, IObject objB)
        {
            //var key = (GetGeneralType(objA), GetGeneralType(objB));

            string typeA;
            string typeB;

            if (objA is IEnemy)
            {
                typeA = "Enemy";
            }
            else
            {
                typeA = objA.GetType().Name;
            }

            CollisionDirections direction = DetectCollisionDirection(objA, objB);

            if (objB is ITreasureItems)
            {
                typeB = "TreasureItem"; //Generalized key for all treasure items
            }
            else if(objB is IEnemy)
            {
                typeB = "Enemy";
            }
            else if (objB is ILinkSprite)
            {
                typeB = "LinkWeapon";
            }
            else if (objB is IProjectile)
            {
                typeB = "EnemyProjectile";
            }
            else
            {
                typeB = objB.GetType().Name;
            }

            if (collisionCommands.TryGetValue((typeA, typeB), out ICollisionCommand command))
            {
                if (!isPhaseActive)
                {
                    command.Execute(objA, objB, direction);
                }
                else if (!(typeA == "Link" & (typeB == "Enemy" || typeB == "EnemyProjectile")))
                {
                    command.Execute(objA, objB, direction);
                }
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
