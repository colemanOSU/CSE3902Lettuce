using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.EnemyStuff
{
    public class Dragon
    {
        private ISprite mySprite;
        private DragonStateMachine stateMachine;
        private Vector2 location;

        public Dragon()
        {
            stateMachine = new DragonStateMachine();
            mySprite = EnemySpriteFactory.Instance.CreateDragonEnemySprite();
        }

        public void Update()
        {
            mySprite.Update();
        }
    }
}
