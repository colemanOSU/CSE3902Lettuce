using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.EnemyStuff.Fireballs;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff
{
    public class EnemySpriteFactory
    {
        private Texture2D bossesSheet;
        private Texture2D enemySpriteSheet;
        public Game1 myGame;
        // More private Texture2Ds follow
        // ...
        private static EnemySpriteFactory instance = new EnemySpriteFactory();
        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemySpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content, Game1 game)
        {
            myGame = game;
            bossesSheet = content.Load<Texture2D>("Bosses");
            // More Content.Load calls follow
            //...
        }
        public ISprite2 CreateDragonEnemySprite()
        {
            return new DragonSpriteIdle(bossesSheet, myGame._spriteBatch);
        }

        public ISprite2 CreateDragonAttackSprite()
        {
            return new DragonSpriteAttack(bossesSheet, myGame._spriteBatch);
        }

        public ISprite2 CreateDragonDamagedSprite()
        {
            return new DragonSpriteDamaged(bossesSheet, myGame._spriteBatch);
        }

        public ISprite2 CreateFireballSprite()
        {
            return new FireballSprite(bossesSheet, myGame._spriteBatch);
        }

        // More public ISprite returning methods follow
        // ...
    }
}