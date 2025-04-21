using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.Levels;
using sprint0Real.Audio;

namespace sprint0Real.LinkStuff.LinkSprites
{
    public class KamehamehaSprite : ILinkSpriteTemp
    {
        private Texture2D _texture;
        private Game1 myGame;

        private Rectangle FrameOneSource = new(166, 11, 16, 16);
        private Rectangle FrameTwoSource = new(183, 11, 16, 16);
        private Rectangle CurrentFrameSource;
        private Rectangle DestinationRectangle;

        private BeamSprite Beam = null;

        private const int FRAMESPAN = 8;
        private int FrameCounter;
        private int CurrentFrame;

        private TimeSpan SpentTime;

        private Rectangle CurrentKameSource;
        private Rectangle KameOneFrameOneSource = new(138, 202, 16, 16);
        private Rectangle KameOneFrameTwoSource = new(138, 219, 16, 16);
        private Rectangle KameOneFrameThreeSource = new(155, 202, 16, 16);
        private Rectangle KameOneFrameFourSource = new(155, 219, 16, 16);

        private Rectangle KameTwoFrameOneSource = new(138 + 34, 202, 16, 16);
        private Rectangle KameTwoFrameTwoSource = new(138 + 34, 219, 16, 16);
        private Rectangle KameTwoFrameThreeSource = new(155 + 34, 202, 16, 16);
        private Rectangle KameTwoFrameFourSource = new(155 + 34, 219, 16, 16);

        private Rectangle KameThreeFrameOneSource = new(138 + 34 + 34, 202, 16, 16);
        private Rectangle KameThreeFrameTwoSource = new(138 + 34 + 34, 219, 16, 16);
        private Rectangle KameThreeFrameThreeSource = new(155 + 34 + 34, 202, 16, 16);
        private Rectangle KameThreeFrameFourSource = new(155 + 34 + 34, 219, 16, 16);

        private bool BeamCreated;
        private int Facing;
        private SpriteEffects FlipEffect;

        public KamehamehaSprite(Texture2D texture, Game1 game, Link.Direction facing)
        {
            _texture = texture;
            myGame = game;
            DestinationRectangle = myGame.Link.GetLocation();
            CurrentFrameSource = FrameOneSource;
            CurrentKameSource = KameOneFrameOneSource;

            SoundEffectFactory.Instance.Play(SoundEffectType.Kamehameha);
            FrameCounter = 0;

            BeamCreated = false;
            if (facing == Link.Direction.Left)
            {
                FlipEffect = SpriteEffects.FlipHorizontally;
                Facing = -1;
            } else
            {
                FlipEffect = SpriteEffects.None;
                Facing = 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Link
            spriteBatch.Draw(_texture, DestinationRectangle, CurrentFrameSource, myGame.Link.GetLinkColor(), 0, Vector2.Zero, FlipEffect, 0);

            //Draw Ball
            spriteBatch.Draw(_texture, DestinationRectangle, CurrentKameSource, Color.White, 0, Vector2.Zero, FlipEffect, 0);

            if (Beam != null)
            {
                Beam.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            SpentTime += gameTime.ElapsedGameTime;

            if (FrameCounter >= (FRAMESPAN * 4)) FrameCounter = 0;
            FrameCounter++;
            CurrentFrame = FrameCounter / FRAMESPAN;

            if (SpentTime.CompareTo(TimeSpan.FromSeconds(2.7)) == -1)
            {
                CurrentKameSource = new(140, 220, 1, 1);
            }
            else if (SpentTime.CompareTo(TimeSpan.FromSeconds(5)) == -1)
            {
                switch (CurrentFrame)
                {
                    case 0:
                        CurrentKameSource = KameOneFrameOneSource;
                        break;
                    case 1:
                        CurrentKameSource = KameOneFrameTwoSource;
                        break;
                    case 2:
                        CurrentKameSource = KameOneFrameThreeSource;
                        break;
                    case 3:
                        CurrentKameSource = KameOneFrameFourSource;
                        break;
                }
            }
            else if (SpentTime.CompareTo(TimeSpan.FromSeconds(8.2)) == -1)
            {
                switch (CurrentFrame)
                {
                    case 0:
                        CurrentKameSource = KameTwoFrameOneSource;
                        break;
                    case 1:
                        CurrentKameSource = KameTwoFrameTwoSource;
                        break;
                    case 2:
                        CurrentKameSource = KameTwoFrameThreeSource;
                        break;
                    case 3:
                        CurrentKameSource = KameTwoFrameFourSource;
                        break;
                }
            }
            else if (SpentTime.CompareTo(TimeSpan.FromSeconds(15.7)) == -1)
            {
                switch (CurrentFrame)
                {
                    case 0:
                        CurrentKameSource = KameThreeFrameOneSource;
                        break;
                    case 1:
                        CurrentKameSource = KameThreeFrameTwoSource;
                        break;
                    case 2:
                        CurrentKameSource = KameThreeFrameThreeSource;
                        break;
                    case 3:
                        CurrentKameSource = KameThreeFrameFourSource;
                        break;
                }
            }

            if (SpentTime.CompareTo(TimeSpan.FromSeconds(9.5)) == -1)
            {
                CurrentFrameSource = FrameOneSource;

                
            }
            else if (SpentTime.CompareTo(TimeSpan.FromSeconds(15.7)) == -1)
            {
                CurrentFrameSource = FrameTwoSource;
                CurrentKameSource = new(140, 220, 1, 1);
                if (!BeamCreated)
                {
                    Beam = new BeamSprite(_texture, myGame, Facing);
                    CurrentMap.Instance.ObjectList().Add(Beam);
                    BeamCreated = true;
                }
                
            }
            else
            {
                CurrentMap.Instance.DeStage(Beam);
                Beam = null;
                myGame.KameCamera.Center = new Vector2(Game1.SCREENMIDX, Game1.SCREENMIDY);

                myGame.Link.SetCanAttack(true);
                myGame.Link.SetCanMove(true);
                if (Facing == 1) { myGame.linkSprite = new FaceRightSprite(_texture, myGame); }
                else { myGame.linkSprite = new FaceLeftSprite(_texture, myGame); }
            }

            if (Beam != null)
            {
                Beam.Update(gameTime);
            }
        }
    }
}
