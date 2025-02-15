using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.BoomerangStuff;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.EnemyStuff.Fireballs;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff
{
    public class EnemySpriteFactory
    {
        public Game1 myGame;
        private Texture2D bossesSheet;
        private Texture2D enemySpriteSheet;
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

        public void LoadGame(Game1 game)
        {
            myGame = game;
        }
        public void LoadAllTextures(ContentManager content)
        {
            bossesSheet = content.Load<Texture2D>("Bosses");
            enemySpriteSheet = content.Load<Texture2D>("Dungeon Enemies"); 
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
        public ISprite2 CreateGoriyaUpSprite()
        {
            return new GoriyaUpSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateGoriyaUpDamaged()
        {
            return new GoriyaUpDamaged(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateGoriyaDownSprite()
        {
            return new GoriyaDownSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateGoriyaDownDamaged()
        {
            return new GoriyaDownDamaged(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateGoriyaLeftSprite()
        {
            return new GoriyaLeftSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateGoriyaLeftDamaged()
        {
            return new GoriyaLeftDamaged(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateGoriyaRightSprite()
        {
            return new GoriyaRightSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateGoriyaRightDamaged()
        {
            return new GoriyaRightDamaged(enemySpriteSheet, myGame._spriteBatch);
        }

        public ISprite2 CreateBoomerangSprite()
        {
            return new BoomerangSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateOctoEnemySpriteU()
        {
            return new OctoSpriteIdleU(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateOctoEnemySpriteR()
        {
            return new OctoSpriteIdleR(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateOctoEnemySpriteD()
        {
            return new OctoSpriteIdleD(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateOctoEnemySpriteL()
        {
            return new OctoSpriteIdleL(enemySpriteSheet, myGame._spriteBatch);
        }


        public ISprite2 CreateOctoAttackSpriteU()
        {
            return new OctoSpriteAttackU(enemySpriteSheet, myGame._spriteBatch);
        }

        public ISprite2 CreateOctoAttackSpriteR()
        {
            return new OctoSpriteAttackR(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateOctoAttackSpriteD()
        {
            return new OctoSpriteAttackD(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateOctoAttackSpriteL()
        {
            return new OctoSpriteAttackL(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateOctoDamagedSprite()
        {
            return new OctoSpriteDamaged(enemySpriteSheet, myGame._spriteBatch);
        }

        public ISprite2 CreateRockSprite()
        {
            return new RockSprite(enemySpriteSheet, myGame._spriteBatch);
        }

        // More public ISprite returning methods follow
        // ...
    }
}