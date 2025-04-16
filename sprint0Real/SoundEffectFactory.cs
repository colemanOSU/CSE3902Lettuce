using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;
using sprint0Real.LinkSprites;
using sprint0Real.TreasureItemStuff;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;

using static sprint0Real.LinkSprites.ItemStateMachine;

namespace sprint0Real
{
    public class SoundEffectFactory
    {
        private static SoundEffectFactory instance = new SoundEffectFactory();
        private SoundEffect stairs;
        private SoundEffect LinkWeapon;
        private ContentManager content;
        private SoundEffect bombExplode;
        private SoundEffect itemPickup;
        private SoundEffect HeartPickup;
        private SoundEffect RupeePickup;
        private SoundEffect Fanfare;
        private SoundEffect boomerangOrArrow;
        private SoundEffect swordShoot;
        private SoundEffect bombDrop;
        private SoundEffect magicRod;
        private SoundEffect EnemyHit;
        private SoundEffect doorUnlock;
        private SoundEffect EnemyDie;
        private SoundEffect secretFound;

        public static SoundEffectFactory Instance => instance;
        private SoundEffectFactory() { }
        public void LoadAllTextures(ContentManager Content)
        {
            this.content = Content;
            stairs = content.Load<SoundEffect>("LOZ_Stairs");
            bombExplode = content.Load<SoundEffect>("LOZ_Bomb_Blow");
            itemPickup = content.Load<SoundEffect>("LOZ_Get_Item");
            Fanfare = content.Load<SoundEffect>("LOZ_Fanfare");
            HeartPickup = content.Load<SoundEffect>("LOZ_Get_Heart");
            RupeePickup = content.Load<SoundEffect>("LOZ_Get_Rupee");
            boomerangOrArrow = content.Load<SoundEffect>("LOZ_Arrow_Boomerang");
            swordShoot = content.Load<SoundEffect>("LOZ_Sword_shoot");
            bombDrop = content.Load<SoundEffect>("LOZ_Bomb_Drop");
            magicRod = content.Load<SoundEffect>("LOZ_MagicalRod");
            EnemyHit = content.Load<SoundEffect>("LOZ_Enemy_Hit");
            EnemyDie = content.Load<SoundEffect>("LOZ_Enemy_Die");
            doorUnlock = content.Load<SoundEffect>("LOZ_Door_Unlock");
            secretFound = content.Load<SoundEffect>("LOZ_Secret");

        }

        public SoundEffect getSecretSound()
        {
            return secretFound;
        }
        public SoundEffect getBlockSoundEffect()
        {
            return stairs;
        }
        public SoundEffect getSwordShoot()
        {
            return swordShoot;
        }
        public SoundEffect getBombDrop()
        {
            return bombDrop;
        }
        public SoundEffect getArrowOrBoomerang()
        {
            return boomerangOrArrow;
        }
        public SoundEffect getMagicRod()
        {
            return magicRod;
        }

        public SoundEffect getDoorUnlock()
        {
            return doorUnlock;
        }
       
        public SoundEffect getEnemyHit()
        {
            return EnemyHit;
        }
        public SoundEffect getEnemyDie()
        {
            return EnemyDie;
        }
        public SoundEffect GetBombExplode()
        {
            return bombExplode;
        }
        public SoundEffect getItemSoundEffect()
        {
            return itemPickup;
        }
        public SoundEffect getFanfareSoundEffect()
        {
            return Fanfare;
        }
        public SoundEffect getHeartSoundEffect()
        {
            return HeartPickup;
        }
        public SoundEffect getRupeeSoundEffect()
        {
            return RupeePickup;
        }
    }
}
