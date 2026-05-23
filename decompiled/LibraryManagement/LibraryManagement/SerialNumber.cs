using System;
using System.Security.Cryptography;
using System.Text;

namespace LibraryManagement;

public class SerialNumber
{
	private static string Encrypt(string inp)
	{
		using MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.ASCII.GetBytes(inp);
		byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.AppendFormat("{0:x2}", array[i]);
		}
		return stringBuilder.ToString();
	}

	private static string ReverseString(string s)
	{
		char[] array = s.ToCharArray();
		Array.Reverse(array);
		return new string(array);
	}

	public static string GetSerialNumber(string requestCode)
	{
		string text = requestCode.Replace("-", "");
		string text2 = $"{ReverseString(text.Substring(28, 4))}{ReverseString(text.Substring(0, 4))}{ReverseString(text.Substring(24, 4))}{ReverseString(text.Substring(16, 4))}{ReverseString(text.Substring(4, 4))}{ReverseString(text.Substring(12, 4))}{ReverseString(text.Substring(20, 4))}{ReverseString(text.Substring(8, 4))}";
		string text3 = text2.Substring(0, 25);
		string text4 = string.Format("{0}", text3.Insert(5, "-").Insert(11, "-").Insert(17, "-")
			.Insert(23, "-"));
		return text4.ToUpper();
	}
}
