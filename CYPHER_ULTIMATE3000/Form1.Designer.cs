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
            this.SuspendLayout();
            this.Icon = Properties.Resources.CyberUltimate;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cypher3000";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

