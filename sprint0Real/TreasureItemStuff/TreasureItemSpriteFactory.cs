using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;

namespace sprint0Real.TreasureItemStuff
{
    public class TreasureItemSpriteFactory
    {
        private static TreasureItemSpriteFactory instance = new TreasureItemSpriteFactory();
        private Texture2D itemSheet;

        public static TreasureItemSpriteFactory Instance => instance;

        private TreasureItemSpriteFactory()
        {
        }
        public static ITreasureItems CreateItem(string itemType, Vector2 pos)
        {
            return itemType switch
            {
                "Rupee" => new Rupee(pos),
                "FiveRupies" => new FiveRupies(pos),
                "Heart" => new Heart(pos),
                "Bomb" => new Bomb(pos),
                "Fairy" => new Fairy(pos),
                "Clock" => new Clock(pos),
                "WolfBubble" => new WolfBubble(pos),
                "Triforce" => new Triforce(pos),
                _ => null
            };
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
