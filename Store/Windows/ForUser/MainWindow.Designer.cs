
namespace Store.Windows.ForUser
{
    partial class MainWindow
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
            this.buttonWatchThroughItems = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogOut = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.buttonWork = new System.Windows.Forms.Button();
            this.buttonQuestion = new System.Windows.Forms.Button();
            this.buttonUserOrders = new System.Windows.Forms.Button();
            this.panelAllPromotions = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panelAllCollections = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.panelAllCategories = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxHavePromotions = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelAllPromotions.SuspendLayout();
            this.panelAllCollections.SuspendLayout();
            this.panelAllCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWatchThroughItems
            // 
            this.buttonWatchThroughItems.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonWatchThroughItems.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonWatchThroughItems.Location = new System.Drawing.Point(11, 75);
            this.buttonWatchThroughItems.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWatchThroughItems.Name = "buttonWatchThroughItems";
            this.buttonWatchThroughItems.Size = new System.Drawing.Size(149, 36);
            this.buttonWatchThroughItems.TabIndex = 21;
            this.buttonWatchThroughItems.Text = "Просмотр товаров";
            this.buttonWatchThroughItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWatchThroughItems.UseVisualStyleBackColor = false;
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 63);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Store.Properties.Resources.shopping_cart;
            this.pictureBox1.Location = new System.Drawing.Point(61, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
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
            this.pictureBoxLogOut.Location = new System.Drawing.Point(812, 19);
            this.pictureBoxLogOut.Margin = new System.Windows.Forms.Padding(2);
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
            this.pictureBoxExit.Location = new System.Drawing.Point(855, 19);
            this.pictureBoxExit.Margin = new System.Windows.Forms.Padding(2);
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
            this.pictureBoxAvatar.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 4;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::Store.Properties.Resources.icon_ready;
            this.pictureBoxIcon.Location = new System.Drawing.Point(325, 9);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(216, 47);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // buttonWork
            // 
            this.buttonWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.buttonWork.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonWork.Location = new System.Drawing.Point(11, 155);
            this.buttonWork.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWork.Name = "buttonWork";
            this.buttonWork.Size = new System.Drawing.Size(149, 36);
            this.buttonWork.TabIndex = 23;
            this.buttonWork.Text = "Заявка на трудоустройство";
            this.buttonWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWork.UseVisualStyleBackColor = false;
            this.buttonWork.Click += new System.EventHandler(this.buttonWork_Click);
            // 
            // buttonQuestion
            // 
            this.buttonQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.buttonQuestion.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonQuestion.Location = new System.Drawing.Point(11, 195);
            this.buttonQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.buttonQuestion.Name = "buttonQuestion";
            this.buttonQuestion.Size = new System.Drawing.Size(149, 36);
            this.buttonQuestion.TabIndex = 24;
            this.buttonQuestion.Text = "Вопросы";
            this.buttonQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonQuestion.UseVisualStyleBackColor = false;
            this.buttonQuestion.Click += new System.EventHandler(this.buttonQuestion_Click);
            // 
            // buttonUserOrders
            // 
            this.buttonUserOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.buttonUserOrders.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonUserOrders.Location = new System.Drawing.Point(11, 115);
            this.buttonUserOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUserOrders.Name = "buttonUserOrders";
            this.buttonUserOrders.Size = new System.Drawing.Size(149, 36);
            this.buttonUserOrders.TabIndex = 25;
            this.buttonUserOrders.Text = "Мои заказы";
            this.buttonUserOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUserOrders.UseVisualStyleBackColor = false;
            this.buttonUserOrders.Click += new System.EventHandler(this.buttonUserOrders_Click);
            // 
            // panelAllPromotions
            // 
            this.panelAllPromotions.AutoScroll = true;
            this.panelAllPromotions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAllPromotions.Controls.Add(this.label14);
            this.panelAllPromotions.Location = new System.Drawing.Point(736, 75);
            this.panelAllPromotions.Name = "panelAllPromotions";
            this.panelAllPromotions.Size = new System.Drawing.Size(153, 205);
            this.panelAllPromotions.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(3, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Все акции";
            // 
            // panelAllCollections
            // 
            this.panelAllCollections.AutoScroll = true;
            this.panelAllCollections.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAllCollections.Controls.Add(this.label23);
            this.panelAllCollections.Location = new System.Drawing.Point(736, 291);
            this.panelAllCollections.Name = "panelAllCollections";
            this.panelAllCollections.Size = new System.Drawing.Size(153, 205);
            this.panelAllCollections.TabIndex = 32;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(3, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 15);
            this.label23.TabIndex = 28;
            this.label23.Text = "Все коллекции";
            // 
            // panelAllCategories
            // 
            this.panelAllCategories.AutoScroll = true;
            this.panelAllCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAllCategories.Controls.Add(this.label28);
            this.panelAllCategories.Location = new System.Drawing.Point(736, 509);
            this.panelAllCategories.Name = "panelAllCategories";
            this.panelAllCategories.Size = new System.Drawing.Size(150, 205);
            this.panelAllCategories.TabIndex = 33;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(3, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(97, 15);
            this.label28.TabIndex = 28;
            this.label28.Text = "Все категории";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Font = new System.Drawing.Font("Cambria", 9F);
            this.textBoxValue.Location = new System.Drawing.Point(220, 83);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(387, 22);
            this.textBoxValue.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(217, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "Введите название или артикул товара";
            // 
            // checkBoxHavePromotions
            // 
            this.checkBoxHavePromotions.AutoSize = true;
            this.checkBoxHavePromotions.Location = new System.Drawing.Point(613, 88);
            this.checkBoxHavePromotions.Name = "checkBoxHavePromotions";
            this.checkBoxHavePromotions.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHavePromotions.TabIndex = 35;
            this.checkBoxHavePromotions.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(563, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "Есть скидки";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Store.Properties.Resources.search_interface_symbol;
            this.pictureBox2.Location = new System.Drawing.Point(634, 83);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(923, 456);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxHavePromotions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.panelAllCategories);
            this.Controls.Add(this.panelAllCollections);
            this.Controls.Add(this.panelAllPromotions);
            this.Controls.Add(this.buttonUserOrders);
            this.Controls.Add(this.buttonQuestion);
            this.Controls.Add(this.buttonWork);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonWatchThroughItems);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelAllPromotions.ResumeLayout(false);
            this.panelAllPromotions.PerformLayout();
            this.panelAllCollections.ResumeLayout(false);
            this.panelAllCollections.PerformLayout();
            this.panelAllCategories.ResumeLayout(false);
            this.panelAllCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWatchThroughItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLogOut;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Button buttonWork;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonQuestion;
        private System.Windows.Forms.Button buttonUserOrders;
        private System.Windows.Forms.Panel panelAllPromotions;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelAllCollections;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panelAllCategories;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxHavePromotions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}