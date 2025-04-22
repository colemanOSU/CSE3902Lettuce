using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using sprint0Real.GameState;

namespace sprint0Real.GameState.NameRegistrationandAchievements
{
    public class NameRegistrationSceneAlternate
    {
        private const int MaxNameLength = 8;
        private const float OptionScale = 2f;
        private const float Scale = 3f;
        private const int CharSpacing = 16;

        private readonly Texture2D spriteSheet;
        private readonly SpriteFont font;
        private readonly Game1 game;

        private Dictionary<char, Rectangle> charMap;
        private StringBuilder playerName = new StringBuilder();

        private KeyboardState currentKeyState, previousKeyState;

        private int cursorX = 0, cursorY = 0;
        private int optionIndex = -1;
        public int recentNameIndex = 0;

        private Vector2 gridStart = new Vector2(40, 135);
        private Vector2 optionBasePos = new Vector2(130, 600);
        private Vector2 recentStart = new Vector2(110, 225);
        private float recentSpacing = 40f;

        private Rectangle titleSrc = new Rectangle(283, 13, 214, 20);
        private Rectangle titleDest = new Rectangle(45, 30, 214, 20);
        private Rectangle cursorSrc = new Rectangle(61, 230, 5, 5);

        private string[,] charGrid = new string[4, 11]
        {
            { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"},
            { "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" },
            { "W", "X", "Y", "Z", "-", ".", ",", "!", "'", "&", "." },
            { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " "}
        };

        private string[] options = { "REGISTER", "END" };

        public enum RegistrationMode { SelectingRecent, TypingNew, SelectingOption }
        public RegistrationMode currentMode = SaveManager.RecentNames.Count > 0 ? RegistrationMode.SelectingRecent : RegistrationMode.TypingNew;

        public NameRegistrationSceneAlternate(Game1 game, Texture2D spriteSheet, SpriteFont font)
        {
            this.spriteSheet = spriteSheet;
            this.font = font;
            this.game = game;
            InitializeCharMap();
        }

        private void InitializeCharMap()
        {
            charMap = new Dictionary<char, Rectangle>();

            int charWidth = 13;
            int charHeight = 14;
            int numHeight = 12;

            int baseX = 304;
            int baseY = 127;
            int spacing = 15;

            for (int i = 0; i <= 10; i++)
                charMap[(char)('A' + i)] = new Rectangle(baseX + spacing * i, baseY, charWidth, charHeight);

            baseY += charHeight + 2;
            for (int i = 0; i <= 10; i++)
                charMap[(char)('L' + i)] = new Rectangle(baseX + spacing * i, baseY, charWidth, charHeight);

            baseY += charHeight + 2;
            string thirdRow = "WXYZ-.,!'&";
            for (int i = 0; i < thirdRow.Length; i++)
                charMap[thirdRow[i]] = new Rectangle(baseX + spacing * i, baseY, charWidth, charHeight);

            baseY += charHeight + 2;
            for (int i = 0; i <= 9; i++)
                charMap[(char)('0' + i)] = new Rectangle(baseX + spacing * i, baseY, charWidth, numHeight);

            charMap[' '] = new Rectangle(0, 0, 0, 0);
        }

        public void MoveCursor(int dx, int dy)
        {
            if (optionIndex == -1)
            {
                if (dy == 1 && cursorY == 3)
                    optionIndex = 0;
                else
                {
                    cursorX = Math.Clamp((cursorX + dx + 11) % 11, 0, 10);
                    cursorY = Math.Clamp((cursorY + dy + 4) % 4, 0, 3);
                }
            }
            else
            {
                optionIndex = (dy == -1) ? -1 : (optionIndex + dx + 2) % 2;
            }
        }

        public void SelectCurrentLetter()
        {
            if (optionIndex == -1 && playerName.Length < MaxNameLength)
            {
                playerName.Append(charGrid[cursorY, cursorX][0]);
            }
            else if (optionIndex != -1)
            {
                HandleOptionSelection();
            }
        }

        private void HandleOptionSelection()
        {
            string finalName = playerName.ToString();

            if (options[optionIndex] == "REGISTER")
            {
                SaveManager.UsePlayer(finalName);
                game.CurrentPlayerName = finalName;
                MediaPlayer.Stop();
                game.currentGameState = GameStates.GamePlay;
            }
            else
            {
                game.Exit();
            }

            playerName.Clear();
            optionIndex = -1;
        }

        public void BackspaceLetter()
        {
            if (optionIndex == -1 && playerName.Length > 0)
                playerName.Remove(playerName.Length - 1, 1);
        }

        public void ToggleOptionMode()
        {
            optionIndex = (optionIndex == -1) ? 0 : -1;
        }

        public void Update(GameTime gameTime)
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            if (currentMode == RegistrationMode.SelectingRecent && SaveManager.RecentNames.Count > 0 && Pressed(Keys.Enter))
            {
                string selected = SaveManager.RecentNames[recentNameIndex];
                SaveManager.UsePlayer(selected);
                game.CurrentPlayerName = selected;
                MediaPlayer.Stop();
                game.currentGameState = GameStates.GamePlay;
            }
        }

        public void ChangePlayerChoice()
        {
            if (currentMode == RegistrationMode.SelectingRecent)
            {
                currentMode = RegistrationMode.TypingNew;
                cursorX = cursorY = 0;
                optionIndex = -1;
                playerName.Clear();
            }
            else if (SaveManager.RecentNames.Count > 0)
            {
                currentMode = RegistrationMode.SelectingRecent;
            }
        }

        private bool Pressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTitle(spriteBatch);
            DrawEnteredName(spriteBatch);
            DrawCharGrid(spriteBatch);
            DrawRecentNames(spriteBatch);
            DrawOptions(spriteBatch);
        }

        private void DrawTitle(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, new Rectangle(titleDest.X, titleDest.Y, (int)(titleSrc.Width * Scale), (int)(titleSrc.Height * Scale)), titleSrc, Color.White);
            spriteBatch.DrawString(font, "Select Recent Name or Press TAB to Create New", new Vector2(110, 80), Color.Gray, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
        }

        private void DrawEnteredName(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, playerName, new Vector2(40, 45) * Scale, Color.Blue, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }

        private void DrawCharGrid(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 11; x++)
                {
                    char c = charGrid[y, x][0];
                    if (!charMap.TryGetValue(c, out Rectangle src)) continue;

                    Vector2 pos = gridStart + new Vector2(x * CharSpacing, y * CharSpacing);
                    Vector2 scaledPos = pos * Scale;

                    spriteBatch.Draw(spriteSheet, new Rectangle((int)scaledPos.X, (int)scaledPos.Y, (int)(src.Width * Scale), (int)(src.Height * Scale)), src, Color.White);

                    if (x == cursorX && y == cursorY && optionIndex == -1)
                    {
                        spriteBatch.Draw(spriteSheet, new Rectangle((int)scaledPos.X - 2, (int)scaledPos.Y - 2, (int)(cursorSrc.Width * Scale), (int)(cursorSrc.Height * Scale)), cursorSrc, Color.White);
                    }
                }
            }
        }

        private void DrawRecentNames(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < SaveManager.RecentNames.Count; i++)
            {
                string name = SaveManager.RecentNames[i];
                Vector2 pos = recentStart + new Vector2(0, i * recentSpacing);
                Color color = (currentMode == RegistrationMode.SelectingRecent && i == recentNameIndex) ? Color.Yellow : Color.White;

                spriteBatch.DrawString(font, name, pos, color, 0f, Vector2.Zero, 1.8f, SpriteEffects.None, 0f);
            }
        }

        private void DrawOptions(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Vector2 pos = optionBasePos + new Vector2(i * 130, 0) * Scale;
                Color color = (optionIndex == i) ? Color.Yellow : Color.White;

                spriteBatch.DrawString(font, options[i], pos, color, 0f, Vector2.Zero, OptionScale, SpriteEffects.None, 0f);
            }
        }
    }
}
