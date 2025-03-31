using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.LinkSprites;

namespace sprint0Real.Items.ItemSprites
{
    internal class MagicRod : ILinkSprite
    {
        public bool IsActive { get; private set; } = false; // Start inactive
        private SoundEffect magicRodSoundEffect;
        private bool SoundPlayed = false;

        public void Disable()
        {
            IsActive = false; // This keeps the weapon in memory but disables it
        }

        public void Activate()
        {
            IsActive = true;
        }
        private Rectangle sourceRectangle = new(124, 78, 14, 14);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private Game1 myGame;
        private int frameCount = 4;
        private float _frameSpeed = 0.2f;
        private int _currentFrame;
        private double _timer;
        private bool flag = false;


        public MagicRod(Texture2D texture, Game1 game)
        {
            _texture = texture;
            myGame = game;
            _timer = 0;
            destinationRectangle = new Rectangle(game.Link.GetLocation().X + 13, game.Link.GetLocation().Y + 1, 14 * 3, 14 * 3);
            magicRodSoundEffect = SoundEffectFactory.Instance.GetWeaponSoundEffect(ItemStateMachine.Item.MagicRod);
        }
        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (flag) return;
            switch (myGame.Link.GetFacing())
            {
                case Link.Direction.Right:
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                    break;
                case Link.Direction.Left:
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                    break;
                case Link.Direction.Up:
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                    break;
                case Link.Direction.Down:
                    spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                    break;
            }

        }

        public void Update(GameTime gameTime)
        {
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (_timer > _frameSpeed)
            {
                _currentFrame = (_currentFrame + 1) % frameCount;
                _timer -= _frameSpeed;
            }
            if (!SoundPlayed)
            {
                magicRodSoundEffect.Play();
                SoundPlayed = true;
            }

            //update destination rectangle for collision handling and draw
            switch (myGame.Link.GetFacing())
            {
                case Link.Direction.Right:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(311, 82, 13, 8);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 14 * 3, myGame.Link.GetLocation().Y + 5 * 3, 13 * 3, 8 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(337, 81, 11, 11);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 12 * 3, myGame.Link.GetLocation().Y + 4 * 3, 11 * 3, 11 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(364, 84, 4, 4);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 15 * 3, myGame.Link.GetLocation().Y + 7 * 3, 4 * 3, 4 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    break;
                case Link.Direction.Left:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(311, 82, 13, 8);
                            destinationRectangle = new(myGame.Link.GetLocation().X - 11 * 3, myGame.Link.GetLocation().Y + 15, 13 * 3, 8 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(337, 81, 11, 11);
                            destinationRectangle = new(myGame.Link.GetLocation().X - 7 * 3, myGame.Link.GetLocation().Y + 12, 11 * 3, 11 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(364, 84, 4, 4);
                            destinationRectangle = new(myGame.Link.GetLocation().X - 3 * 3, myGame.Link.GetLocation().Y + 21, 4 * 3, 4 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    break;
                case Link.Direction.Up:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(300, 97, 8, 13);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 3 * 3, myGame.Link.GetLocation().Y - 13 * 3, 8 * 3, 13 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(317, 98, 8, 11);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 3 * 3, myGame.Link.GetLocation().Y - 11 * 3, 8 * 3, 11 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(334, 106, 8, 3);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 9, myGame.Link.GetLocation().Y - 12, 8 * 3, 3 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    break;
                case Link.Direction.Down:
                    switch (_currentFrame)
                    {
                        case 0:
                            sourceRectangle = new(302, 61, 8, 12);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 15, myGame.Link.GetLocation().Y + 15 * 3, 8 * 3, 12 * 3);
                            break;
                        case 1:
                            sourceRectangle = new(321, 61, 5, 9);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 21, myGame.Link.GetLocation().Y + 14 * 3, 5 * 3, 9 * 3);
                            break;
                        case 2:
                            sourceRectangle = new(338, 61, 4, 5);
                            destinationRectangle = new(myGame.Link.GetLocation().X + 21, myGame.Link.GetLocation().Y + 14 * 3, 4 * 3, 5 * 3);
                            break;
                        case 3:
                            flag = true;
                            break;
                    }
                    break;
            }

            if (flag == true)
            {
                myGame.Link.SetCanMove(true);
                myGame.Link.SetCanAttack(true);
                myGame.weaponItemsB = new NullSprite(_texture, myGame);
            }
        }

    }
}
