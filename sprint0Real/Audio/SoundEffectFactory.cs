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
using Microsoft.Xna.Framework.Media;
using sprint0Real.TreasureItemStuff;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;

using static sprint0Real.LinkSprites.ItemStateMachine;

namespace sprint0Real.Audio
{
    public class SoundEffectFactory
    {

        private static SoundEffectFactory instance = new SoundEffectFactory();
        public static SoundEffectFactory Instance => instance;
        private Dictionary<SoundEffectType, SoundEffect> soundEffects = new();
        private Dictionary<SongType, Song> songs = new();
        private ContentManager content;
        private SongType? currentSong = null;
        private bool muted = false;
        public bool Muted
        {
            get => muted;
            set
            {
                muted = value;
                if (muted)
                {
                    MediaPlayer.Pause();
                }
                else
                {
                    MediaPlayer.Resume();
                }
            }
        }
        private SoundEffectFactory() { }
        public void LoadAllSounds(ContentManager Content)
        {
            content = Content;

            soundEffects[SoundEffectType.stairs] = content.Load<SoundEffect>("LOZ_Stairs");
            soundEffects[SoundEffectType.bombExplode] = content.Load<SoundEffect>("LOZ_Bomb_Blow");
            soundEffects[SoundEffectType.itemPickup] = content.Load<SoundEffect>("LOZ_Get_Item");
            soundEffects[SoundEffectType.Fanfare] = content.Load<SoundEffect>("LOZ_Fanfare");
            soundEffects[SoundEffectType.HeartPickup] = content.Load<SoundEffect>("LOZ_Get_Heart");
            soundEffects[SoundEffectType.RupeePickup] = content.Load<SoundEffect>("LOZ_Get_Rupee");
            soundEffects[SoundEffectType.boomerandOrArrow] = content.Load<SoundEffect>("LOZ_Arrow_Boomerang");
            soundEffects[SoundEffectType.swordShoot] = content.Load<SoundEffect>("LOZ_Sword_shoot");
            soundEffects[SoundEffectType.bombDrop] = content.Load<SoundEffect>("LOZ_Bomb_Drop");
            soundEffects[SoundEffectType.magicRod] = content.Load<SoundEffect>("LOZ_MagicalRod");
            soundEffects[SoundEffectType.EnemyHit] = content.Load<SoundEffect>("LOZ_Enemy_Hit");
            soundEffects[SoundEffectType.EnemyDie] = content.Load<SoundEffect>("LOZ_Enemy_Die");
            soundEffects[SoundEffectType.doorUnlock] = content.Load<SoundEffect>("LOZ_Door_Unlock");
            soundEffects[SoundEffectType.secretFound] = content.Load<SoundEffect>("LOZ_Secret");
            soundEffects[SoundEffectType.linkHurt] = content.Load<SoundEffect>("LOZ_Link_Hurt");
            soundEffects[SoundEffectType.Kamehameha] = content.Load<SoundEffect>("LinkKamehameha");

            songs[SongType.Title] = content.Load<Song>("01 - Intro");
            songs[SongType.Gameover] = content.Load<Song>("07 - Game Over");
            songs[SongType.Dungeon] = content.Load<Song>("04 - Dungeon");
            songs[SongType.Winning] = content.Load<Song>("06 - Triforce");

        }
        public SoundEffect Get(SoundEffectType type)
        {
            return soundEffects[type];
        }
        public void Play(SoundEffectType type)
        {
            if (!muted && soundEffects.ContainsKey(type))
            {
                soundEffects[type].Play();
            }
        }
        public void ResetSongState()
        {
            currentSong = null;
        }
        public void PlaySong(SongType type, bool repeat = true)
        {
            if(!muted && songs.ContainsKey(type))
            {
                if (currentSong != type)
                {
                    MediaPlayer.IsRepeating = repeat;
                    MediaPlayer.Play(songs[type]);
                    currentSong = type;
                }
            }
        }
        public void ToggleMute()
        {
            Muted = !Muted;
        }
    }
}
