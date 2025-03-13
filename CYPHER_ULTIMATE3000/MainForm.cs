using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CYPHER_ULTIMATE3000
{
    public partial class MainForm : Form
    {
        // Инициализация формы
        public MainForm()
        {
            InitializeComponent();

            AESRadioButton.Checked = true;
            SetInterfaceVal (false);
        }

        // Задание параметров
        private void SetInterfaceVal(bool val)
        { 
            PubKeyText.Visible = 
            PubKeyTextBox.Visible = 
            SignButton.Visible = 
            VerifyButton.Visible = 
            SignatureText.Visible = 
            SignatureTextBox.Visible = val;
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
                MessageBox.Show($"Ошибка: {ex.Message}");
                return null;
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
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXmlString(publicKey);
                byte[] messageBytes = Zip(dataToEncrypt);
                byte[] encryptedBytes = rsa.Encrypt(messageBytes, RSAEncryptionPadding.Pkcs1);
                return encryptedBytes;
            }
        }

        private string RSADecrypt(string encryptedText, string privateKeyXml)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXmlString(privateKeyXml);

                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);

                return Unzip(decryptedBytes);
            }
        }


        //
        //
        // ШИФРОВАНИЕ RSA

        // ПОДПИСЬ И ПРОВЕРКА
        //
        //

        public static string Sign(string privateKey, string dataToSign)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXmlString(privateKey);
                byte[] messageBytes = Encoding.UTF8.GetBytes(dataToSign);
                byte[] signatureBytes = rsa.SignData(messageBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                return Convert.ToBase64String(signatureBytes);
            }
        }


        public static bool Verify(string publicKey, string dataToValidate, byte[] signature)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.FromXmlString(publicKey);
                byte[] messageBytes = Encoding.UTF8.GetBytes(dataToValidate);
                return rsa.VerifyData(messageBytes, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }

        //
        //
        // ПОДПИСЬ И ПРОВЕРКА

        public static byte[] Zip(string str)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    CopyTo(msi, gs);
                }
                return mso.ToArray();
            }
        }
        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    CopyTo(gs, mso);
                }
                return System.Text.Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

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
                    if (decryptedText == null)
                    {
                        MessageBox.Show("Неправильный ключ/дешифруемый текст!", "Ошибка!");
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
            for (int i = 0; i < 256; i++)
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
                    try
                    {
                        string keyCrypt = PubKeyTextBox.Text;
                        OutputTextBox.Clear();
                        OutputTextBox.AppendText(Convert.ToBase64String(RSAEncrypt(InputTextBox.Text, keyCrypt)));
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"Ошибка: {ex.Message}"); }
                }
                else MessageBox.Show("Введите ключ.", "Ошибка!");
            }
            else MessageBox.Show("Введите текст.", "Ошибка!");
        }

        // Кнопка RSA дешифрования
        private void RSADecryptButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputTextBox.Text))
            {
                MessageBox.Show("Введите текст.", "Ошибка!");
                return;
            }

            if (string.IsNullOrEmpty(PrivKeyTextBox.Text))
            {
                MessageBox.Show("Введите ключ.", "Ошибка!");
                return;
            }

            string privateKeyXml = PrivKeyTextBox.Text;

            try
            {
                OutputTextBox.Clear();
                OutputTextBox.Text = RSADecrypt(InputTextBox.Text, privateKeyXml);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Детали");
            }
        }


        // Проверка строки на соответствие Base-64
        private static bool IsBase64String(string s)
        {
            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Кнопка генерации приватного ключа RSA
        private void GenerateRSAKeyButton_Click(Object sender, EventArgs e)
        {
            using (RSA rsa = RSA.Create())
            {
                string privateKeyXml = rsa.ToXmlString(true);
                PrivKeyTextBox.Text = privateKeyXml;

                PubKeyTextBox.Text = rsa.ToXmlString(false);
            }
        }

        // Кнопка подписи
        private void SignButton_Click(Object sender, EventArgs e)
        {
            string privateKey = PrivKeyTextBox.Text;
            string inputText = InputTextBox.Text;

            if (string.IsNullOrWhiteSpace(privateKey) || string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Введите приватный ключ и текст для подписи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string signedMessage = Sign(privateKey, inputText);

            string output = $"Зашифрованное сообщение:\r\n{inputText}\r\n\r\nПодписанное сообщение:\r\n{signedMessage}";

            OutputTextBox.Text = output;
        }

        // Кнопка проверки
        private void VerifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verify(PubKeyTextBox.Text, InputTextBox.Text, Convert.FromBase64String(SignatureTextBox.Text)))
                {
                    MessageBox.Show("Текст не был изменён");
                }
                else
                {
                    MessageBox.Show("Текст был изменён");
                }
            }
            catch
            {
                MessageBox.Show($"Введён неправильный подписанный текст.");
            }
        }

        // Обработка круглой кнопки симметричного алгоритма
        private void AESRadioButton_CheckedChanged(Object sender, EventArgs e)
        {
            if (AESRadioButton.Checked)
            {
                SetInterfaceVal(false);

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

        // Обработка круглой кнопки асимметричного алгоритма
        private void RSARadioButton_CheckedChanged(Object sender, EventArgs e)
        {
            if (RSARadioButton.Checked)
            {
                SetInterfaceVal(true);

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
