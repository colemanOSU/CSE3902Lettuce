using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.NPCStuff
{
    public class FireSprite : IGameObject
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;
        private Vector2 location;

        public FireSprite(Vector2 location)
        {
            this.location = location;
            sprites = EnemySpriteFactory.Instance.ReturnOldManSpriteSheet();
            totalFrames = 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(52, 11, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
            else
            {
                sourceRectangle = new Rectangle(69, 11, 16, 16);
                destinationRectangle = new Rectangle((int)location.X,
                (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
        }
    }
}
