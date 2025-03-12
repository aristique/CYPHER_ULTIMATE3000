using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CYPHER_ULTIMATE3000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // ШИФРОВАНИЕ AES
        //
        //

        public static string Encrypt(string plainText, string password)
        {
            byte[] cipherData;
            using (Aes aes = Aes.Create())
            {
                byte[] salt = new byte[16];
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                var pbkdf2 = new Rfc2898DeriveBytes(
                    password: password,
                    salt: salt,
                    iterations: 10000,
                    hashAlgorithm: HashAlgorithmName.SHA256
                );

                aes.Key = pbkdf2.GetBytes(32);
                aes.GenerateIV();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(salt, 0, salt.Length);
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string combinedString, string password)
        {
            try
            {
                byte[] combinedData = Convert.FromBase64String(combinedString);
                if (combinedData.Length < 32)
                    return "Ошибка: неверный формат данных";

                using (Aes aes = Aes.Create())
                {
                    byte[] salt = new byte[16];
                    byte[] iv = new byte[16];
                    Array.Copy(combinedData, 0, salt, 0, 16);
                    Array.Copy(combinedData, 16, iv, 0, 16);

                    var pbkdf2 = new Rfc2898DeriveBytes(
                        password: password,
                        salt: salt,
                        iterations: 10000,
                        hashAlgorithm: HashAlgorithmName.SHA256
                    );

                    aes.Key = pbkdf2.GetBytes(32);
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (MemoryStream ms = new MemoryStream(combinedData, 32, combinedData.Length - 32))
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        //
        //
        // ШИФРОВАНИЕ AES

        private void EncyptButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                if (KeyTextBox.Text != "")
                {
                    string keyCrypt = KeyTextBox.Text;
                    OutputTextBox.Clear();
                    OutputTextBox.AppendText(Encrypt(InputTextBox.Text, keyCrypt));
                }
                else MessageBox.Show("Введите ключ.", "Ошибка!");
            }
            else MessageBox.Show("Введите текст.", "Ошибка!");
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                if (KeyTextBox.Text != "")
                {
                    string keyCrypt = KeyTextBox.Text;
                    OutputTextBox.Clear();
                    string decryptedText = Decrypt(InputTextBox.Text, keyCrypt);
                    if (decryptedText.StartsWith("Ошибка"))
                    {
                        MessageBox.Show(decryptedText, "Ошибка!");
                    }
                    else
                    {
                        OutputTextBox.AppendText(decryptedText);
                    }
                }
                else MessageBox.Show("Введите ключ.", "Ошибка!");
            }
            else MessageBox.Show("Введите текст.", "Ошибка!");
        }

        private void GenerateKeyButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder(16);
            KeyTextBox.Clear();
            for (int i = 0; i < 16; i++)
            {
                char randomChar = (char)random.Next(33, 127);
                result.Append(randomChar);
            }
            KeyTextBox.AppendText(result.ToString());
        }
    }
}
