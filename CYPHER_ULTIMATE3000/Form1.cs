using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYPHER_ULTIMATE3000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            string plainText = InputTextBox.Text;  // Вводимый текст
            byte[] key;

            // Проверяем, ввёл ли пользователь ключ
            if (string.IsNullOrEmpty(KeyTextBox.Text))
            {
                key = AESHelper.GenerateRandomKey(32); // Генерация 256-битного ключа
                KeyTextBox.Text = Convert.ToBase64String(key); // Вывод ключа в поле
            }
            else
            {
                key = AESHelper.GetAESKey(KeyTextBox.Text); // Преобразование введённого ключа
            }

            byte[] iv = AESHelper.GenerateRandomKey(16); // IV всегда 16 байт
            byte[] encryptedData = AESHelper.EncryptAES(plainText, key, iv);

            byte[] result = iv.Concat(encryptedData).ToArray();
            OutputTextBox.Text = Convert.ToBase64String(result);
        }


        private void DecryptButton_Click(object sender, EventArgs e)
        {
            byte[] encryptedData = Convert.FromBase64String(OutputTextBox.Text);
            byte[] iv = encryptedData.Take(16).ToArray(); // Извлекаем IV
            byte[] cipherText = encryptedData.Skip(16).ToArray(); // Извлекаем зашифрованные данные

            byte[] key;
            if (string.IsNullOrEmpty(KeyTextBox.Text))
            {
                MessageBox.Show("Введите ключ для расшифровки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                key = AESHelper.GetAESKey(KeyTextBox.Text);
            }

            string decryptedText = AESHelper.DecryptAES(cipherText, key, iv);
            OutputTextBox.Text = decryptedText;
        }

        private void GenerateKeyButton_Click(object sender, EventArgs e)
        {
            byte[] key = AESHelper.GenerateRandomKey(32); // Генерация 256-битного ключа
            KeyTextBox.Text = Convert.ToBase64String(key); // Выводим ключ в поле ввода
        }

    }
}
