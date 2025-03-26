using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemSprites;

namespace sprint0Real.Commands
{
    public class ShowPreviousItemCommand : ICommand
    {
        private Dictionary<int, ITreasureItems> tempItems;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentItem;
        private Vector2 _position;

        public ShowPreviousItemCommand(Game1 game, Texture2D itemTexture)
        {
            _game = game;
            _texture = itemTexture;
            _position = new Vector2(0, 0);

            tempItems = new Dictionary<int, ITreasureItems>()
            {
                { 4, new Clock(_position) },
                { 6, new FiveRupies(_position) },
                { 7, new LifePotion(_position) },
                { 8, new SecondPotion(_position) },
                { 9, new Letter(_position) },
                { 10, new Food(_position) },
                { 11, new Sword(_position) },
                { 12, new WhiteSword(_position) },
                { 13, new MagicalSword(_position) },
                { 14, new MagicalShield(_position) },
                { 15, new Boomerang(_position) },
                { 16, new MagicalBoomerang(_position) },
                { 17, new Bomb(_position) },
                { 18, new Bow(_position) },
                { 19, new Arrow(_position) },
                { 20, new BlueCandle(_position) },
                { 21, new RedCandle(_position) },
                { 22, new BlueRing(_position) },
                { 23, new RedRing(_position) },
                { 24, new PowerBracelet(_position) },
                { 25, new Recorder(_position) },
                { 26, new Raft(_position) },
                { 27, new StepLadder(_position) },
                { 28, new MagicalRod(_position) },
                { 29, new BookOfMagic(_position) },
                { 30, new Key(_position) },
                { 31, new MagicalKey(_position) },
                { 32, new Map(_position) },
                { 33, new Compass(_position) },
                { 2, new ContainerHeart(_position) },
                { 1, new Heart(_position) },
                { 3, new Fairy(_position) },
                { 5, new Rupy(_position) },
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