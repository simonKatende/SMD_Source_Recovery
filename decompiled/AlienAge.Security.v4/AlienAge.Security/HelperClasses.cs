using System;
using System.Text;

namespace AlienAge.Security;

public class HelperClasses
{
	public static string CharacterCodes(string word, int typeId)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in word)
		{
			switch (c)
			{
			case 'A':
				stringBuilder.Append('1');
				break;
			case 'B':
				stringBuilder.Append('2');
				break;
			case 'C':
				stringBuilder.Append('3');
				break;
			case 'D':
				stringBuilder.Append('4');
				break;
			case 'E':
				stringBuilder.Append('5');
				break;
			case 'F':
				stringBuilder.Append('6');
				break;
			case 'G':
				stringBuilder.Append('7');
				break;
			case 'H':
				stringBuilder.Append('8');
				break;
			case 'I':
				stringBuilder.Append('9');
				break;
			case 'J':
				stringBuilder.Append('0');
				break;
			case 'K':
				stringBuilder.Append("10");
				break;
			case 'L':
				stringBuilder.Append("11");
				break;
			case 'M':
				stringBuilder.Append("12");
				break;
			case 'N':
				stringBuilder.Append("13");
				break;
			case 'O':
				stringBuilder.Append("14");
				break;
			case 'P':
				stringBuilder.Append("15");
				break;
			case 'Q':
				stringBuilder.Append("16");
				break;
			case 'R':
				stringBuilder.Append("17");
				break;
			case 'S':
				stringBuilder.Append("18");
				break;
			case 'T':
				stringBuilder.Append("19");
				break;
			case 'U':
				stringBuilder.Append("20");
				break;
			case 'V':
				stringBuilder.Append("21");
				break;
			case 'W':
				stringBuilder.Append("22");
				break;
			case 'X':
				stringBuilder.Append("23");
				break;
			case 'Y':
				stringBuilder.Append("24");
				break;
			case 'Z':
				stringBuilder.Append("25");
				break;
			case '|':
				stringBuilder.Append("|");
				break;
			default:
				stringBuilder.Append(c * typeId);
				break;
			}
		}
		return stringBuilder.ToString();
	}

	public static string ReverseString(string s)
	{
		char[] array = s.ToCharArray();
		Array.Reverse(array);
		return new string(array);
	}
}
