using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AESHelper
{
    // Генерируем ключ из пароля пользователя
    public static byte[] GenerateKeyFromPassword(string password)
    {
        int keySize = 32; // 256 bit

        byte[] salt = new byte[8];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            byte[] key = pbkdf2.GetBytes(keySize);
            return key;
        }
    }

    // Генерируем рандомный ключ
    public static byte[] GenerateRandomKey()
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.KeySize = 256;
            aesAlg.GenerateKey();
            return aesAlg.Key;
        }
    }

    public static string EncryptAES(string userText, byte[] key)
    {
        // Используем фиксированный IV для отладки
        byte[] iv = new byte[16];
        for (int i = 0; i < iv.Length; i++) iv[i] = (byte)i; // Заполняем IV последовательными байтами для упрощения отладки

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;
            aesAlg.Padding = PaddingMode.PKCS7;  // Убедитесь, что padding соответствует PKCS7

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                msEncrypt.Write(iv, 0, iv.Length);  // Запись IV в начало данных

                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(userText);
                    }
                }

                // Возвращаем зашифрованные данные вместе с IV в base64
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }



    public static string DecryptAES(string encryptedText, byte[] key)
    {
        byte[] cipherTextWithIV = Convert.FromBase64String(encryptedText);

        // Извлекаем IV из первых 16 байт (для AES-256)
        byte[] iv = new byte[16];
        Array.Copy(cipherTextWithIV, 0, iv, 0, iv.Length);

        // Извлекаем зашифрованные данные (после IV)
        byte[] cipherText = new byte[cipherTextWithIV.Length - iv.Length];
        Array.Copy(cipherTextWithIV, iv.Length, cipherText, 0, cipherText.Length);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;
            aesAlg.Padding = PaddingMode.PKCS7;  // Убедитесь, что padding соответствует PKCS7

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }


}
