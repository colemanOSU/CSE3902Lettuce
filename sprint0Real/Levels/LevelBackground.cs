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
        private int Multiple = 3;
        private BackgroundCatalogue catalogue = new BackgroundCatalogue();

        private Rectangle destinationRectangleInterior;
        private Rectangle destinationRectangleExterior;
        private Rectangle destinationRectangleLeftDoor;
        private Rectangle destinationRectangleRightDoor;
        private Rectangle destinationRectangleDownDoor;
        private Rectangle destinationRectangleUpDoor;

        public LevelBackground()
        {
            //"X" and "Y" refer to the coordinates of the top left corner of the sprite
            int InteriorWidth = (192 * Game1.RENDERSCALE);
            int InteriorHeight = (112 * Game1.RENDERSCALE);
            int InteriorXCoord = Game1.SCREENMIDX - InteriorWidth / 2;
            int InteriorYCoord = Game1.SCREENMIDY - InteriorHeight / 2 + 30 * Game1.RENDERSCALE;

            int ExteriorWidth = (256 * Game1.RENDERSCALE);
            int ExteriorHeight = (176 * Game1.RENDERSCALE);
            int ExteriorXCoord = Game1.SCREENMIDX - ExteriorWidth / 2;
            int ExteriorYCoord = Game1.SCREENMIDY - ExteriorHeight / 2 + 30 * Game1.RENDERSCALE;


            destinationRectangleInterior = new Rectangle(InteriorXCoord, InteriorYCoord, InteriorWidth, InteriorHeight);
            destinationRectangleExterior = new Rectangle(ExteriorXCoord, ExteriorYCoord, ExteriorWidth, ExteriorHeight);

            destinationRectangleLeftDoor = new Rectangle(ExteriorXCoord, ExteriorYCoord + (72 * Game1.RENDERSCALE), (32 * Game1.RENDERSCALE), (32 * Game1.RENDERSCALE));
            destinationRectangleRightDoor = new Rectangle(ExteriorXCoord + (224 * Game1.RENDERSCALE), ExteriorYCoord + (72 * Game1.RENDERSCALE), (32 * Game1.RENDERSCALE), (32 * Game1.RENDERSCALE));
            destinationRectangleDownDoor = new Rectangle(ExteriorXCoord + (112 * Game1.RENDERSCALE), ExteriorYCoord, (32 * Game1.RENDERSCALE), (32 * Game1.RENDERSCALE));
            destinationRectangleUpDoor = new Rectangle(ExteriorXCoord + (112 * Game1.RENDERSCALE), ExteriorYCoord + (144 * Game1.RENDERSCALE), (32 * Game1.RENDERSCALE), (32 * Game1.RENDERSCALE));
        }

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
            spriteBatch.Draw(spriteSheet, destinationRectangleInterior, RoomInterior, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleExterior, RoomExterior, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleLeftDoor, LeftDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleRightDoor, RightDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleDownDoor, UpDoor, Color.White);
            spriteBatch.Draw(spriteSheet, destinationRectangleUpDoor, DownDoor, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            // Same function but with an offset
            // temporary variables needed, as offset changes the rectangle directly
            Rectangle interior = destinationRectangleInterior;
            Rectangle exterior = destinationRectangleExterior;
            Rectangle left = destinationRectangleLeftDoor;
            Rectangle right = destinationRectangleRightDoor;
            Rectangle down = destinationRectangleDownDoor;
            Rectangle up = destinationRectangleUpDoor;

            interior.Offset(offset);
            exterior.Offset(offset);
            right.Offset(offset);
            left.Offset(offset);
            down.Offset(offset);
            up.Offset(offset);

            spriteBatch.Draw(spriteSheet, interior, RoomInterior, Color.White);
            spriteBatch.Draw(spriteSheet, exterior, RoomExterior, Color.White);

            spriteBatch.Draw(spriteSheet, left, LeftDoor, Color.White);
            spriteBatch.Draw(spriteSheet, right, RightDoor, Color.White);
            spriteBatch.Draw(spriteSheet, down, UpDoor, Color.White);
            spriteBatch.Draw(spriteSheet, up, DownDoor, Color.White);
        }
    }
}
