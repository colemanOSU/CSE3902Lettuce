using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff.DeathSprites;
using sprint0Real.Interfaces;

namespace sprint0Real.LinkStuff2
{
    public class LinkSpriteFactory
    {
        private static LinkSpriteFactory instance = new LinkSpriteFactory();
        private Texture2D linkSheet;
        public static LinkSpriteFactory  Instance { get { return instance; } }
        private LinkSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            linkSheet = content.Load<Texture2D>("Bosses");
        }

        public ISprite2 CreateLinkMovingUp()
        {

        }
        public ISprite2 CreateLinkMovingDown()
        {

        }
        public ISprite2 CreateLinkMovingLeft()
        {

        }
        public ISprite2 CreateLinkMovingRight()
        {

        }

        public ISprite2 CreateLinkFacingUp()
        {

        }
        public ISprite2 CreateLinkFacingDown()
        {

        }
        public ISprite2 CreateLinkFacingLeft()
        {

        }
        public ISprite2 CreateLinkFacingRight()
        {

        }

        public ISprite2 CreateLinkUsingItemUp()
        {

        }
        public ISprite2 CreateLinkUsingItemDown()
        {

        }
        public ISprite2 CreateLinkUsingItemLeft()
        {

        }
        public ISprite2 CreateLinkUsingItemRight()
        {

        }
        public ISprite2 CreateLinkPickingUpItem()
        {

        }
    }
}
