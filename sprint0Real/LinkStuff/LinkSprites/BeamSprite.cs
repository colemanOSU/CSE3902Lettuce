using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0Real.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata.Ecma335;
using System.Numerics;
using System.Diagnostics;
using sprint0Real.Levels;

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
        private bool Active;

        private TimeSpan ElapsedTime;

        public Rectangle Rect { get; private set; }

        public bool IsActive { get; private set; } = true;

        public BeamSprite(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            LinkDestination = myGame.Link.GetLocation();
            StartDestination = new Rectangle(LinkDestination.X + 16 * Scale, LinkDestination.Y - 16 * Scale, 17 * Scale, 55 * Scale);
            ElapsedTime = TimeSpan.Zero;
            BeamLength = 0;

            Rect = Rectangle.Empty;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw first sprite of beam
            spriteBatch.Draw(_texture, StartDestination, StartSource, Color.White);

            //Draw middle sprites of beam
            int i;
            for (i = 0; i < BeamLength; i++)
            {
                spriteBatch.Draw(_texture, new Rectangle(StartDestination.X + (i + 1) * 16 * Scale, StartDestination.Y, 16 *Scale, 55 * Scale), MidSource, Color.White);
            }
            //Draw last sprite of beam
            spriteBatch.Draw(_texture, new Rectangle(StartDestination.X + (i + 1)*16*Scale, StartDestination.Y, 16 * Scale, 55 * Scale), EndSource, Color.White);
        }

        public void Update(GameTime gameTime)
        {

            ElapsedTime = ElapsedTime.Add(gameTime.ElapsedGameTime);
            Debug.WriteLine(ElapsedTime.TotalSeconds);
            if (ElapsedTime.CompareTo(TimeSpan.FromSeconds(0.25)) > 0)
            {
                BeamLength++;
                Debug.WriteLine("Beam" + BeamLength);
                ElapsedTime = TimeSpan.Zero;
            }

            Rect = new Rectangle(StartDestination.X, StartDestination.Y, 16 * Scale * (BeamLength + 2), 55 * Scale);
        }


        public void Activate()
        {
            Active = true;
        }

        public void Disable()
        {
            Active = false;
        }
    }
}
