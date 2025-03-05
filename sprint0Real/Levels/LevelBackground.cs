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
        private BackgroundCatalogue catalogue = new BackgroundCatalogue();

        public void SetRoomInterior(String sprite)
        {
            RoomInterior = catalogue.InteriorCatalogue[sprite];
        }
        public void SetRoomExterior(String sprite)
        {
            RoomExterior = catalogue.ExteriorCatalogue[sprite];
        }
        public void SetLeftDoor(String sprite)
        {
            LeftDoor = catalogue.LeftDoorCatalogue[sprite];
        }
        public void SetRightDoor(String sprite)
        {
            RightDoor = catalogue.RightDoorCatalogue[sprite];
        }
        public void SetUpDoor(String sprite)
        {
            UpDoor = catalogue.UpDoorCatalogue[sprite];
        }
        public void SetDownDoor(String sprite)
        {
            DownDoor = catalogue.DownDoorCatalogue[sprite];
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
