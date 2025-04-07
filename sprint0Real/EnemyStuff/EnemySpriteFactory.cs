using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.BatStuff;
using sprint0Real.EnemyStuff.BoomerangStuff;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.EnemyStuff.Fireballs;
using sprint0Real.EnemyStuff.HandStuff;
using sprint0Real.EnemyStuff.RedGoriyaStuff;
using sprint0Real.EnemyStuff.BTrapStuff;
using sprint0Real.Interfaces;
using sprint0Real.EnemyStuff.SlimeStuff;
using sprint0Real.EnemyStuff.DeathSprites;

namespace sprint0Real.EnemyStuff
{
    public class EnemySpriteFactory
    {
        public Game1 myGame;
        private Texture2D bossesSheet;
        private Texture2D enemySpriteSheet;
        private Texture2D DungeonTileSet;
        private Texture2D Deathsprites;
        private Texture2D OldManSpriteSheet;
        

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
            DungeonTileSet = content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            Deathsprites = content.Load<Texture2D>("NES_-_The_Legend_of_Zelda_-_Enemy_Death");
            OldManSpriteSheet = content.Load<Texture2D>("OldManZelda");
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
            return new BoomerangSprite(enemySpriteSheet);
        }
        
        public ISprite2 CreateSkeletonSprite()
        {
            return new SkeletonSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateBTrapSprite()
        {
            return new BTrapSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateSlimeSprite()
        {
            return new SlimeSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateHandSprite()
        {
            return new HandSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public ISprite2 CreateBatSprite()
        {
            return new BatSprite(enemySpriteSheet, myGame._spriteBatch);
        }
        public Texture2D ReturnDungeonTileSheet()
        {
            return DungeonTileSet;
        }

        public ISprite2 CreateDeathSprite()
        {
            return new DeathSprite(Deathsprites);
        }

        public Texture2D ReturnOldManSpriteSheet()
        {
            return OldManSpriteSheet;
        }
    }
}