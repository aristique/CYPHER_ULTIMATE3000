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

            AESRadioButton.Checked = true;
            PubKeyText.Visible = false;
            PubKeyTextBox.Visible = false;
        }

        // ШИФРОВАНИЕ AES
        //
        //

        public static string AESEncrypt(string plainText, string password)
        {
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

        public static string AESDecrypt(string combinedString, string password)
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

        // ШИФРОВАНИЕ RSA
        //
        //

        public static byte[] RSAEncrypt(string dataToEncrypt, string publicKey)
        {
            //using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXmlString(publicKey);
                byte[] messageBytes = Encoding.UTF8.GetBytes(dataToEncrypt);
                byte[] encryptedBytes = rsa.Encrypt(messageBytes, RSAEncryptionPadding.Pkcs1);
                return encryptedBytes;
            }
        }

        public static string RSADecrypt(string privateKey, byte[] encryptedBytes)
        {
            //using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXmlString(privateKey);
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
                string decryptedMessage = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedMessage;
            }
        }

        //
        //
        // ШИФРОВАНИЕ RSA

        // Кнопка AES шифрования
        private void AESEncyptButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                if (PrivKeyTextBox.Text != "")
                {
                    string keyCrypt = PrivKeyTextBox.Text;
                    OutputTextBox.Clear();
                    OutputTextBox.AppendText(AESEncrypt(InputTextBox.Text, keyCrypt));
                }
                else MessageBox.Show("Введите ключ.", "Ошибка!");
            }
            else MessageBox.Show("Введите текст.", "Ошибка!");
        }
        
        // Кнопка AES дешифрования
        private void AESDecryptButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                if (PrivKeyTextBox.Text != "")
                {
                    string keyCrypt = PrivKeyTextBox.Text;
                    OutputTextBox.Clear();
                    string decryptedText = AESDecrypt(InputTextBox.Text, keyCrypt);
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

        // Кнопка генерации приватного ключа AES
        private void GenerateAESKeyButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder(16);
            PrivKeyTextBox.Clear();
            for (int i = 0; i < 16; i++)
            {
                char randomChar = (char)random.Next(33, 127);
                result.Append(randomChar);
            }
            PrivKeyTextBox.AppendText(result.ToString());
        }

        // Кнопка RSA шифрования
        private void RSAEncyptButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "")
            {
                if (PubKeyTextBox.Text != "")
                {
                    string keyCrypt = PubKeyTextBox.Text;
                    OutputTextBox.Clear();
                    OutputTextBox.AppendText(Convert.ToBase64String(RSAEncrypt(InputTextBox.Text, keyCrypt)));
                }
                else MessageBox.Show("Введите ключ.", "Ошибка!");
            }
            else MessageBox.Show("Введите текст.", "Ошибка!");
        }

        // Кнопка RSA дешифрования
        private void RSADecryptButton_Click(object sender, EventArgs e)
        {
            /*if (InputTextBox.Text != "")
            {
                if (PrivKeyTextBox.Text != "")
                {
                    string keyCrypt = PrivKeyTextBox.Text;
                    OutputTextBox.Clear();
                    string decryptedText = RSADecrypt(InputTextBox.Text, Convert.FromBase64String(keyCrypt));
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
            else MessageBox.Show("Введите текст.", "Ошибка!");*/
        }

        // Кнопка генерации приватного ключа RSA
        private void GenerateRSAKeyButton_Click(Object sender, EventArgs e)
        {
            using (RSA rsa = RSA.Create())
            {
                 PubKeyTextBox.Text = rsa.ToXmlString(false);
                 PrivKeyTextBox.Text = rsa.ToXmlString(true);
            }
        }

        private void AESRadioButton_CheckedChanged(Object sender, EventArgs e)
        {
            if (AESRadioButton.Checked)
            {
                PubKeyText.Visible = false;
                PubKeyTextBox.Visible = false;

                GeneratePrivKeyButton.Click -= GenerateAESKeyButton_Click;
                GeneratePrivKeyButton.Click -= GenerateRSAKeyButton_Click;
                GeneratePrivKeyButton.Click += GenerateAESKeyButton_Click;

                EncryptButton.Click -= AESEncyptButton_Click;
                EncryptButton.Click -= RSAEncyptButton_Click;
                EncryptButton.Click += AESEncyptButton_Click;

                DecryptButton.Click -= AESDecryptButton_Click;
                DecryptButton.Click -= RSADecryptButton_Click;
                DecryptButton.Click += AESDecryptButton_Click;
            }
        }

        private void RSARadioButton_CheckedChanged(Object sender, EventArgs e)
        {
            if (RSARadioButton.Checked)
            {
                PubKeyText.Visible = true;
                PubKeyTextBox.Visible = true;

                GeneratePrivKeyButton.Click -= GenerateAESKeyButton_Click;
                GeneratePrivKeyButton.Click -= GenerateRSAKeyButton_Click;
                GeneratePrivKeyButton.Click += GenerateRSAKeyButton_Click;

                EncryptButton.Click -= AESEncyptButton_Click;
                EncryptButton.Click -= RSAEncyptButton_Click;
                EncryptButton.Click += RSAEncyptButton_Click;

                DecryptButton.Click -= AESDecryptButton_Click;
                DecryptButton.Click -= RSADecryptButton_Click;
                DecryptButton.Click += RSADecryptButton_Click;
            }
        }
    }
}
