using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands
{
    public class NextBlockCommand : ICommand
    {
        private Dictionary<int, IBlock> blocks;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentBlock;

        public NextBlockCommand(Game1 game, int currentBlock, Texture2D blockTexture)
        {
            _game = game;
            _texture = blockTexture;
            _currentBlock = currentBlock;

            if(_currentBlock == 10) //if at last block start over
            {
                _currentBlock = 1;
            }
            else //increment to next block
            {
                _currentBlock++;
            }

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
                _game.currentBlock = blocks[_currentBlock];
            }
        }
    }
}
