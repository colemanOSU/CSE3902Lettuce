using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands
{
    public class PreviousBlockCommand : ICommand
    {
        private Dictionary<int, IBlock> blocks;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentBlock;

        public PreviousBlockCommand(Game1 game, Texture2D blockTexture)
        {
            _game = game;
            _texture = blockTexture;
            _currentBlock = _game.currentBlockIndex;

            blocks = new Dictionary<int, IBlock>();
            blocks.Add(1, new BlockSprite1(_texture));
            blocks.Add(2, new BlockSprite2(_texture));
            blocks.Add(3, new BlockSprite3(_texture));
            blocks.Add(4, new BlockSprite4(_texture));
            blocks.Add(5, new BlockSprite5(_texture));
            blocks.Add(6, new BlockSprite6(_texture));
            blocks.Add(7, new BlockSprite7(_texture));
            blocks.Add(8, new BlockSprite8(_texture));
            blocks.Add(9, new BlockSprite9(_texture));
            blocks.Add(10, new BlockSprite10(_texture));

        }

        public void Execute()
        {
            if (blocks.ContainsKey(_currentBlock))
            {
                if (_currentBlock == 1) //if at first block go to last
                {
                    _currentBlock = 10;
                }
                else //decrement to previous block
                {
                    _currentBlock--;
                }

                _game.currentBlock = blocks[_currentBlock];
                _game.currentBlockIndex = _currentBlock; //update index
            }
        }
    }
}