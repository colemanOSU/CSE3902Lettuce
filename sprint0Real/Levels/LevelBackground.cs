using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.EnemyStuff;
using sprint0Real.Interfaces;

namespace sprint0Real.Levels
{
    public class LevelBackground
    {
        private Texture2D spriteSheet = EnemySpriteFactory.Instance.ReturnDungeonTileSheet();
        private Rectangle RoomInterior;
        private Rectangle RoomExterior;
        private Rectangle LeftDoor;
        private Rectangle RightDoor;
        private Rectangle UpDoor;
        private Rectangle DownDoor;

        public void SetRoomInterior(Rectangle rectange)
        {
            RoomInterior = rectange;
        }
        public void SetRoomExterior(Rectangle rectange)
        {
            RoomInterior = rectange;
        }
        public void SetDoorLeft(Rectangle rectange)
        {
            RoomInterior = rectange;
        }
        public void SetDoorRight(Rectangle rectange)
        {
            RoomInterior = rectange;
        }
        public void SetDoorUp(Rectangle rectange)
        {
            RoomInterior = rectange;
        }
        public void SetDoorDown(Rectangle rectange)
        {
            RoomInterior = rectange;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangleInterior = new Rectangle(123, 123,3, 51);
            Rectangle destinationRectangleExterior = new Rectangle(123, 123, 3, 51);
            Rectangle destinationRectangleLeftDoor = new Rectangle(123, 123, 3, 51);
            Rectangle destinationRectangleRightDoor = new Rectangle(123, 123, 3, 51);
            Rectangle destinationRectangleDownDoor = new Rectangle(123, 123, 3, 51);
            Rectangle destinationRectangleUpDoor = new Rectangle(123, 123, 3, 51);


            spriteBatch.Draw(spriteSheet, destinationRectangleInterior, RoomInterior, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleExterior, RoomExterior, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleLeftDoor, LeftDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleRightDoor, RightDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleDownDoor, UpDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleUpDoor, DownDoor, Color.White);
        }
    }
}
