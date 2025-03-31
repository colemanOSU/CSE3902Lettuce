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
        private SoundEffect soundEffectTest;
        private Dictionary<String, SoundEffect> itemSoundEffects;

        public static TreasureItemSpriteFactory Instance => instance;

        private TreasureItemSpriteFactory()
        {
            itemSoundEffects = new Dictionary<String, SoundEffect>();
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons");
            soundEffectTest = content.Load<SoundEffect>("LOZ_Get_Heart"); //Don't think this is right sound
            
            itemSoundEffects.Add("ContainerHeart", soundEffectTest);
        }

        public Texture2D GetItemSpriteSheet()
        {
            return itemSheet;
        }

        public SoundEffect GetSoundEffect(String item)
        {
            if (itemSoundEffects.TryGetValue(item, out SoundEffect soundEffect))
            {
                return soundEffect;
            }
            return null;
        }
    }
}
