﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.DinoStuff.DinoHurtSprites
{
    public class DinoHurtUpSprite : ISprite2
    {
        private Texture2D sprites;

        public DinoHurtUpSprite(Texture2D spriteSheet)
        {
            sprites = spriteSheet;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(52, 58, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X,
            (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            // Nothing to update
        }
    }
}
