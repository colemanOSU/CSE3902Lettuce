using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.TreasureItemStuff;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;


namespace sprint0Real.Commands.KeyboardCommands
{
    public class ShowNextItemCommand// : ICommand
    {
        //PROBABLY CAN DELETE ENTIRE CLASS

        /*private Dictionary<int, ITreasureItems> tempItems;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentItem;
        private Vector2 _position;

        public ShowNextItemCommand(Game1 game, Texture2D itemTexture)
        {
            _game = game;
            _texture = itemTexture;
            _position = new Vector2(0, 0);

            tempItems = new Dictionary<int, ITreasureItems>()
            {
                { 1, new Sword(_position) },
                { 2, new Bomb(_position) },
                { 3, new Boomerang(_position) },
                { 4, new Bow(_position) },
                { 5, new WhiteSword(_position) },
                { 6, new MagicalSword(_position) },
                { 7, new MagicalShield(_position) },
                { 8, new MagicalBoomerang(_position ) },
                { 9, new Arrow(_position) },
                { 10, new Heart(_position) },
                { 11, new ContainerHeart(_position) },
                { 12, new Fairy(_position) },
                { 13, new Clock(_position) },
                { 14, new Rupy(_position) },
                { 15, new FiveRupies(_position) },
                { 16, new LifePotion(_position) },
                { 17, new SecondPotion(_position) },
                { 18, new Letter(_position) },
                { 19, new Food(_position) },
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
             };

        }

        public void Execute()
        {
            int _currentItem = _game.currentItemIndex;

            if (tempItems.ContainsKey(_currentItem))
            {
                if (_currentItem == 33) //if at last block start over
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
        }*/
    }
}