using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;

namespace sprint0Real.LinkStuff.LinkSprites
{
    internal class DeathSprite : ILinkSpriteTemp
    {
        private Rectangle SourceRectangle;
        private Rectangle DestinationRectangle;
        private Rectangle FaceDownSource = new(1, 11, 16, 16);
        private Rectangle FaceHorizontalSource = new (35, 11, 16, 16);
        private Rectangle FaceUpSource = new(69, 11, 16, 16);

        private int FrameCounter;
        private const int FRAMESPAN = 8;
        private int Frame;
        private SpriteEffects Flip;

        private Texture2D _texture;
        private Game1 myGame;

        public DeathSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            DestinationRectangle = myGame.Link.GetLocation();
            SourceRectangle = FaceDownSource;
            Frame = 0;
            Flip = SpriteEffects.None;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws all right facing sprites flipped horizontally
            spriteBatch.Draw(_texture, DestinationRectangle, SourceRectangle, Color.White, 0, Vector2.Zero, Flip, 0);
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (FrameCounter >= (FRAMESPAN * 4)) FrameCounter = 0;
            FrameCounter++;
            Frame = FrameCounter / FRAMESPAN;

            switch (Frame)
            {
                case 0:
                    SourceRectangle = FaceDownSource;
                    Flip = SpriteEffects.None;
                    break;
                case 1:
                    SourceRectangle = FaceHorizontalSource;
                    Flip = SpriteEffects.None;
                    break;
                case 2:
                    SourceRectangle = FaceUpSource;
                    Flip = SpriteEffects.None;
                    break;
                case 3:
                    SourceRectangle = FaceHorizontalSource;
                    Flip = SpriteEffects.FlipHorizontally;
                    break;
            }
        }
    }
}
