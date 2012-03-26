#region

using System;
using System.Security.Cryptography;
using System.Text;
using EncryptionClassLibrary.Encryption;

#endregion

namespace CommonLib.Util
{
	public static class EncryptionUtil
	{
		public static string EncodePasswordMD5(string originalPassword)
		{
			//Declarations
			Byte[] originalBytes;
			Byte[] encodedBytes;
			MD5 md5;

			//Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
			md5 = new MD5CryptoServiceProvider();
			originalBytes = Encoding.Default.GetBytes(originalPassword);
			encodedBytes = md5.ComputeHash(originalBytes);

			//Convert encoded bytes back to a 'readable' string
			return BitConverter.ToString(encodedBytes);
		}

		public static string Encrypt(string strPlainText, string strKey24)
		{
			var sym = new Symmetric(Symmetric.Provider.TripleDES, true);
			var key = new Data(strKey24);
			Data encryptedData;
			encryptedData = sym.Encrypt(new Data(strPlainText), key);
			return encryptedData.ToBase64();
		}

		public static string Decrypt(String strEncText, string strKey24)
		{
			var sym = new Symmetric(Symmetric.Provider.TripleDES, true);
			var key = new Data(strKey24);
			var encryptedData = new Data();
			encryptedData.Base64 = strEncText;
			var decryptedData = new Data();
			decryptedData = sym.Decrypt(encryptedData, key);
			return decryptedData.ToString();
		}
	}
}