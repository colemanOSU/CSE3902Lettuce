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
                    //handle
                    Debug.WriteLine("Collision detected between block and link");
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
