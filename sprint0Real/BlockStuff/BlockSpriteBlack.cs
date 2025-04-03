using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;


namespace sprint0Real.BlockSprites
{
    public class BlockSpriteBlack : IBlock
    {
        private int width = 16;
        private int height = 16;
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        public Vector2 position;
        private SoundEffect stairsSound;
        private bool SoundPlayed = false;

        public Texture2D texture;

        public BlockSpriteBlack(Vector2 startPos)
        {
            texture = BlockSpriteFactory.Instance.GetDungeonTileSet();
            position = startPos;

            sourceRectangle = new Rectangle(984, 28, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width * 3, height * 3);
        }
        public void TakeStairs()
        {
            stairsSound = SoundEffectFactory.Instance.getBlockSoundEffect();
            if (!SoundPlayed)
            {
                stairsSound.Play();
                SoundPlayed = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
            destinationRectangle.X = (int)position.X;
            destinationRectangle.Y = (int)position.Y;
        }
        public void Move(Vector2 direction)
        {
            position += direction;

            //example of how to move: block.Move(new Vector2(-1, 0)); // Move left
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
    }
}