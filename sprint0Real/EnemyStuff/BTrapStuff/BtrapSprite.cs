using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.EnemyStuff.BTrapStuff
{
    public class BTrapSprite : ISprite2
    {
        private Texture2D sprites;

        public BTrapSprite(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            sprites = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            sourceRectangle = new Rectangle(164, 59, 15, 15);
            destinationRectangle = new Rectangle((int)location.X,
            (int)location.Y, 30, 30);

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            // Static Sprite
        }
    }
}
