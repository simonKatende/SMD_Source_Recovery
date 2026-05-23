using System;

namespace I_Xtreme;

internal class NumberToWordsConverter
{
	private string[] _smallNumbers = new string[20]
	{
		"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
		"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
	};

	private string[] _tens = new string[10]
	{
		string.Empty,
		string.Empty,
		"Twenty",
		"Thirty",
		"Forty",
		"Fifty",
		"Sixty",
		"Seventy",
		"Eighty",
		"Ninety"
	};

	private string[] _scaleNumbers = new string[5]
	{
		string.Empty,
		"Thousand",
		"Million",
		"Billion",
		"Trillion"
	};

	public string NumberToWords(long number)
	{
		if (number == 0)
		{
			return _smallNumbers[0];
		}
		long[] array = new long[5];
		long num = Math.Abs(number);
		for (long num2 = 0L; num2 < 5; num2++)
		{
			array[num2] = num % 1000;
			num /= 1000;
		}
		string[] array2 = new string[5];
		for (long num3 = 0L; num3 < 5; num3++)
		{
			array2[num3] = ThreeDigitGroupToWords(array[num3]);
		}
		string text = array2[0];
		bool flag = array[0] > 0 && array[0] < 100;
		for (long num4 = 1L; num4 < 5; num4++)
		{
			if (array[num4] != 0)
			{
				string text2 = $"{array2[num4]} {_scaleNumbers[num4]}";
				if (text.Length != 0)
				{
					text2 += (flag ? " and " : ", ");
				}
				flag = false;
				text = text2 + text;
			}
		}
		if (number < 0)
		{
			text = "Negative " + text;
		}
		return text;
	}

	private string ThreeDigitGroupToWords(long threeDigits)
	{
		string text = string.Empty;
		long num = threeDigits / 100;
		long num2 = threeDigits % 100;
		if (num != 0)
		{
			text = text + _smallNumbers[num] + " Hundred";
			if (num2 != 0)
			{
				text += " and ";
			}
		}
		long num3 = num2 / 10;
		long num4 = num2 % 10;
		if (num3 >= 2)
		{
			text += _tens[num3];
			if (num4 != 0)
			{
				text = text + " " + _smallNumbers[num4];
			}
		}
		else if (num2 != 0)
		{
			text += _smallNumbers[num2];
		}
		return text;
	}
}
