
namespace Store.Windows.ForUser
{
    partial class QuestionWindow
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogOut = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.buttonUserOrders = new System.Windows.Forms.Button();
            this.buttonQuestion = new System.Windows.Forms.Button();
            this.buttonWork = new System.Windows.Forms.Button();
            this.buttonWatchThroughItems = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.buttonAddQuestion = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxQThemes = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(22)))), ((int)(((byte)(81)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBoxLogOut);
            this.panel1.Controls.Add(this.pictureBoxExit);
            this.panel1.Controls.Add(this.pictureBoxAvatar);
            this.panel1.Controls.Add(this.pictureBoxIcon);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 63);
            this.panel1.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Store.Properties.Resources.shopping_cart;
            this.pictureBox1.Location = new System.Drawing.Point(61, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxLogOut
            // 
            this.pictureBoxLogOut.Image = global::Store.Properties.Resources.logout;
            this.pictureBoxLogOut.Location = new System.Drawing.Point(892, 19);
            this.pictureBoxLogOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxLogOut.Name = "pictureBoxLogOut";
            this.pictureBoxLogOut.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogOut.TabIndex = 6;
            this.pictureBoxLogOut.TabStop = false;
            this.pictureBoxLogOut.Click += new System.EventHandler(this.pictureBoxLogOut_Click);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.Image = global::Store.Properties.Resources.close;
            this.pictureBoxExit.Location = new System.Drawing.Point(935, 19);
            this.pictureBoxExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExit.TabIndex = 5;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = global::Store.Properties.Resources.user;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(20, 15);
            this.pictureBoxAvatar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 4;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::Store.Properties.Resources.icon_ready;
            this.pictureBoxIcon.Location = new System.Drawing.Point(364, 8);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(216, 47);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // buttonUserOrders
            // 
            this.buttonUserOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.buttonUserOrders.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonUserOrders.Location = new System.Drawing.Point(11, 116);
            this.buttonUserOrders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUserOrders.Name = "buttonUserOrders";
            this.buttonUserOrders.Size = new System.Drawing.Size(149, 36);
            this.buttonUserOrders.TabIndex = 29;
            this.buttonUserOrders.Text = "Мои заказы";
            this.buttonUserOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUserOrders.UseVisualStyleBackColor = false;
            this.buttonUserOrders.Click += new System.EventHandler(this.buttonUserOrders_Click);
            // 
            // buttonQuestion
            // 
            this.buttonQuestion.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonQuestion.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonQuestion.Location = new System.Drawing.Point(11, 196);
            this.buttonQuestion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonQuestion.Name = "buttonQuestion";
            this.buttonQuestion.Size = new System.Drawing.Size(149, 36);
            this.buttonQuestion.TabIndex = 28;
            this.buttonQuestion.Text = "Вопросы";
            this.buttonQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonQuestion.UseVisualStyleBackColor = false;
            // 
            // buttonWork
            // 
            this.buttonWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.buttonWork.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonWork.Location = new System.Drawing.Point(11, 156);
            this.buttonWork.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonWork.Name = "buttonWork";
            this.buttonWork.Size = new System.Drawing.Size(149, 36);
            this.buttonWork.TabIndex = 27;
            this.buttonWork.Text = "Заявка на трудоустройство";
            this.buttonWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWork.UseVisualStyleBackColor = false;
            this.buttonWork.Click += new System.EventHandler(this.buttonWork_Click);
            // 
            // buttonWatchThroughItems
            // 
            this.buttonWatchThroughItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.buttonWatchThroughItems.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonWatchThroughItems.Location = new System.Drawing.Point(11, 76);
            this.buttonWatchThroughItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonWatchThroughItems.Name = "buttonWatchThroughItems";
            this.buttonWatchThroughItems.Size = new System.Drawing.Size(149, 36);
            this.buttonWatchThroughItems.TabIndex = 26;
            this.buttonWatchThroughItems.Text = "Просмотр товаров";
            this.buttonWatchThroughItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWatchThroughItems.UseVisualStyleBackColor = false;
            this.buttonWatchThroughItems.Click += new System.EventHandler(this.buttonWatchThroughItems_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(182, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 15);
            this.label13.TabIndex = 9;
            this.label13.Text = "Тема вопроса";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(182, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 15);
            this.label14.TabIndex = 34;
            this.label14.Text = "Текст вопроса";
            // 
            // richTextBoxQuestion
            // 
            this.richTextBoxQuestion.Font = new System.Drawing.Font("Cambria", 9F);
            this.richTextBoxQuestion.Location = new System.Drawing.Point(185, 195);
            this.richTextBoxQuestion.Name = "richTextBoxQuestion";
            this.richTextBoxQuestion.Size = new System.Drawing.Size(383, 96);
            this.richTextBoxQuestion.TabIndex = 35;
            this.richTextBoxQuestion.Text = "";
            this.richTextBoxQuestion.Validating += new System.ComponentModel.CancelEventHandler(this.richTextBoxQuestion_Validating);
            this.richTextBoxQuestion.Validated += new System.EventHandler(this.richTextBoxQuestion_Validated);
            // 
            // buttonAddQuestion
            // 
            this.buttonAddQuestion.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAddQuestion.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonAddQuestion.Location = new System.Drawing.Point(185, 314);
            this.buttonAddQuestion.Name = "buttonAddQuestion";
            this.buttonAddQuestion.Size = new System.Drawing.Size(127, 32);
            this.buttonAddQuestion.TabIndex = 36;
            this.buttonAddQuestion.Text = "Задать вопрос";
            this.buttonAddQuestion.UseVisualStyleBackColor = false;
            this.buttonAddQuestion.Click += new System.EventHandler(this.buttonAddQuestion_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label15.Location = new System.Drawing.Point(588, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 15);
            this.label15.TabIndex = 37;
            this.label15.Text = "Мои вопросы";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label16.Location = new System.Drawing.Point(182, 428);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(184, 15);
            this.label16.TabIndex = 38;
            this.label16.Text = "Вопросы, ожидающие ответа";
            // 
            // comboBoxQThemes
            // 
            this.comboBoxQThemes.Font = new System.Drawing.Font("Cambria", 9F);
            this.comboBoxQThemes.FormattingEnabled = true;
            this.comboBoxQThemes.Location = new System.Drawing.Point(185, 116);
            this.comboBoxQThemes.Name = "comboBoxQThemes";
            this.comboBoxQThemes.Size = new System.Drawing.Size(383, 22);
            this.comboBoxQThemes.TabIndex = 39;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // QuestionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(981, 456);
            this.Controls.Add(this.comboBoxQThemes);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonAddQuestion);
            this.Controls.Add(this.richTextBoxQuestion);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonUserOrders);
            this.Controls.Add(this.buttonQuestion);
            this.Controls.Add(this.buttonWork);
            this.Controls.Add(this.buttonWatchThroughItems);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "QuestionWindow";
            this.Text = "QuestionWindow";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxLogOut;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Button buttonUserOrders;
        private System.Windows.Forms.Button buttonQuestion;
        private System.Windows.Forms.Button buttonWork;
        private System.Windows.Forms.Button buttonWatchThroughItems;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox richTextBoxQuestion;
        private System.Windows.Forms.Button buttonAddQuestion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxQThemes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}