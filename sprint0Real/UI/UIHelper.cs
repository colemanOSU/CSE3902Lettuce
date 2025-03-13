using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
using sprint0Real.LinkStuff;
using System;
using System.Diagnostics;

public static class UIHelper
{
	//Function takes in a number from 0 to 99 and returns the source
	//rectangles for each digit on the sprite sheet as an array.
	//All inputs greater than 99 are treated as 99.
	//Inputs must be positive.
	public static Rectangle[] CounterHelper(int input)
	{
		
		if (input > 99) input = 99;

		//Get each digit
		int OneDigit = input % 10;
		int TenDigit = input / 10;

		//Set each digit's source to the "0" sprite by default
		Rectangle OneDigitRec = new Rectangle(528, 117, 8, 8);
		Rectangle TenDigitRec = new Rectangle(528, 117, 8, 8);

		OneDigitRec.Offset(9 * OneDigit, 0);
        TenDigitRec.Offset(9 * TenDigit, 0);

        Rectangle[] AnswerArray = {OneDigitRec, TenDigitRec};
		return AnswerArray;
	}

	//Takes the current health and maximum health of Link as inputs
	//And returns the source rectangles for the healthbar sprite as
	//an array of length 8.

	//Health is measured in half hearts (so 2 hearts = 4 health)
	//Assumes maximum possible maximum health of 8 hearts.

	//Max Health MUST ALWAYS BE an even Number!
	public static Rectangle[] HealthbarHelper(int MaxHealth, int CurrentHealth)
	{
		if (MaxHealth % 2 != 0)
		{
			throw new ArgumentException("Max Health must be an even number!");
        }

		Rectangle[] ReturnArray = new Rectangle[MaxHealth / 2];
		

		

		for (int i = 0; i < MaxHealth / 2; i++)
		{
			if (CurrentHealth >= 2)
			{
				ReturnArray[i] = new Rectangle(645, 117, 8, 8);
			}
			else if (CurrentHealth == 1) { 
				ReturnArray[i] = new Rectangle(636, 117, 8, 8); 
			}
			else ReturnArray[i] = new Rectangle(627, 117, 8, 8);

			CurrentHealth--;
            CurrentHealth--;


        }

		return ReturnArray;
	}

    //Oh how I wish there was an easier way to do this.
    //I would just edit the spritesheet to make the sprites evenly spaced
    //but other classes have already hard-coded those numbers
	//A thousand years of punishment for me (╥﹏╥)
    public static Rectangle ItemSpriteHelper(Inventory.Items item)
	{
		int X = 490;

		switch (item)
		{
			case Inventory.Items.Boomerang:
				X = 584;
				break;
            case Inventory.Items.M_Boomerang:
                X = 593;
                break;
            case Inventory.Items.Arrow:
                X = 615;
                break;
            case Inventory.Items.Silver_Arrow:
                X = 624;
                break;
            case Inventory.Items.Blue_Candle:
                X = 644;
                break;
            case Inventory.Items.Red_Candle:
                X = 653;
                break;
            case Inventory.Items.Flute:
                X = 664;
                break;
            case Inventory.Items.Meat:
                X = 675;
                break;
            case Inventory.Items.Note:
                X = 686;
                break;
            case Inventory.Items.Blue_Potion:
                X = 695;
                break;
            case Inventory.Items.Red_Potion:
                X = 704;
                break;
            case Inventory.Items.Staff:
                X = 715;
                break;
        }

		return new Rectangle(X, 137, 8, 16);
	}
}
