using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.BlockSprites
{
    public class BlockSpriteFactory
    {
        private static BlockSpriteFactory instance = new BlockSpriteFactory();
        private Texture2D dungeonTileSet;

        public static BlockSpriteFactory Instance => instance;

        private BlockSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            dungeonTileSet = content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
        }

        public Texture2D GetDungeonTileSet()
        {
            return dungeonTileSet;
        }
    }
}
