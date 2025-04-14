using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.NPCStuff
{
    public class OldManSprite : INPC
    {
        private Texture2D sprites;
        public Vector2 location { get; set; }
        private int FPS = 6;
        private int health = 10;

        private float damageTimer = 0f;
        private float damageDelay = 1f;
        private bool damageFlag = false;

        private float attackTimer = 0f;
        private float attackDelay = 3f;
        private bool attackFlag = false;
        public OldManSprite(Vector2 location)
        {
            this.location = location;
            sprites = EnemySpriteFactory.Instance.ReturnOldManSpriteSheet();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(1, 11, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X,
            (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);

            spriteBatch.Draw(sprites, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            // Check whether to attack
            if (attackFlag)
            {
                attackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (attackTimer >= attackDelay)
                {
                    attackTimer = 0f;
                    SignalAttack();
                }
            }

            // Check if recently took damage
            if (damageFlag)
            {
                damageTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (damageTimer >= damageDelay)
                {
                    damageTimer = 0f;
                    damageFlag = false;
                }
            }
        }

        private void SignalAttack()
        {
            foreach(FireSprite fire in CurrentMap.Instance.ObjectList().OfType<FireSprite>())
            {
                fire.Attack();
            }
        }

        private void SignalDespawn()
        {
            foreach (FireSprite fire in CurrentMap.Instance.ObjectList().OfType<FireSprite>())
            {
                CurrentMap.Instance.DeStage(fire);
            }
        }

        public void TakeDamage(int damage)
        {
            if (!damageFlag)
            {
                health -= damage;
                damageFlag = true;
            }

            if (health <= 5)
            {
                attackFlag = true;
            }

            if (health <= 0)
            {
                SignalDespawn();
                CurrentMap.Instance.DeStage(this);
            }
        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, 16 * Game1.RENDERSCALE, 16 * Game1.RENDERSCALE);
            }
        }
    }
}
