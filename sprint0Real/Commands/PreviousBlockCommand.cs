using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.BlockSprites;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands
{
    public class PreviousBlockCommand : ICommand
    {
        private Dictionary<int, IBlock> blocks;
        private Game1 _game;
        private Texture2D _texture;
        private int _currentBlock;
        private Vector2 _position;

        public PreviousBlockCommand(Game1 game, Texture2D blockTexture)
        {
            _game = game;
            _texture = blockTexture;
            _position = new Vector2(300, 300);

            blocks = new Dictionary<int, IBlock>()
            {
                { 1, new BlockSpriteFloorTile(_position) },
                { 2, new BlockSpriteFloorBlock(_position) },
                { 3, new BlockSpriteStatueFaceRight(_position) },
                { 4, new BlockSpriteStatueFaceLeft(_position) },
                { 5, new BlockSpriteBlack(_position) },
                { 6, new BlockSpriteSpecks(_position) },
                { 7, new BlockSpriteNavy(_position) },
                { 8, new BlockSpriteStairs(_position) },
                { 9, new BlockSpriteBricks(_position) },
                { 10, new BlockSpriteStripes(_position) }
             };

        }

        public void Execute()
        {
            _currentBlock = _game.currentBlockIndex;

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