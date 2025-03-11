using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;
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
}
