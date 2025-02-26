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
        private Vector2 _position;

        public NextBlockCommand(Game1 game, Texture2D blockTexture)
        {
            _game = game;
            _texture = blockTexture;
            _position = new Vector2(300, 300);

            blocks = new Dictionary<int, IBlock>()
            {
                { 1, new BlockSpriteFloorTile(_texture, _position) },
                { 2, new BlockSpriteFloorBlock(_texture, _position) },
                { 3, new BlockSpriteStatueFaceRight(_texture, _position) },
                { 4, new BlockSpriteStatueFaceLeft(_texture, _position) },
                { 5, new BlockSpriteBlack(_texture, _position) },
                { 6, new BlockSpriteSpecks(_texture, _position) },
                { 7, new BlockSpriteNavy(_texture, _position) },
                { 8, new BlockSpriteStairs(_texture, _position) },
                { 9, new BlockSpriteBricks(_texture, _position) },
                { 10, new BlockSpriteStripes(_texture, _position) }
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
