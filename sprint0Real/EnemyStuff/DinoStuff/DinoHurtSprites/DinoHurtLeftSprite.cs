using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DinoStuff.DinoHurtSprites
{
    public class DinoHurtLeftSprite : ISprite2
    {
        private Texture2D sprites;

        public DinoHurtLeftSprite(Texture2D spriteSheet)
        {
            sprites = spriteSheet;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(135, 58, 28, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X,
            (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 1);
        }

        public void Update()
        {
            // Nothing to update
        }
    }
}
