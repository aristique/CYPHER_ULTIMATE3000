using System.Windows.Forms;

namespace CYPHER_ULTIMATE3000
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OutputText = new System.Windows.Forms.Label();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InputText = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PrivKeyTextBox = new System.Windows.Forms.TextBox();
            this.PrivKeyText = new System.Windows.Forms.Label();
            this.GeneratePrivKeyButton = new System.Windows.Forms.Button();
            this.PubKeyText = new System.Windows.Forms.Label();
            this.PubKeyTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChooseAlgText = new System.Windows.Forms.Label();
            this.AESRadioButton = new System.Windows.Forms.RadioButton();
            this.RSARadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.SignButton = new System.Windows.Forms.Button();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.SignatureTextBox = new System.Windows.Forms.TextBox();
            this.SignatureText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.OutputText, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.OutputTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.InputTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.InputText, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1342, 471);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // OutputText
            // 
            this.OutputText.AutoSize = true;
            this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputText.Location = new System.Drawing.Point(686, 0);
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(653, 20);
            this.OutputText.TabIndex = 5;
            this.OutputText.Text = "Результат Шифрования/Дешифрования";
            this.OutputText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Location = new System.Drawing.Point(686, 23);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(653, 445);
            this.OutputTextBox.TabIndex = 2;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTextBox.Location = new System.Drawing.Point(3, 23);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(652, 445);
            this.InputTextBox.TabIndex = 0;
            // 
            // InputText
            // 
            this.InputText.AutoSize = true;
            this.InputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputText.Location = new System.Drawing.Point(3, 0);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(652, 20);
            this.InputText.TabIndex = 3;
            this.InputText.Text = "Шифруемый/Дешифруемый текст";
            this.InputText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.61832F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.45802F));
            this.tableLayoutPanel2.Controls.Add(this.PrivKeyTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.PrivKeyText, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.GeneratePrivKeyButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.PubKeyText, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.PubKeyTextBox, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 490);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(655, 181);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // PrivKeyTextBox
            // 
            this.PrivKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrivKeyTextBox.Location = new System.Drawing.Point(3, 21);
            this.PrivKeyTextBox.Multiline = true;
            this.PrivKeyTextBox.Name = "PrivKeyTextBox";
            this.PrivKeyTextBox.Size = new System.Drawing.Size(321, 66);
            this.PrivKeyTextBox.TabIndex = 0;
            // 
            // PrivKeyText
            // 
            this.PrivKeyText.AutoSize = true;
            this.PrivKeyText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrivKeyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrivKeyText.Location = new System.Drawing.Point(3, 0);
            this.PrivKeyText.Name = "PrivKeyText";
            this.PrivKeyText.Size = new System.Drawing.Size(321, 18);
            this.PrivKeyText.TabIndex = 1;
            this.PrivKeyText.Text = "Приватный ключ:";
            this.PrivKeyText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GeneratePrivKeyButton
            // 
            this.GeneratePrivKeyButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GeneratePrivKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeneratePrivKeyButton.Location = new System.Drawing.Point(330, 21);
            this.GeneratePrivKeyButton.Name = "GeneratePrivKeyButton";
            this.GeneratePrivKeyButton.Size = new System.Drawing.Size(187, 66);
            this.GeneratePrivKeyButton.TabIndex = 2;
            this.GeneratePrivKeyButton.Text = "Сгенерировать ключ";
            this.GeneratePrivKeyButton.UseVisualStyleBackColor = true;
            this.GeneratePrivKeyButton.Click += new System.EventHandler(this.GenerateAESKeyButton_Click);
            // 
            // PubKeyText
            // 
            this.PubKeyText.AutoSize = true;
            this.PubKeyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PubKeyText.Location = new System.Drawing.Point(3, 90);
            this.PubKeyText.Name = "PubKeyText";
            this.PubKeyText.Size = new System.Drawing.Size(136, 16);
            this.PubKeyText.TabIndex = 3;
            this.PubKeyText.Text = "Публичный ключ:";
            this.PubKeyText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PubKeyTextBox
            // 
            this.PubKeyTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PubKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PubKeyTextBox.Location = new System.Drawing.Point(3, 111);
            this.PubKeyTextBox.Multiline = true;
            this.PubKeyTextBox.Name = "PubKeyTextBox";
            this.PubKeyTextBox.Size = new System.Drawing.Size(321, 67);
            this.PubKeyTextBox.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.EncryptButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DecryptButton, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(698, 490);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(653, 68);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // EncryptButton
            // 
            this.EncryptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EncryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncryptButton.Location = new System.Drawing.Point(3, 3);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(310, 62);
            this.EncryptButton.TabIndex = 0;
            this.EncryptButton.Text = "Шифровать текст";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.AESEncyptButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DecryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecryptButton.Location = new System.Drawing.Point(339, 3);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(311, 62);
            this.DecryptButton.TabIndex = 1;
            this.DecryptButton.Text = "Дешифровать текст";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.AESDecryptButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChooseAlgText);
            this.panel1.Controls.Add(this.AESRadioButton);
            this.panel1.Controls.Add(this.RSARadioButton);
            this.panel1.Location = new System.Drawing.Point(12, 677);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 79);
            this.panel1.TabIndex = 3;
            // 
            // ChooseAlgText
            // 
            this.ChooseAlgText.AutoSize = true;
            this.ChooseAlgText.Location = new System.Drawing.Point(3, 10);
            this.ChooseAlgText.Name = "ChooseAlgText";
            this.ChooseAlgText.Size = new System.Drawing.Size(97, 13);
            this.ChooseAlgText.TabIndex = 2;
            this.ChooseAlgText.Text = "Выбор алгоритма";
            // 
            // AESRadioButton
            // 
            this.AESRadioButton.AutoSize = true;
            this.AESRadioButton.Location = new System.Drawing.Point(3, 36);
            this.AESRadioButton.Name = "AESRadioButton";
            this.AESRadioButton.Size = new System.Drawing.Size(183, 17);
            this.AESRadioButton.TabIndex = 1;
            this.AESRadioButton.TabStop = true;
            this.AESRadioButton.Text = "Симметричный алгоритм (AES)";
            this.AESRadioButton.UseVisualStyleBackColor = true;
            this.AESRadioButton.CheckedChanged += new System.EventHandler(this.AESRadioButton_CheckedChanged);
            // 
            // RSARadioButton
            // 
            this.RSARadioButton.AutoSize = true;
            this.RSARadioButton.Location = new System.Drawing.Point(3, 59);
            this.RSARadioButton.Name = "RSARadioButton";
            this.RSARadioButton.Size = new System.Drawing.Size(190, 17);
            this.RSARadioButton.TabIndex = 0;
            this.RSARadioButton.TabStop = true;
            this.RSARadioButton.Text = "Асимметричный алгоритм (RSA)";
            this.RSARadioButton.UseVisualStyleBackColor = true;
            this.RSARadioButton.CheckedChanged += new System.EventHandler(this.RSARadioButton_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.SignButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.VerifyButton, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(698, 564);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(653, 68);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // SignButton
            // 
            this.SignButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignButton.Location = new System.Drawing.Point(3, 3);
            this.SignButton.Name = "SignButton";
            this.SignButton.Size = new System.Drawing.Size(310, 62);
            this.SignButton.TabIndex = 0;
            this.SignButton.Text = "Подписать текст";
            this.SignButton.UseVisualStyleBackColor = true;
            this.SignButton.Click += new System.EventHandler(this.SignButton_Click);
            // 
            // VerifyButton
            // 
            this.VerifyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VerifyButton.Location = new System.Drawing.Point(339, 3);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(311, 62);
            this.VerifyButton.TabIndex = 1;
            this.VerifyButton.Text = "Проверить подпись";
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // SignatureTextBox
            // 
            this.SignatureTextBox.Location = new System.Drawing.Point(695, 661);
            this.SignatureTextBox.Multiline = true;
            this.SignatureTextBox.Name = "SignatureTextBox";
            this.SignatureTextBox.Size = new System.Drawing.Size(653, 48);
            this.SignatureTextBox.TabIndex = 5;
            // 
            // SignatureText
            // 
            this.SignatureText.AutoSize = true;
            this.SignatureText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SignatureText.Location = new System.Drawing.Point(695, 639);
            this.SignatureText.Name = "SignatureText";
            this.SignatureText.Size = new System.Drawing.Size(157, 16);
            this.SignatureText.TabIndex = 6;
            this.SignatureText.Text = "Подписанный текст:";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.SignatureText);
            this.Controls.Add(this.SignatureTextBox);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::CYPHER_ULTIMATE3000.Properties.Resources.CyberUltimate;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cypher3000";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox OutputTextBox;
        private TextBox InputTextBox;
        private Label InputText;
        private Label OutputText;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox PrivKeyTextBox;
        private Label PrivKeyText;
        private Button GeneratePrivKeyButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Button EncryptButton;
        private Button DecryptButton;
        private Panel panel1;
        private RadioButton AESRadioButton;
        private RadioButton RSARadioButton;
        private Label ChooseAlgText;
        private Label PubKeyText;
        private TextBox PubKeyTextBox;
        private TableLayoutPanel tableLayoutPanel4;
        private Button SignButton;
        private Button VerifyButton;
        private TextBox SignatureTextBox;
        private Label SignatureText;
    }
}

