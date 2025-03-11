using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real;
using sprint0Real.Interfaces;

public static class CounterHelper
{
	//Function takes in a number from 0 to 99 and returns the source
	//rectangles for each digit on the sprite sheet as an array.
	//All inputs greater than 99 are treated as 99.
	//Inputs must be positive.
	public static Rectangle[] Helper(int input)
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
}
