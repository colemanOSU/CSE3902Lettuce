using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using sprint0Real.ItemTempSprites;

namespace sprint0Real.Commands
{
    public class PreviousTempItemCommand : ICommand
    {
        private Dictionary<int, IItemtemp> tempItems;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentItem;

        public PreviousTempItemCommand(Game1 game, Texture2D itemTexture)
        {
            _game = game;
            _texture = itemTexture;

            tempItems = new Dictionary<int, IItemtemp>()
            {
                { 1, new Clock(_texture) },
                { 2, new FiveRupies(_texture) },
                { 3, new LifePotion(_texture) },
                { 4, new SecondPotion(_texture) },
                { 5, new Letter(_texture) },
                { 6, new Food(_texture) },
                { 7, new Sword(_texture) },
                { 8, new WhiteSword(_texture) },
                { 9, new MagicalSword(_texture) },
                { 10, new MagicalShield(_texture) },
                { 11, new Boomerang(_texture) },
                { 12, new MagicalBoomerang(_texture) },
                { 13, new Bomb(_texture) },
                { 14, new Bow(_texture) },
                { 15, new Arrow(_texture) },
                { 16, new BlueCandle(_texture) },
                { 17, new RedCandle(_texture) },
                { 18, new BlueRing(_texture) },
                { 19, new RedRing(_texture) },
                { 20, new PowerBracelet(_texture) },
                { 21, new Recorder(_texture) },
                { 22, new Raft(_texture) },
                { 23, new StepLadder(_texture) },
             };

        }

        public void Execute()
        {
            int _currentItem = _game.currentItemIndex;

            if (tempItems.ContainsKey(_currentItem))
            {
                if (_currentItem == 1) //if at first block go to last
                {
                    _currentItem = 23;
                }
                else //decrement to previous block
                {
                    _currentItem--;
                }

                _game.currentItem = tempItems[_currentItem];
                _game.currentItemIndex = _currentItem; //update index
            }
        }
    }
}