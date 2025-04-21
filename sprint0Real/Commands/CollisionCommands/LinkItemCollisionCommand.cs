using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Collisions;
using sprint0Real.GameState.NameRegistrationandAchievements;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.LinkStuff;
using sprint0Real.TreasureItemStuff.TreasureItemSprites;

namespace sprint0Real.Commands.CollisionCommands2
{
    internal class LinkItemCollisionCommand : ICollisionCommand
    {
        private Inventory inv;
        private Link link;
        private Game1 myGame;
        public LinkItemCollisionCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute(IObject LinkObj, IObject Item, CollisionDirections direction)
        {
            //Maybe Dangerous
            Link link = (Link)LinkObj;

            //TODO make link pick up item/update inventory etc.
            
            inv = link.GetInventory();

            switch (Item)
            {
                case Heart:
                    link.OffsetCurrentHealth(1);
                    break;
                case FiveRupies:
                    inv.PickUpRupee(5);
                    break;
                case Rupee:
                    inv.PickUpRupee(1);
                    break;
                case Fairy:
                    link.OffsetCurrentHealth(link.GetMaxHealth());
                    AchievementManager.Unlock("Fairy Catcher!");
                    break;
                case ContainerHeart:
                    link.SetMaxHealth(link.GetMaxHealth() + 2);
                    link.OffsetCurrentHealth(2);
                    break;
                case Key:
                    inv.KeyGet();
                    break;
                case MagicalSword:
                    inv.CurrentSword = Inventory.Swords.Magic_Sword;
                    break;
                case WhiteSword:
                    inv.CurrentSword = Inventory.Swords.White_Sword;
                    break;
                case Sword:
                    inv.CurrentSword = Inventory.Swords.Wood_Sword;
                    break;
                case Compass:
                    inv.HasCompass = true;
                    break;
                case Map:
                    inv.HasMap = true;
                    break;
                case Bomb:
                    inv.PickUpBomb();
                    break;
                case Boomerang:
                    inv.ObtainItem(Inventory.Items.Boomerang);
                    if (inv.CurrentItem == Inventory.Items.NONE) inv.CurrentItem = Inventory.Items.Boomerang;
                    break;
                case MagicalBoomerang:
                    inv.ObtainItem(Inventory.Items.M_Boomerang);
                    break;
                case Arrow:
                    inv.ObtainItem(Inventory.Items.Arrow);
                    break;
                case BlueCandle:
                    inv.ObtainItem(Inventory.Items.Blue_Candle);
                    break;
                case RedCandle:
                    inv.ObtainItem(Inventory.Items.Red_Candle);
                    break;
                case Recorder:
                    inv.ObtainItem(Inventory.Items.Flute);
                    break;
                case Food:
                    inv.ObtainItem(Inventory.Items.Meat);
                    break;
                case Letter:
                    inv.ObtainItem(Inventory.Items.Note);
                    break;
                case LifePotion:
                    inv.ObtainItem(Inventory.Items.Blue_Potion);
                    break;
                case SecondPotion:
                    inv.ObtainItem(Inventory.Items.Red_Potion);
                    break;
                case WolfBubble:
                    inv.ObtainItem(Inventory.Items.WolfBubble);
                    break;
                case Triforce:
                    myGame.currentGameState = GameState.GameStates.Winning;
                    break;

                //TODO other cases
                default:
                    break;
            }
            if (Item is ITreasureItems item)
            {
                item.CollectItem();
                CurrentMap.Instance.DeStage(item);
            }
        }
    }
}
