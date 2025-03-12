using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace CYPHER_ULTIMATE3000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Шифрование и дешифрование
        /// Шифрует строку (Строка которую необходимо зашифровать, Ключ шифрования)
        public static string Encrypt(string str, string keyCrypt)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(str), keyCrypt));
        }
        /// Расшифроывает данные из строки (Зашифрованая строка, Ключ шифрования)
        public static string Decrypt(string str, string keyCrypt)
        {
            string Result;
            try
            {
                CryptoStream Cs = InternalDecrypt(Convert.FromBase64String(str), keyCrypt);
                StreamReader Sr = new StreamReader(Cs);

                Result = Sr.ReadToEnd();

                Cs.Close();
                Cs.Dispose();

                Sr.Close();
                Sr.Dispose();
            }
            catch (CryptographicException)
            {
                return null;
            }

            return Result;
        }
        private static byte[] Encrypt(byte[] key, string value)
        {
            SymmetricAlgorithm Sa = Rijndael.Create();
            ICryptoTransform Ct = Sa.CreateEncryptor((new PasswordDeriveBytes(value, null)).GetBytes(16), new byte[16]);

            MemoryStream Ms = new MemoryStream();
            CryptoStream Cs = new CryptoStream(Ms, Ct, CryptoStreamMode.Write);

            Cs.Write(key, 0, key.Length);
            Cs.FlushFinalBlock();

            byte[] Result = Ms.ToArray();

            Ms.Close();
            Ms.Dispose();

            Cs.Close();
            Cs.Dispose();

            Ct.Dispose();

            return Result;
        }
        private static CryptoStream InternalDecrypt(byte[] key, string value)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            ICryptoTransform ct = sa.CreateDecryptor((new PasswordDeriveBytes(value, null)).GetBytes(16), new byte[16]);

            MemoryStream ms = new MemoryStream(key);
            return new CryptoStream(ms, ct, CryptoStreamMode.Read);
        }

        /// Кнопки по шифр. и дешифр.
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
                    string keyCrypt;
                    OutputTextBox.Clear();
                    keyCrypt = KeyTextBox.Text;
                    if (Decrypt(InputTextBox.Text, keyCrypt) == null)
                    {
                        MessageBox.Show("Неправильный ключ.", "Ошибка!");
                    }
                    else OutputTextBox.AppendText(Decrypt(InputTextBox.Text, keyCrypt));
                }
                else MessageBox.Show("Введите ключ.", "Ошибка!");
            }
            else MessageBox.Show("Введите текст.", "Ошибка!");
        }
    }
}