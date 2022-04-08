
namespace Store.Windows
{
    partial class SuccessWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.labelErrorText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.okButton.Font = new System.Drawing.Font("Cambria", 9F);
            this.okButton.Location = new System.Drawing.Point(341, 99);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(46, 27);
            this.okButton.TabIndex = 27;
            this.okButton.Text = "Ок";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // labelErrorText
            // 
            this.labelErrorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.labelErrorText.Font = new System.Drawing.Font("Cambria", 9F);
            this.labelErrorText.ForeColor = System.Drawing.Color.Black;
            this.labelErrorText.Location = new System.Drawing.Point(56, 35);
            this.labelErrorText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelErrorText.Name = "labelErrorText";
            this.labelErrorText.Size = new System.Drawing.Size(269, 28);
            this.labelErrorText.TabIndex = 26;
            this.labelErrorText.Text = "Ошибка регистрации. \r\nПожалуйста, перепроверьте введенные данные";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(194)))), ((int)(((byte)(184)))));
            this.panel1.Location = new System.Drawing.Point(-1, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 41);
            this.panel1.TabIndex = 28;
            // 
            // SuccessWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(394, 132);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.labelErrorText);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SuccessWindow";
            this.Text = "SuccessWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label labelErrorText;
        private System.Windows.Forms.Panel panel1;
    }
}