using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using sprint0Real.GameState;
using System.Xml.Linq;
using sprint0Real.GameState.NameRegistrationandAchievements;
using Microsoft.Xna.Framework.Media;

namespace sprint0Real.GameState.NameRegistrationandAchievements
{
    public class NameRegistrationScene
    {

        private Texture2D spriteSheet;
        private Dictionary<char, Rectangle> charMap;
        private StringBuilder playerName;
        private int cursorX = 0, cursorY = 0;
        private const int maxNameLength = 8;
        private Vector2 gridStart = new Vector2(40, 135); // Adjust as needed
        private int charSpacing = 16;
        private SpriteFont font;
        private float optionScale = 2f;
        private Rectangle titleSrc = new Rectangle(283, 13, 214, 20);
        private Rectangle titleDest = new Rectangle(45, 30, 214, 20);
        private Rectangle cursorSrc = new Rectangle(61, 230, 5, 5);
        Vector2 optionBasePos = new Vector2(130, 600);
        public int recentNameIndex = 0;
        private Vector2 recentStart = new Vector2(110, 225); // Position to draw the names
        private float recentSpacing = 40f;
        private KeyboardState currentKeyState;
        private KeyboardState previousKeyState;
        private Game1 game;

        public enum RegistrationMode { SelectingRecent, TypingNew, SelectingOption }
        public RegistrationMode currentMode = RegistrationMode.SelectingRecent;
        private float scale = 3f;


        private string[,] charGrid = new string[4, 11]
        {
            { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"},
            { "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" },
            { "W", "X", "Y", "Z", "-", ".", ",", "!", "'", "&", "." },
            { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " "},
        };

        private string[] options = { "REGISTER", "END" };
        private int optionIndex = -1; // -1 = not selected

        public NameRegistrationScene(Game1 game, Texture2D spriteSheet, SpriteFont font)
        {
            this.spriteSheet = spriteSheet;
            this.game = game;
            this.font = font;
            playerName = new StringBuilder();

            InitializeCharMap();

        }
        private void InitializeCharMap()
        {
            charMap = new Dictionary<char, Rectangle>();

            charMap['A'] = new Rectangle(304, 127, 13, 14);
            charMap['B'] = new Rectangle(318, 127, 13, 14);
            charMap['C'] = new Rectangle(333, 127, 13, 14);
            charMap['D'] = new Rectangle(349, 127, 13, 14);
            charMap['E'] = new Rectangle(365, 127, 13, 14);
            charMap['F'] = new Rectangle(381, 127, 13, 14);
            charMap['G'] = new Rectangle(397, 127, 13, 14);
            charMap['H'] = new Rectangle(414, 127, 13, 14);
            charMap['I'] = new Rectangle(431, 127, 13, 14);
            charMap['J'] = new Rectangle(446, 127, 13, 14);
            charMap['K'] = new Rectangle(462, 127, 13, 14);
            charMap['L'] = new Rectangle(304, 143, 13, 14);
            charMap['M'] = new Rectangle(318, 143, 13, 14);
            charMap['N'] = new Rectangle(333, 143, 13, 14);
            charMap['O'] = new Rectangle(349, 143, 13, 14);
            charMap['P'] = new Rectangle(365, 143, 13, 14);
            charMap['Q'] = new Rectangle(381, 143, 13, 14);
            charMap['R'] = new Rectangle(397, 143, 13, 14);
            charMap['S'] = new Rectangle(414, 143, 13, 14);
            charMap['T'] = new Rectangle(431, 143, 13, 14);
            charMap['U'] = new Rectangle(446, 143, 13, 14);
            charMap['V'] = new Rectangle(462, 143, 13, 14);
            charMap['W'] = new Rectangle(304, 159, 13, 14);
            charMap['X'] = new Rectangle(318, 159, 13, 14);
            charMap['Y'] = new Rectangle(333, 159, 13, 14);
            charMap['Z'] = new Rectangle(349, 159, 13, 14);
            charMap['-'] = new Rectangle(365, 159, 13, 14);
            charMap['.'] = new Rectangle(381, 159, 13, 14);
            charMap[','] = new Rectangle(397, 159, 13, 14);
            charMap['!'] = new Rectangle(414, 159, 13, 14);
            charMap['\''] = new Rectangle(431, 159, 13, 14);
            charMap['&'] = new Rectangle(446, 159, 13, 14);
            charMap['.'] = new Rectangle(462, 159, 13, 14);
            charMap['0'] = new Rectangle(304, 175, 13, 12);
            charMap['1'] = new Rectangle(318, 175, 13, 12);
            charMap['2'] = new Rectangle(333, 175, 13, 12);
            charMap['3'] = new Rectangle(349, 175, 13, 12);
            charMap['4'] = new Rectangle(365, 175, 13, 12);
            charMap['5'] = new Rectangle(381, 175, 13, 12);
            charMap['6'] = new Rectangle(397, 175, 13, 12);
            charMap['7'] = new Rectangle(414, 175, 13, 12);
            charMap['8'] = new Rectangle(431, 175, 13, 12);
            charMap['9'] = new Rectangle(446, 175, 13, 12);
        }

        public void MoveCursor(int dx, int dy)
        {
            if (optionIndex == -1)
            {
                if (dy == 1 && cursorY == 3)
                {
                    optionIndex = 0;
                }
                else
                {
                    cursorX = Math.Clamp((cursorX + dx + 11) % 11, 0, 10);
                    cursorY = Math.Clamp((cursorY + dy + 4) % 4, 0, 3);
                }

            }
            else
            {
                if (dy == -1)
                {
                    optionIndex = -1; //back up to grid
                }
                else
                {
                    optionIndex = (optionIndex + dx + 2) % 2;
                }
            }
        }

        public void SelectCurrentLetter()
        {
            if (optionIndex == -1 && playerName.Length < maxNameLength)
            {
                char selected = charGrid[cursorY, cursorX][0];
                playerName.Append(selected);
            }
            else if (optionIndex != -1)
            {
                if (options[optionIndex] == "REGISTER")
                {

                    string finalName = playerName.ToString();

                    //Save to full list + mark as used
                    SaveManager.UsePlayer(finalName);

                    //Store this as the current player
                    game.CurrentPlayerName = finalName;
                    MediaPlayer.Stop();
                    game.currentGameState = GameStates.GamePlay;
                    playerName.Clear();
                    optionIndex = -1;
                }
                else
                {
                    game.Exit();
                }
                playerName.Clear();
                optionIndex = -1;
            }
        }
        public void BackspaceLetter()
        {
            if (optionIndex == -1 && playerName.Length > 0)
            {
                playerName.Remove(playerName.Length - 1, 1);
            }
        }

        public void ToggleOptionMode()
        {
            optionIndex = optionIndex == -1 ? 0 : -1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //Draw title
            spriteBatch.Draw(spriteSheet, new Rectangle(titleDest.X, titleDest.Y, (int)(titleSrc.Width * scale), (int)(titleSrc.Height * scale)), titleSrc, Color.White);
            spriteBatch.DrawString(
                font,
                "Select Recent Name or Press TAB to Create New",
                new Vector2(110, 80),
                Color.Gray,
                0f,
                Vector2.Zero,
                1.5f,
                SpriteEffects.None,
                0f
            );

            //Draw entered name
            Vector2 namePos = new Vector2(40, 45) * scale;
            spriteBatch.DrawString(
                font,
                playerName,
                namePos,
                Color.Blue,
                0f,
                Vector2.Zero,
                3f,
                SpriteEffects.None,
                0f
            );

            //Draw character grid
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 11; x++)
                {
                    char c = charGrid[y, x][0];
                    if (charMap.ContainsKey(c))
                    {
                        Vector2 pos = gridStart + new Vector2(x * charSpacing, y * charSpacing);
                        Vector2 scaledPos = pos * scale;
                        Rectangle src = charMap[c];

                        spriteBatch.Draw(spriteSheet,
                            new Rectangle((int)scaledPos.X, (int)scaledPos.Y, (int)(src.Width * scale), (int)(src.Height * scale)),
                            src, Color.White);

                        // Draw cursor if here
                        if (x == cursorX && y == cursorY && optionIndex == -1)
                        {
                            spriteBatch.Draw(spriteSheet, new Rectangle((int)scaledPos.X - 2, (int)scaledPos.Y - 2, (int)(cursorSrc.Width * scale), (int)(cursorSrc.Height * scale)), cursorSrc, Color.White);
                        }
                    }
                }
            }

            //Draw recent names
            for (int i = 0; i < SaveManager.RecentNames.Count; i++)
            {
                string name = SaveManager.RecentNames[i];
                Vector2 pos = recentStart + new Vector2(0, i * recentSpacing);

                Color color = currentMode == RegistrationMode.SelectingRecent && i == recentNameIndex
                    ? Color.Yellow
                    : Color.White;

                spriteBatch.DrawString(
                    font,
                    name,
                    pos,
                    color,
                    0f,
                    Vector2.Zero,
                    1.8f,
                    SpriteEffects.None,
                    0f
                    );
            }

            //Draw options
            for (int i = 0; i < options.Length; i++)
            {
                Vector2 pos = optionBasePos + new Vector2(i * 130, 0) * scale; //spacing between options
                Color color = optionIndex == i ? Color.Yellow : Color.White;

                spriteBatch.DrawString(
                    font,
                    options[i],
                    pos,
                    color,
                    0f,
                    Vector2.Zero,
                    optionScale,
                    SpriteEffects.None,
                    0f
                );
            }

        }
        private bool Pressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key);
        }
        public void Update(GameTime gameTime)
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            if (currentMode == RegistrationMode.SelectingRecent && SaveManager.RecentNames.Count > 0)
            {

                if (Pressed(Keys.Enter))
                {
                    //Use the selected name
                    string selected = SaveManager.RecentNames[recentNameIndex];
                    SaveManager.UsePlayer(selected);
                    game.CurrentPlayerName = selected;
                    MediaPlayer.Stop();
                    game.currentGameState = GameStates.GamePlay;
                }
            }

        }
        public void ChangePlayerChoice()
        {
            if (currentMode == RegistrationMode.SelectingRecent)
            {
                currentMode = RegistrationMode.TypingNew;
                cursorX = 0;
                cursorY = 0;
                optionIndex = -1;
                playerName.Clear();
            }
            else if (currentMode == RegistrationMode.TypingNew)
            {
                currentMode = RegistrationMode.SelectingRecent;
            }
        }
    }
}
