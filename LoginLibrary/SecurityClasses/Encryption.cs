using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LoginLibrary.SecurityClasses
{
	namespace SecurityClasses
	{
		/// <summary>
		/// Simple encryption decryption of strings
		/// </summary>
		public class Encryption
		{
			public byte[] Encrypt(string plainText, string secretKey)
			{
				byte[] encryptedPassword = null;
				using (var outputStream = new MemoryStream())
				{
					RijndaelManaged algorithm = getAlgorithm(secretKey);
					using (var cryptoStream = new CryptoStream(outputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
					{
						byte[] inputBuffer = Encoding.Unicode.GetBytes(plainText);
						cryptoStream.Write(inputBuffer, 0, inputBuffer.Length);
						cryptoStream.FlushFinalBlock();
						encryptedPassword = outputStream.ToArray();
					}
				}
				return encryptedPassword;
			}

			public string Decrypt(byte[] encryptedBytes, string secretKey)
			{
				string plainText = null;
				using (var inputStream = new MemoryStream(encryptedBytes))
				{
					RijndaelManaged algorithm = getAlgorithm(secretKey);
					using (var cryptoStream = new CryptoStream(inputStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
					{
						byte[] outputBuffer = new byte[((int)(inputStream.Length - 1)) + 1];
						int readBytes = cryptoStream.Read(outputBuffer, 0, (int)inputStream.Length);
						plainText = Encoding.Unicode.GetString(outputBuffer, 0, readBytes);
					}
				}
				return plainText;
			}
			private RijndaelManaged getAlgorithm(string secretKey)
			{
				const string salt = "akl~jdf";
				const int keySize = 256;

				var keyBuilder = new Rfc2898DeriveBytes(secretKey, Encoding.Unicode.GetBytes(salt));
			    var algorithm = new RijndaelManaged {KeySize = keySize};
			    algorithm.IV = keyBuilder.GetBytes(Convert.ToInt32(algorithm.BlockSize / 8.0));
				algorithm.Key = keyBuilder.GetBytes(Convert.ToInt32(algorithm.KeySize / 8.0));
				algorithm.Padding = PaddingMode.PKCS7;
				return algorithm;
			}
		}
	}
}