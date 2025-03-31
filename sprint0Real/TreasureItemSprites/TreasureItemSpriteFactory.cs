using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.TreasureItemSprites
{
    public class TreasureItemSpriteFactory
    {
        private static TreasureItemSpriteFactory instance = new TreasureItemSpriteFactory();
        private Texture2D itemSheet;

        public static TreasureItemSpriteFactory Instance => instance;

        private TreasureItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons");
        }

        public Texture2D GetItemSpriteSheet()
        {
            return itemSheet;
        }
    }
}
