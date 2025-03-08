using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Levels;
using sprint0Real.LinkStuff2.Interface;
using sprint0Real.LinkStuff2.Items;

namespace sprint0Real.LinkStuff2
{
    public class Link
    {
        public Rectangle destinationRectangle;
        private ILinkSprite mySprite;
        private LinkStateMachine stateMachine;
        private Color LinkSpriteColor;
        private Vector2 momentumVector;
        
        private List<IItem> bag;
        private IItem CurrentItem;
        private int FPS = 24;
        private float timer;
        private int health = 10;
        public int SPEED = 2;

        public  Link()
        {
            stateMachine = new LinkStateMachine(this);
            //mySprite = LinkSpriteFactory.Instance.Create();
        }

        public void PickUpItem(IItem item)
        {
            bag.Add(item);
            //item.Despawn();
        }

        public void Attack()
        {
            //stateMachine.Attack();
        }

        public void UseItem()
        {
            //CurrentItem.Use();
        }

        public void TakeDamage()
        {

        }

        public void SetLocation()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mySprite.Draw(LinkSpriteColor, spriteBatch, destinationRectangle.Location);
        }
        public void Update(GameTime time)
        {
            // Moves onto the next frame in animation
            timer += (float)time.ElapsedGameTime.TotalSeconds;

            if (timer >= ((float)1 / FPS))
            {
                timer = 0f;
                mySprite.Update();
            }
            stateMachine.Update();
        }
    }
}
