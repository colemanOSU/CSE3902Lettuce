using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Commands;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using sprint0Real.Collisions;
using sprint0Real.Levels;
using sprint0Real.LinkSprites;
using Microsoft.Xna.Framework.Audio;

namespace sprint0Real.Items.ItemSprites
{

    internal class FireSprite : ILinkSprite
    {
        public bool IsActive { get; private set; } = false; // Start inactive
        private SoundEffect soundEffect;
        private bool soundPlayed = false;
        public void Disable()
        {
            IsActive = false; // This keeps the weapon in memory but disables it
        }

        public void Activate()
        {
            IsActive = true;
        }
        private Rectangle sourceRectangle = new(191, 185, 16, 16);
        private Rectangle destinationRectangle;

        private Texture2D _texture;
        private readonly Game1 myGame;
        private Vector2 startPosition;
        private Vector2 velocity;
        private double _timer;
        private bool isMoving = true;
        private Vector2 _position;
        private double delayTimer;
        private double delayDuration = 0.5;
        private bool isDelaying = false;
        private float travelDistance = 180f;
        private Vector2 finalPosition;


        public FireSprite(Texture2D texture, Game1 game)
        {

            _texture = texture;
            myGame = game;
            _timer = 0;
            velocity = Vector2.Zero;
            GetPosition(game.Link.GetFacing());
            _position = startPosition;
            destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
            soundEffect = SoundEffectFactory.Instance.GetWeaponSoundEffect(ItemStateMachine.Item.Fire);

        }
        public Rectangle Rect
        {
            get { return destinationRectangle; }
        }
        public void GetPosition(Link.Direction direction)
        {
            switch (direction)
            {
                case Link.Direction.Right:
                    velocity = new Vector2(200,0);
                    startPosition = new(myGame.Link.GetLocation().X + 16 *3, myGame.Link.GetLocation().Y);
                    break;
                case Link.Direction.Left:
                    velocity = new Vector2(-200, 0);
                    startPosition = new(myGame.Link.GetLocation().X - 9 * 3, myGame.Link.GetLocation().Y);
                    break;
                case Link.Direction.Up:
                    velocity = new Vector2(0, -200);
                    startPosition = new(myGame.Link.GetLocation().X + 3 * 3, myGame.Link.GetLocation().Y-16*3);
                    break;
                case Link.Direction.Down:
                    velocity = new Vector2(0, 200);
                    startPosition = new(myGame.Link.GetLocation().X + 3 * 3, myGame.Link.GetLocation().Y + 14*3);
                    break;   
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isDelaying)
            {
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
                return;
            }
            if (isMoving)
            {
                spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            }

        }

        public void Update(GameTime gameTime)
        {
            if (!soundPlayed)
            {
                soundEffect.Play();
                soundPlayed = true;
            }
            _timer += gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (isMoving)
            {
                _position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (_timer > 1)
                {
                    isMoving = false;
                    velocity = Vector2.Zero;
                    finalPosition = _position;
                    isDelaying = true;
                    delayTimer = 0;
                }
            }
            destinationRectangle = new((int)_position.X, (int)_position.Y, 16 * 3, 16 * 3);
            if (isDelaying)
            {
                delayTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (delayTimer >= delayDuration)
                {
                    isDelaying = false;
                    myGame.weaponItems = new NullSprite(_texture,myGame);
                }
            }
        }

    }
}
