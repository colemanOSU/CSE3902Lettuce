using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Audio;
using sprint0Real.CollisionBoxes;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.BlockSprites
{
    public class BlockSpriteFloorBlock : IBlock
    {
        private int width = 16;
        private int height = 16;
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        public Vector2 position;
        private bool hasMoved = false;
        private float totalPushedDistance = 0f;
        private float maxPushDistance = 48f;
        private float pushSpeed = 1f;
        private bool isBeingPushed = false;

        public Texture2D texture;

        public BlockSpriteFloorBlock(Vector2 startPos)
        {
            this.texture = BlockSpriteFactory.Instance.GetDungeonTileSet();
            this.position = startPos;

            sourceRectangle = new Rectangle(1001, 11, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width * 3, height * 3);
            //destination(200, 200)
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
            if (isBeingPushed && !hasMoved)
            {
                float pushAmount = pushSpeed;
                position.X -= pushAmount;
                totalPushedDistance += pushAmount;

                if (totalPushedDistance >= maxPushDistance)
                {
                    hasMoved = true;
                    isBeingPushed = false;

                    foreach (var obj in CurrentMap.Instance.ObjectList())
                    {
                        if (obj is SealedTransitionBox sealedDoor)
                        {
                            sealedDoor.Unlock();
                        }
                    }
                }
            }

            destinationRectangle.X = (int)position.X;
            destinationRectangle.Y = (int)position.Y;
        }

        public void TryPush(Link link, CollisionDirections direction)
        {
            Rectangle linkRect = link.Rect;

            // Check if Link is touching the right side of the block
            if (!hasMoved && direction == CollisionDirections.Right && CurrentMap.Instance.MapName == "Level8")
            {
                isBeingPushed = true;
            }
        }
        public void Move(Vector2 direction)
        {
            position += direction;

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
