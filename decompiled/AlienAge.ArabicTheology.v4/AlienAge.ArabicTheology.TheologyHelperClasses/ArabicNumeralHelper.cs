using System;
using System.Text.RegularExpressions;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

public class ArabicNumeralHelper
{
	public string EnglishToArabic(string EnglishInput)
	{
		return EnglishInput.Replace('0', '٠').Replace('1', '١').Replace('2', '٢')
			.Replace('3', '٣')
			.Replace('4', '٤')
			.Replace('5', '٥')
			.Replace('6', '٦')
			.Replace('7', '٧')
			.Replace('8', '٨')
			.Replace('9', '٩');
	}

	public int ArabicToEnglish(string ArabicInput)
	{
		string text = "";
		for (int i = 0; i < ArabicInput.Length; i++)
		{
			text = ((!char.IsDigit(ArabicInput[i])) ? (text + ArabicInput[i]) : (text + char.GetNumericValue(ArabicInput, i)));
		}
		return Convert.ToInt32(text);
	}

	public string ArabicToEnglishCheck(string ArabicInput)
	{
		string text = "";
		for (int i = 0; i < ArabicInput.Length; i++)
		{
			text = ((!char.IsDigit(ArabicInput[i])) ? (text + ArabicInput[i]) : (text + char.GetNumericValue(ArabicInput, i)));
		}
		return text;
	}

	public bool IsRtl(string input)
	{
		return Regex.IsMatch(input, "\\p{IsArabic}");
	}
}
