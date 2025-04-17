using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0Real.GameState.NameRegistrationandAchievements
{
    public class AchievementPopup
    {
        private string message;
        private float timer;
        private const float displayTime = 4.5f;
        private Vector2 position;
        private float fade = 0f;

        public bool IsVisible => timer < displayTime;

        public AchievementPopup(string achievementName)
        {
            message = $"Achievement Unlocked: {achievementName} (SPACE to view)";
            timer = 0f;
            position = new Vector2(Game1.SCREENWIDTH / 2f, Game1.SCREENHEIGHT - 80);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Fade in first 0.5s, fade out last 0.5s
            if (timer < 0.5f)
                fade = timer / 0.5f;
            else if (timer > displayTime - 0.5f)
                fade = (displayTime - timer) / 0.5f;
            else
                fade = 1f;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (!IsVisible) return;

            Vector2 size = font.MeasureString(message);
            Vector2 drawPos = position - size / 2f;

            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            rect.SetData(new[] { Color.Black * 0.7f });
            spriteBatch.Draw(rect, new Rectangle((int)drawPos.X - 10, (int)drawPos.Y - 5, (int)size.X + 20, (int)size.Y + 10), Color.White * fade);
            spriteBatch.DrawString(font, message, drawPos, Color.White * fade);
        }
    }
}
