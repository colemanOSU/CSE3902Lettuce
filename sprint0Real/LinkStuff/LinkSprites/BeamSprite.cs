using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using sprint0Real.Interfaces;
namespace sprint0Real.LinkStuff.LinkSprites
{
    internal class BeamSprite : ILinkSprite
    {
        private Texture2D _texture;
        private Game1 myGame;

        private Rectangle StartSource = new(276, 251, 17, 55);
        private Rectangle MidSource = new(294, 251, 16, 55);
        private Rectangle EndSource = new(311, 251, 16, 55);
        private Rectangle LinkDestination;
        private Rectangle StartDestination;
        private Rectangle EndDestination;

        private int Scale = Game1.RENDERSCALE;
        private int BeamLength;

        private int Facing;
        private SpriteEffects FlipEffect;

        private TimeSpan ElapsedTime;

        public Rectangle Rect { get; private set; }

        public bool IsActive { get; private set; } = true;

        public BeamSprite(Texture2D texture, Game1 game, int facing)
        {
            _texture = texture;
            myGame = game;
            LinkDestination = myGame.Link.GetLocation();
            Rect = Rectangle.Empty;
            BeamLength = 0;

            Facing = facing;
            FlipEffect = (Facing == 1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            StartDestination = new Rectangle(LinkDestination.X + 16 * Facing * Scale, LinkDestination.Y - 16 * Scale, 17 * Scale, 55 * Scale);
            ElapsedTime = TimeSpan.Zero;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw first sprite of beam
            spriteBatch.Draw(_texture, StartDestination, StartSource, Color.White, 0, Vector2.Zero, FlipEffect, 0);

            //Draw middle sprites of beam
            int i;
            for (i = 0; i < BeamLength; i++)
            {
                spriteBatch.Draw(_texture, new Rectangle(StartDestination.X + (i + 1) * 16 * Facing * Scale, StartDestination.Y, 16 *Scale, 55 * Scale), MidSource, Color.White, 0, Vector2.Zero, FlipEffect, 0);
            }
            //Draw last sprite of beam
            spriteBatch.Draw(_texture, new Rectangle(StartDestination.X + (i + 1)*16* Scale * Facing, StartDestination.Y, 16 * Scale, 55 * Scale), EndSource, Color.White, 0, Vector2.Zero, FlipEffect, 0);
        }

        public void Update(GameTime gameTime)
        {
            myGame.CameraShake();
            ElapsedTime = ElapsedTime.Add(gameTime.ElapsedGameTime);
            if (ElapsedTime.CompareTo(TimeSpan.FromSeconds(0.25)) > 0)
            {
                BeamLength++;
                ElapsedTime = TimeSpan.Zero;
            }

            if (Facing == 1) {
                Rect = new Rectangle(StartDestination.X, StartDestination.Y, 16 * Scale * (BeamLength + 2), 55 * Scale);
            } else
            {
                Rect = new Rectangle(StartDestination.X - 16 * Scale * (BeamLength + 2), StartDestination.Y, 16 * Scale * (BeamLength + 2), 55 * Scale);
            }

         
            
        }


        public void Activate()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }
    }
}
