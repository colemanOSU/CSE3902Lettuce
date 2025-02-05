using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.EnemyStuff
{
    public class EnemySpriteFactory
    {
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
        public void LoadAllTextures(ContentManager content)
        {
            bossesSheet = content.Load<Texture2D>("Bosses");
            // More Content.Load calls follow
            //...
        }
        public ISprite CreateDragonEnemySprite()
        {
            return new DragonSprite(bossesSheet);
        }
        public ISprite CreateBigEnemySprite()
        {
            return new EnemySprite(enemySpriteSheet, 64, 64);
        }
        public ISprite CreateTintedEnemySprite(ILevel level)
        {
            return new EnemySprite(enemySpriteSheet, level.ColorTheme);
        }
        // More public ISprite returning methods follow
        // ...
    }
}