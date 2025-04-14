using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Commands.KeyboardCommands;
using sprint0Real.EnemyStuff;
using sprint0Real.EnemyStuff.Fireballs;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.NPCStuff
{
    public class FireSprite : IGameObject
    {
        private Texture2D sprites;
        private int currentFrame;
        private int totalFrames;
        private Vector2 location;
        private int FPS = 6;
        private float timer = 0f;
        public FireSprite(Vector2 location)
        {
            this.location = location;
            sprites = EnemySpriteFactory.Instance.ReturnOldManSpriteSheet();
            totalFrames = 2;
        }
        public void Attack()
        {
            Rectangle linkLocation = EnemySpriteFactory.Instance.myGame.Link.GetLocation();
            Vector2 destination = new Vector2(linkLocation.X, linkLocation.Y);
            CurrentMap.Instance.Stage(new FireBall(location, destination));
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
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= ((float)1 / FPS))
            {
                timer = 0f;
                currentFrame = (currentFrame + 1) % totalFrames;
            }
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
