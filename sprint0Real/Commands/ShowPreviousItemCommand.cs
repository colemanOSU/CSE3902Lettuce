using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.ItemTempSprites;

namespace sprint0Real.Commands
{
    public class ShowPreviousItemCommand : ICommand
    {
        private Dictionary<int, IItemtemp> tempItems;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentItem;

        public ShowPreviousItemCommand(Game1 game, Texture2D itemTexture)
        {
            _game = game;
            _texture = itemTexture;

            tempItems = new Dictionary<int, IItemtemp>()
            {
                { 4, new Clock(_texture) },
                { 6, new FiveRupies(_texture) },
                { 7, new LifePotion(_texture) },
                { 8, new SecondPotion(_texture) },
                { 9, new Letter(_texture) },
                { 10, new Food(_texture) },
                { 11, new Sword(_texture) },
                { 12, new WhiteSword(_texture) },
                { 13, new MagicalSword(_texture) },
                { 14, new MagicalShield(_texture) },
                { 15, new Boomerang(_texture) },
                { 16, new MagicalBoomerang(_texture) },
                { 17, new Bomb(_texture) },
                { 18, new Bow(_texture) },
                { 19, new Arrow(_texture) },
                { 20, new BlueCandle(_texture) },
                { 21, new RedCandle(_texture) },
                { 22, new BlueRing(_texture) },
                { 23, new RedRing(_texture) },
                { 24, new PowerBracelet(_texture) },
                { 25, new Recorder(_texture) },
                { 26, new Raft(_texture) },
                { 27, new StepLadder(_texture) },
                { 28, new MagicalRod(_texture) },
                { 29, new BookOfMagic(_texture) },
                { 30, new Key(_texture) },
                { 31, new MagicalKey(_texture) },
                { 32, new Map(_texture) },
                { 33, new Compass(_texture) },
                { 2, new ContainerHeart(_texture) },
                { 1, new Heart(_texture) },
                { 3, new Fairy(_texture) },
                { 5, new Rupy(_texture) },
             };

        }

        public void Execute()
        {
            int _currentItem = _game.currentItemIndex;

            if (tempItems.ContainsKey(_currentItem))
            {
                if (_currentItem == 1) //if at first block go to last
                {
                    _currentItem = 33;
                }
                else //decrement to previous block
                {
                    _currentItem--;
                }

                _game.currentItem = tempItems[_currentItem];
                _game.currentItemIndex = _currentItem; //update index
            }
        }
        public void Initialize(IGameObject objA, IGameObject objB, CollisionDirections direction)
        {
            //for collision detection
        }
    }
}