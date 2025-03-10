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
        private int RoomScale = 2;
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
            //What do the numbers mean Mason???

            int InteriorWidth = (192 * RoomScale);
            int InteriorHeight = (112 * RoomScale);
            int InteriorXCoord = Game1.SCREENMIDX - InteriorWidth / 2;
            int InteriorYCoord = Game1.SCREENMIDY - InteriorHeight / 2;

            int ExteriorWidth = (256 * RoomScale);
            int ExteriorHeight = (176 * RoomScale);
            int ExteriorXCoord = Game1.SCREENMIDX - ExteriorWidth / 2;
            int ExteriorYCoord = Game1.SCREENMIDY - ExteriorHeight / 2;


            Rectangle destinationRectangleInterior = new Rectangle(InteriorXCoord, InteriorYCoord, InteriorWidth, InteriorHeight);
            Rectangle destinationRectangleExterior = new Rectangle(ExteriorXCoord, ExteriorYCoord, ExteriorWidth, ExteriorHeight);

            Rectangle destinationRectangleLeftDoor = new Rectangle(ExteriorXCoord, ExteriorYCoord + (72 * RoomScale), (32 * RoomScale), (32 * RoomScale));
            Rectangle destinationRectangleRightDoor = new Rectangle(ExteriorXCoord + (224 * RoomScale), ExteriorYCoord + (72 * RoomScale), (32 * RoomScale), (32 * RoomScale));
            Rectangle destinationRectangleDownDoor = new Rectangle(ExteriorXCoord + (112 * RoomScale), ExteriorYCoord, (32 * RoomScale), (32 * RoomScale));
            Rectangle destinationRectangleUpDoor = new Rectangle(ExteriorXCoord + (112 * RoomScale), ExteriorYCoord + (144 * RoomScale), (32 * RoomScale), (32 * RoomScale));

            
            spriteBatch.Draw(spriteSheet, destinationRectangleInterior, RoomInterior, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleExterior, RoomExterior, Color.White);

            spriteBatch.Draw(spriteSheet, destinationRectangleLeftDoor, LeftDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleRightDoor, RightDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleDownDoor, UpDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleUpDoor, DownDoor, Color.White);
        }
    }
}
