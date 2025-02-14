using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.ItemTempSprites;

namespace sprint0Real.Commands
{
    public class NextTempItemCommand : ICommand
    {
        private Dictionary<int, IItemtemp> tempItems;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentItem;

        public NextTempItemCommand(Game1 game, Texture2D blockTexture)
        {
            _game = game;
            _texture = blockTexture;

            tempItems = new Dictionary<int, IItemtemp>()
            {
                { 1, new Clock(_texture) },
                { 2, new FiveRupies(_texture) },
                { 3, new LifePotion(_texture) },
             };

        }

        public void Execute()
        {
            int _currentItem = _game.currentItemIndex;

            if (tempItems.ContainsKey(_currentItem))
            {
                if (_currentItem == 3) //if at last block start over
                {
                    _currentItem = 1;
                }
                else //increment to next block
                {
                    _currentItem++;
                }

                _game.currentItem = tempItems[_currentItem];
                _game.currentItemIndex = _currentItem; //update index
            }
        }
    }
}