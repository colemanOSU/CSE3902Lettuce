using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.TreasureItemStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.WolfLink
{
    public class WolfSpriteFactory
    {
        private static WolfSpriteFactory instance = new WolfSpriteFactory();
        private Texture2D texture;

        public static WolfSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private WolfSpriteFactory()
        {

        }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("WolfSprite");
        }
        public Texture2D GetItemSpriteSheet()
        {
            return texture;
        }
    }
}
