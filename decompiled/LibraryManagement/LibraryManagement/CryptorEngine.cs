using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LibraryManagement;

public class CryptorEngine
{
	private static readonly string PasswordHash = "P@@Sw0rd";

	private static readonly string SaltKey = "S@LT&KEY";

	private static readonly string VIKey = "@1B2c3D4e5F6g7H8";

	public static string Encrypt(string plainText)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(plainText);
		byte[] bytes2 = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(32);
		RijndaelManaged rijndaelManaged = new RijndaelManaged
		{
			Mode = CipherMode.CBC,
			Padding = PaddingMode.Zeros
		};
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, Encoding.ASCII.GetBytes(VIKey));
		byte[] inArray;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.FlushFinalBlock();
				inArray = memoryStream.ToArray();
				cryptoStream.Close();
			}
			memoryStream.Close();
		}
		return Convert.ToBase64String(inArray);
	}

	public static string Decrypt(string encryptedText)
	{
		byte[] array = Convert.FromBase64String(encryptedText);
		byte[] bytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(32);
		RijndaelManaged rijndaelManaged = new RijndaelManaged
		{
			Mode = CipherMode.CBC,
			Padding = PaddingMode.None
		};
		ICryptoTransform transform = rijndaelManaged.CreateDecryptor(bytes, Encoding.ASCII.GetBytes(VIKey));
		MemoryStream memoryStream = new MemoryStream(array);
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
		byte[] array2 = new byte[array.Length];
		int count = cryptoStream.Read(array2, 0, array2.Length);
		memoryStream.Close();
		cryptoStream.Close();
		return Encoding.UTF8.GetString(array2, 0, count).TrimEnd("\0".ToCharArray());
	}
}
