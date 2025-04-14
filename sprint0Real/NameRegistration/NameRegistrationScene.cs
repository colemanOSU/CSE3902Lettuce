using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.NameRegistration
{
    public class NameRegistrationScene
    {

        private Texture2D spriteSheet;
        private Dictionary<char, Rectangle> charMap;
        private StringBuilder playerName;
        private int cursorX = 0, cursorY = 0;
        private const int maxNameLength = 8;
        private Vector2 gridStart = new Vector2(40, 100); // Adjust as needed
        private int charSpacing = 16;


        private string[,] charGrid =
        {
            { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" },
            { "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" },
            { "U", "V", "W", "X", "Y", "Z", ".", ",", "!", "%" },
            { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
        };

        private string[] options = { "REGISTER", "END" };
        private int optionIndex = -1; // -1 = not selected

        public NameRegistrationScene(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
            playerName = new StringBuilder();

            charMap['A'] = new Rectangle(303, 126, 8, 8);
        }
    }
}
