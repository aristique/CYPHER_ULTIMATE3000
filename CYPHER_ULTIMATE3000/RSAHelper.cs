using System;
using System.Security.Cryptography;
using System.Text;

public static class RSAHelper
{
    // Метод для генерации ключей RSA (открытого и закрытого)
    public static (string publicKey, string privateKey) GenerateKeys()
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.KeySize = 2048;  // Устанавливаем размер ключа

            // Получаем открытый и закрытый ключи в формате XML
            string publicKey = rsa.ToXmlString(false);  // Открытый ключ
            string privateKey = rsa.ToXmlString(true);  // Закрытый ключ

            return (publicKey, privateKey);
        }
    }

    // Шифрование с использованием публичного ключа
    public static string EncryptRSA(string plainText, string publicKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.FromXmlString(publicKey);
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedData);
        }
    }

    // Дешифрование с использованием приватного ключа
    public static string DecryptRSA(string cipherText, string privateKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.FromXmlString(privateKey);
            byte[] data = Convert.FromBase64String(cipherText);
            byte[] decryptedData = rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
