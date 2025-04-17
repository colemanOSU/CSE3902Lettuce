using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Input;

namespace sprint0Real.GameState.NameRegistrationandAchievements
{
    public class AchievementScreen
    {
        private SpriteFont font;
        private Game1 game;

        public AchievementScreen(Game1 game, SpriteFont font)
        {
            this.font = font;
            this.game = game;
        }
        public void Update(GameTime gametime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            SaveFile save = SaveManager.GetSave(game.CurrentPlayerName);

            if (save == null)
            {
                spriteBatch.DrawString(font, "No save file loaded.", new Vector2(50, 50), Color.White);
                spriteBatch.End();
                return;
            }

            spriteBatch.DrawString(
                font,
                "ACHIEVEMENTS",
                new Vector2(60, 40),
                Color.White,
                0f,
                Vector2.Zero,
                2.5f,
                SpriteEffects.None,
                0f
            );

            int y = 120;
            foreach (var pair in AchievementManager.AllAchievements)
            {
                string achievementTitle = pair.Key;
                string description = pair.Value;

                bool unlocked = save.Achievements.Contains(achievementTitle);
                Color color = unlocked ? Color.Gold : Color.Gray;

                spriteBatch.DrawString(
                    font,
                    $"{achievementTitle}",
                    new Vector2(80, y),
                    color,
                    0f,
                    Vector2.Zero,
                    1.2f,
                    SpriteEffects.None,
                    0f
                );
                if (unlocked)
                {
                    y += 25;
                }
                else
                {
                    y += 35;
                }

                if (unlocked)
                {
                    spriteBatch.DrawString(font, $"{description}", new Vector2(100, y), Color.White);
                    y += 35;
                }
            }

        }
    }
}
