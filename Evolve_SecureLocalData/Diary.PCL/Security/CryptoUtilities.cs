using System;
using PCLCrypto;
using System.Text;

namespace Diary.Shared
{
	public static class CryptoUtilities
	{
		const int IVSize = 16;

		public static byte[] GetAES256KeyMaterial ()
		{
			return WinRTCrypto.CryptographicBuffer.GenerateRandom(32); 
		}

		public static byte[] Get256BitSalt ()
		{
			return WinRTCrypto.CryptographicBuffer.GenerateRandom(32); 
		}

		public static byte[] Encrypt (byte[] plainText, byte[] keyMaterial)
		{
			//TODO
			return plainText;
		}

		public static byte[] Decrypt (byte[] cipherText, byte[] keyMaterial)
		{
			//TODO
			return cipherText;
		}

		public static byte[] GetHash (byte[] data, byte[] salt)
		{
			//TODO
			return data;
		}

		public static string ByteArrayToString (byte[] data)
		{
			return Encoding.UTF8.GetString (data, 0, data.Length);
		}

		public static byte[] StringToByteArray (string text)
		{
			return Encoding.UTF8.GetBytes (text);
		}
	}
}