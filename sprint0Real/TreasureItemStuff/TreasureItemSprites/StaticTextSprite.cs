using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Interfaces;

namespace sprint0Real.TreasureItemStuff.TreasureItemSprites
{
    public class StaticTextSprite : IGameObject
    {
        private string text;
        private Vector2 position;
        private SpriteFont font;
        private Color color;

        public StaticTextSprite(Vector2 position)
        {
            this.text = "EASTMOST PENINSULA IS THE SECRET";
            this.position = position;
            this.font = TreasureItemSpriteFactory.Instance.GetSpriteFont();
            this.color = Color.White;
        }

        public void Update(GameTime gametime)
        {
            //static
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);
        }
        public Rectangle Rect => new Rectangle((int)position.X, (int)position.Y, 1, 1); // not used
    }
}
