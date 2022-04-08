
namespace Store.Windows.ForConsultant
{
    partial class UserInfoWIndow
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
            this.labelGoodName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDateBirth = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonAddToSC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelGoodName
            // 
            this.labelGoodName.AutoSize = true;
            this.labelGoodName.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.labelGoodName.Location = new System.Drawing.Point(24, 21);
            this.labelGoodName.Name = "labelGoodName";
            this.labelGoodName.Size = new System.Drawing.Size(186, 19);
            this.labelGoodName.TabIndex = 65;
            this.labelGoodName.Text = "Данные пользователя ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(37, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 67;
            this.label3.Text = "Дата рождения:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(37, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "ФИО:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(37, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 68;
            this.label4.Text = "Телефон:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(37, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 69;
            this.label5.Text = "Email:";
            // 
            // labelUserName
            // 
            this.labelUserName.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.labelUserName.Location = new System.Drawing.Point(99, 63);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(261, 15);
            this.labelUserName.TabIndex = 70;
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDateBirth
            // 
            this.labelDateBirth.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.labelDateBirth.Location = new System.Drawing.Point(181, 94);
            this.labelDateBirth.Name = "labelDateBirth";
            this.labelDateBirth.Size = new System.Drawing.Size(179, 15);
            this.labelDateBirth.TabIndex = 71;
            this.labelDateBirth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPhone
            // 
            this.labelPhone.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.labelPhone.Location = new System.Drawing.Point(181, 128);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(179, 15);
            this.labelPhone.TabIndex = 72;
            this.labelPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEmail
            // 
            this.labelEmail.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.labelEmail.Location = new System.Drawing.Point(181, 161);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(179, 15);
            this.labelEmail.TabIndex = 73;
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonAddToSC
            // 
            this.buttonAddToSC.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAddToSC.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonAddToSC.Location = new System.Drawing.Point(313, 198);
            this.buttonAddToSC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddToSC.Name = "buttonAddToSC";
            this.buttonAddToSC.Size = new System.Drawing.Size(47, 29);
            this.buttonAddToSC.TabIndex = 107;
            this.buttonAddToSC.Text = "Ок";
            this.buttonAddToSC.UseVisualStyleBackColor = false;
            this.buttonAddToSC.Click += new System.EventHandler(this.buttonAddToSC_Click);
            // 
            // UserInfoWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(382, 238);
            this.Controls.Add(this.buttonAddToSC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.labelDateBirth);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelGoodName);
            this.Name = "UserInfoWIndow";
            this.Text = "UserInfoWIndow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGoodName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDateBirth;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonAddToSC;
    }
}