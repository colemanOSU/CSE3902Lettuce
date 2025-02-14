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

        public NextBlockCommand(Game1 game, Texture2D blockTexture)
        {
            _game = game;
            _texture = blockTexture;

            blocks = new Dictionary<int, IBlock>()
            {
                { 1, new BlockSpriteFloorTile(_texture) },
                { 2, new BlockSpriteFloorBlock(_texture) },
                { 3, new BlockSpriteStatueFaceRight(_texture) },
                { 4, new BlockSpriteStatueFaceLeft(_texture) },
                { 5, new BlockSpriteBlack(_texture) },
                { 6, new BlockSpriteSpecks(_texture) },
                { 7, new BlockSpriteNavy(_texture) },
                { 8, new BlockSpriteStairs(_texture) },
                { 9, new BlockSpriteBricks(_texture) },
                { 10, new BlockSpriteStripes(_texture) }
             };

        }

        public void Execute()
        {
            int _currentBlock = _game.currentBlockIndex;

            if (blocks.ContainsKey(_currentBlock))
            {
                if (_currentBlock == 10) //if at last block start over
                {
                    _currentBlock = 1;
                }
                else //increment to next block
                {
                    _currentBlock++;
                }

                _game.currentBlock = blocks[_currentBlock];
                _game.currentBlockIndex = _currentBlock; //update index
            }
        }
    }
}
