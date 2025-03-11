using System.Windows.Forms;

namespace CYPHER_ULTIMATE3000
{
    partial class Form1
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
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InputText = new System.Windows.Forms.Label();
            this.OutputText = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.KeyText = new System.Windows.Forms.Label();
            this.GenerateKeyButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AsymAlgRadioButton = new System.Windows.Forms.RadioButton();
            this.SymAlgRadioButton = new System.Windows.Forms.RadioButton();
            this.ChooseAlgText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.InputText.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputText.Location = new System.Drawing.Point(3, 0);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(652, 20);
            this.InputText.TabIndex = 3;
            this.InputText.Text = "Шифруемый/Дешифруемый текст";
            this.InputText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutputText
            // 
            this.OutputText.AutoSize = true;
            this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputText.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputText.Location = new System.Drawing.Point(686, 0);
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(653, 20);
            this.OutputText.TabIndex = 5;
            this.OutputText.Text = "Результат Шифрования/Дешифрования";
            this.OutputText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.KeyTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.KeyText, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.GenerateKeyButton, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 490);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(655, 81);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyTextBox.Location = new System.Drawing.Point(3, 23);
            this.KeyTextBox.Multiline = true;
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(321, 55);
            this.KeyTextBox.TabIndex = 0;
            // 
            // KeyText
            // 
            this.KeyText.AutoSize = true;
            this.KeyText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyText.Location = new System.Drawing.Point(3, 0);
            this.KeyText.Name = "KeyText";
            this.KeyText.Size = new System.Drawing.Size(321, 20);
            this.KeyText.TabIndex = 1;
            this.KeyText.Text = "Ключ:";
            this.KeyText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GenerateKeyButton
            // 
            this.GenerateKeyButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GenerateKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateKeyButton.Location = new System.Drawing.Point(330, 26);
            this.GenerateKeyButton.Name = "GenerateKeyButton";
            this.GenerateKeyButton.Size = new System.Drawing.Size(157, 49);
            this.GenerateKeyButton.TabIndex = 2;
            this.GenerateKeyButton.Text = "Сгенерировать ключ";
            this.GenerateKeyButton.UseVisualStyleBackColor = true;
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChooseAlgText);
            this.panel1.Controls.Add(this.SymAlgRadioButton);
            this.panel1.Controls.Add(this.AsymAlgRadioButton);
            this.panel1.Location = new System.Drawing.Point(12, 574);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 79);
            this.panel1.TabIndex = 3;
            // 
            // AsymAlgRadioButton
            // 
            this.AsymAlgRadioButton.AutoSize = true;
            this.AsymAlgRadioButton.Location = new System.Drawing.Point(3, 59);
            this.AsymAlgRadioButton.Name = "AsymAlgRadioButton";
            this.AsymAlgRadioButton.Size = new System.Drawing.Size(190, 17);
            this.AsymAlgRadioButton.TabIndex = 0;
            this.AsymAlgRadioButton.TabStop = true;
            this.AsymAlgRadioButton.Text = "Асимметричный алгоритм (RSA)";
            this.AsymAlgRadioButton.UseVisualStyleBackColor = true;
            // 
            // SymAlgRadioButton
            // 
            this.SymAlgRadioButton.AutoSize = true;
            this.SymAlgRadioButton.Location = new System.Drawing.Point(3, 36);
            this.SymAlgRadioButton.Name = "SymAlgRadioButton";
            this.SymAlgRadioButton.Size = new System.Drawing.Size(183, 17);
            this.SymAlgRadioButton.TabIndex = 1;
            this.SymAlgRadioButton.TabStop = true;
            this.SymAlgRadioButton.Text = "Симметричный алгоритм (AES)";
            this.SymAlgRadioButton.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1366, 768);
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
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox OutputTextBox;
        private TextBox InputTextBox;
        private Label InputText;
        private Label OutputText;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox KeyTextBox;
        private Label KeyText;
        private Button GenerateKeyButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Button EncryptButton;
        private Button DecryptButton;
        private Panel panel1;
        private RadioButton SymAlgRadioButton;
        private RadioButton AsymAlgRadioButton;
        private Label ChooseAlgText;
    }
}

