
namespace Store.Windows
{
    partial class ErrorWindow
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
            this.labelErrorText = new System.Windows.Forms.Label();
            this.pictureBoxAlert = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // labelErrorText
            // 
            this.labelErrorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.labelErrorText.Font = new System.Drawing.Font("Cambria", 9F);
            this.labelErrorText.ForeColor = System.Drawing.Color.Black;
            this.labelErrorText.Location = new System.Drawing.Point(79, 35);
            this.labelErrorText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelErrorText.Name = "labelErrorText";
            this.labelErrorText.Size = new System.Drawing.Size(269, 28);
            this.labelErrorText.TabIndex = 18;
            this.labelErrorText.Text = "Ошибка регистрации. \r\nПожалуйста, перепроверьте введенные данные";
            // 
            // pictureBoxAlert
            // 
            this.pictureBoxAlert.ErrorImage = null;
            this.pictureBoxAlert.Image = global::Store.Properties.Resources.alert;
            this.pictureBoxAlert.InitialImage = global::Store.Properties.Resources.alert;
            this.pictureBoxAlert.Location = new System.Drawing.Point(43, 33);
            this.pictureBoxAlert.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxAlert.Name = "pictureBoxAlert";
            this.pictureBoxAlert.Size = new System.Drawing.Size(32, 31);
            this.pictureBoxAlert.TabIndex = 19;
            this.pictureBoxAlert.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.okButton.Font = new System.Drawing.Font("Cambria", 9F);
            this.okButton.Location = new System.Drawing.Point(342, 99);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(46, 27);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "Ок";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(194)))), ((int)(((byte)(184)))));
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 41);
            this.panel1.TabIndex = 25;
            // 
            // ErrorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(394, 132);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.pictureBoxAlert);
            this.Controls.Add(this.labelErrorText);
            this.Controls.Add(this.panel1);
            this.Name = "ErrorWindow";
            this.Text = "ErrorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAlert;
        private System.Windows.Forms.Label labelErrorText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel1;
    }
}