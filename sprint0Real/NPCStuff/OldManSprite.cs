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
    public class OldManSprite : IGameObject
    {
        private Texture2D sprites;
        private Vector2 location;
        public OldManSprite(Vector2 location)
        {
            this.location = location;
            sprites = EnemySpriteFactory.Instance.ReturnOldManSpriteSheet();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(1, 11, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X,
            (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update(GameTime gametime)
        {
            // Doesn't update
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
