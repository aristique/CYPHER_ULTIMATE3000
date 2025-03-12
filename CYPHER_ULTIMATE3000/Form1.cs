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

        public static string Encrypt(string plainText, string keyString)
        {
            byte[] cipherData;
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(keyString);
            aes.GenerateIV();
            aes.Mode = CipherMode.CBC;
            ICryptoTransform cipher = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, cipher, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }

                cipherData = ms.ToArray();
            }

            byte[] combinedData = new byte[aes.IV.Length + cipherData.Length];
            Array.Copy(aes.IV, 0, combinedData, 0, aes.IV.Length);
            Array.Copy(cipherData, 0, combinedData, aes.IV.Length, cipherData.Length);
            return Convert.ToBase64String(combinedData);
        }

        public static string Decrypt(string combinedString, string keyString)
        {
            string plainText;
            byte[] combinedData = Convert.FromBase64String(combinedString);
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] cipherText = new byte[combinedData.Length - iv.Length];
            Array.Copy(combinedData, iv, iv.Length);
            Array.Copy(combinedData, iv.Length, cipherText, 0, cipherText.Length);
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform decipher = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, decipher, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        plainText = sr.ReadToEnd();
                    }
                }

                return plainText;
            }
        }

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
