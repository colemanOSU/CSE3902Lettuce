using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Diagnostics;

namespace sprint0Real.Collisions
{
    public class CollisionDetection : ICollision
    {
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private ILink linkSprite;
        private Game1 game;
        public CollisionDetection(ILink link, List<IBlock> blocks, Game1 game)
        {
            linkSprite = link;
            //this.enemies = enemies;
            this.blocks = blocks;
            this.game = game;
        }

        public void Update(GameTime gametime)
        {
            checkLinkBlockCollisions();
            //checkLinkEnemyCollisions();
            //checkEnemyBlockCollisions();
        }

        private void checkLinkBlockCollisions()
        {
            foreach (var block in blocks)
            {
                if (linkSprite.Rect.Intersects(block.Rect))
                {
                    Rectangle linkRect = linkSprite.Rect;
                    Rectangle blockRect = block.Rect;

                    //calculate overlap
                    int overlapBottom = blockRect.Bottom - linkRect.Top;
                    int overlapTop = linkRect.Bottom - blockRect.Top;
                    int overlapRight = blockRect.Right - linkRect.Left;
                    int overlapLeft = linkRect.Right - blockRect.Left;

                    //find smallest overlap
                    int minOverlap = MathHelper.Min(MathHelper.Min(overlapTop, overlapBottom), MathHelper.Min(overlapLeft, overlapRight));

                    if (minOverlap == overlapTop)
                    {
                        Debug.WriteLine("Collision from Top of Block");
                        //TODO
                    }
                    else if (minOverlap == overlapBottom)
                    {
                        Debug.WriteLine("Collision from Bottom of Block");
                        //TODO
                    }
                    else if(minOverlap == overlapLeft)
                    {
                        Debug.WriteLine("Collision from Left of Block");
                        //TODO
                    }
                    else if(minOverlap == overlapRight)
                    {
                        Debug.WriteLine("Collision from Right of Block");
                        //TODO
                    }
                }
            }
        }
        /*
        private void checkLinkEnemyCollisions()
        {
            foreach (var enemy in enemies)
            {
                if (linkSprite.Rect.Intersects(enemy.Rect))
                {
                    //handle
                }
            }
        }

       private void checkEnemyBlockCollisions()
        {
            foreach (var enemy in enemies)
            {
                foreach (var block in blocks)
                {
                    if (enemy.Rect.Intersects(block.Rect))
                    {
                        //handle
                    }
                }
            }
        }*/
    }
}
