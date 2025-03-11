using System;
using System.Security.Cryptography;
using System.Text;

public class AESHelper
{
    public static byte[] GetAESKey(string userInput)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(userInput));
        }
    }

    public static byte[] GenerateRandomKey(int keySize)
    {
        byte[] key = new byte[keySize];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(key);
        }
        return key;
    }

    public static byte[] GenerateRandomIV()
    {
        byte[] iv = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(iv);
        }
        return iv;
    }

    public static byte[] EncryptAES(string plainText, byte[] key, byte[] iv)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }
        }
    }

    public static string DecryptAES(byte[] cipherText, byte[] key, byte[] iv)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
            {
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
