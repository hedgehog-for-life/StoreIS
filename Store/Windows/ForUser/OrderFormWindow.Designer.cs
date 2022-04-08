
namespace Store.Windows.ForUser
{
    partial class OrderFormWindow
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
            this.labelGoodName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDeliveryMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPickupAddress = new System.Windows.Forms.Panel();
            this.checkedListBoxPaddresses = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxPcity = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPregion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPcountry = new System.Windows.Forms.ComboBox();
            this.labelBuyer = new System.Windows.Forms.Label();
            this.panelAddressDelivery = new System.Windows.Forms.Panel();
            this.textBoxDappartment = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxDhouse = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxDstreet = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxDindex = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxDcity = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDregion = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDcountry = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labelDeliveryDate = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.listBoxGoodsNames = new System.Windows.Forms.ListBox();
            this.listBoxResultNumber = new System.Windows.Forms.ListBox();
            this.listBoxGoodsPrices = new System.Windows.Forms.ListBox();
            this.listBoxGoodsResultCost = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.listBoxGoodsDiscounts = new System.Windows.Forms.ListBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.labelResultCost = new System.Windows.Forms.Label();
            this.labelDeliveryCost = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.buttonAddToSC = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelPickupAddress.SuspendLayout();
            this.panelAddressDelivery.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 63);
            this.panel1.TabIndex = 39;
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
            this.pictureBoxLogOut.Location = new System.Drawing.Point(561, 19);
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
            this.pictureBoxExit.Location = new System.Drawing.Point(604, 19);
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
            this.pictureBoxIcon.Location = new System.Drawing.Point(162, 9);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(216, 47);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelGoodName
            // 
            this.labelGoodName.AutoSize = true;
            this.labelGoodName.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.labelGoodName.Location = new System.Drawing.Point(16, 74);
            this.labelGoodName.Name = "labelGoodName";
            this.labelGoodName.Size = new System.Drawing.Size(222, 19);
            this.labelGoodName.TabIndex = 65;
            this.labelGoodName.Text = "Оформление нового заказа";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(18, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 66;
            this.label7.Text = "Покупатель";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(16, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 67;
            this.label1.Text = "Способ оплаты";
            // 
            // comboBoxPaymentMethod
            // 
            this.comboBoxPaymentMethod.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxPaymentMethod.FormattingEnabled = true;
            this.comboBoxPaymentMethod.Location = new System.Drawing.Point(143, 138);
            this.comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            this.comboBoxPaymentMethod.Size = new System.Drawing.Size(215, 23);
            this.comboBoxPaymentMethod.TabIndex = 68;
            this.comboBoxPaymentMethod.Text = "Наличными при получении";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 69;
            this.label2.Text = "Способ доставки";
            // 
            // comboBoxDeliveryMethod
            // 
            this.comboBoxDeliveryMethod.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxDeliveryMethod.FormattingEnabled = true;
            this.comboBoxDeliveryMethod.Location = new System.Drawing.Point(145, 177);
            this.comboBoxDeliveryMethod.Name = "comboBoxDeliveryMethod";
            this.comboBoxDeliveryMethod.Size = new System.Drawing.Size(215, 23);
            this.comboBoxDeliveryMethod.TabIndex = 70;
            this.comboBoxDeliveryMethod.Text = "Курьерская";
            this.comboBoxDeliveryMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeliveryMethod_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 15);
            this.label3.TabIndex = 72;
            this.label3.Text = "Выберите пункт самовывоза";
            // 
            // panelPickupAddress
            // 
            this.panelPickupAddress.Controls.Add(this.checkedListBoxPaddresses);
            this.panelPickupAddress.Controls.Add(this.label8);
            this.panelPickupAddress.Controls.Add(this.comboBoxPcity);
            this.panelPickupAddress.Controls.Add(this.label6);
            this.panelPickupAddress.Controls.Add(this.comboBoxPregion);
            this.panelPickupAddress.Controls.Add(this.label5);
            this.panelPickupAddress.Controls.Add(this.comboBoxPcountry);
            this.panelPickupAddress.Controls.Add(this.label3);
            this.panelPickupAddress.Location = new System.Drawing.Point(24, 216);
            this.panelPickupAddress.Name = "panelPickupAddress";
            this.panelPickupAddress.Size = new System.Drawing.Size(492, 257);
            this.panelPickupAddress.TabIndex = 74;
            this.panelPickupAddress.Visible = false;
            // 
            // checkedListBoxPaddresses
            // 
            this.checkedListBoxPaddresses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.checkedListBoxPaddresses.Font = new System.Drawing.Font("Cambria", 9F);
            this.checkedListBoxPaddresses.FormattingEnabled = true;
            this.checkedListBoxPaddresses.Location = new System.Drawing.Point(16, 137);
            this.checkedListBoxPaddresses.Name = "checkedListBoxPaddresses";
            this.checkedListBoxPaddresses.Size = new System.Drawing.Size(459, 89);
            this.checkedListBoxPaddresses.TabIndex = 80;
            this.checkedListBoxPaddresses.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxPaddresses_ItemCheck);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label8.Location = new System.Drawing.Point(13, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 78;
            this.label8.Text = "Выберите город";
            // 
            // comboBoxPcity
            // 
            this.comboBoxPcity.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxPcity.FormattingEnabled = true;
            this.comboBoxPcity.Location = new System.Drawing.Point(130, 100);
            this.comboBoxPcity.Name = "comboBoxPcity";
            this.comboBoxPcity.Size = new System.Drawing.Size(209, 23);
            this.comboBoxPcity.TabIndex = 79;
            this.comboBoxPcity.SelectedIndexChanged += new System.EventHandler(this.comboBoxPcity_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label6.Location = new System.Drawing.Point(13, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 76;
            this.label6.Text = "Выберите регион";
            // 
            // comboBoxPregion
            // 
            this.comboBoxPregion.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxPregion.FormattingEnabled = true;
            this.comboBoxPregion.Location = new System.Drawing.Point(130, 62);
            this.comboBoxPregion.Name = "comboBoxPregion";
            this.comboBoxPregion.Size = new System.Drawing.Size(209, 23);
            this.comboBoxPregion.TabIndex = 77;
            this.comboBoxPregion.SelectedIndexChanged += new System.EventHandler(this.comboBoxPregion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(13, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 75;
            this.label5.Text = "Выберите страну";
            // 
            // comboBoxPcountry
            // 
            this.comboBoxPcountry.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxPcountry.FormattingEnabled = true;
            this.comboBoxPcountry.Location = new System.Drawing.Point(130, 26);
            this.comboBoxPcountry.Name = "comboBoxPcountry";
            this.comboBoxPcountry.Size = new System.Drawing.Size(209, 23);
            this.comboBoxPcountry.TabIndex = 75;
            this.comboBoxPcountry.SelectedIndexChanged += new System.EventHandler(this.comboBoxPcountry_SelectedIndexChanged);
            // 
            // labelBuyer
            // 
            this.labelBuyer.AutoSize = true;
            this.labelBuyer.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.labelBuyer.Location = new System.Drawing.Point(142, 107);
            this.labelBuyer.Name = "labelBuyer";
            this.labelBuyer.Size = new System.Drawing.Size(216, 15);
            this.labelBuyer.TabIndex = 81;
            this.labelBuyer.Text = "Меркурьевна Саманта Геннадьевна";
            // 
            // panelAddressDelivery
            // 
            this.panelAddressDelivery.Controls.Add(this.textBoxDappartment);
            this.panelAddressDelivery.Controls.Add(this.label16);
            this.panelAddressDelivery.Controls.Add(this.textBoxDhouse);
            this.panelAddressDelivery.Controls.Add(this.label15);
            this.panelAddressDelivery.Controls.Add(this.textBoxDstreet);
            this.panelAddressDelivery.Controls.Add(this.label14);
            this.panelAddressDelivery.Controls.Add(this.textBoxDindex);
            this.panelAddressDelivery.Controls.Add(this.label13);
            this.panelAddressDelivery.Controls.Add(this.comboBoxDcity);
            this.panelAddressDelivery.Controls.Add(this.label9);
            this.panelAddressDelivery.Controls.Add(this.comboBoxDregion);
            this.panelAddressDelivery.Controls.Add(this.label10);
            this.panelAddressDelivery.Controls.Add(this.comboBoxDcountry);
            this.panelAddressDelivery.Controls.Add(this.label11);
            this.panelAddressDelivery.Controls.Add(this.label12);
            this.panelAddressDelivery.Location = new System.Drawing.Point(21, 216);
            this.panelAddressDelivery.Name = "panelAddressDelivery";
            this.panelAddressDelivery.Size = new System.Drawing.Size(399, 257);
            this.panelAddressDelivery.TabIndex = 81;
            // 
            // textBoxDappartment
            // 
            this.textBoxDappartment.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.textBoxDappartment.Location = new System.Drawing.Point(292, 220);
            this.textBoxDappartment.Name = "textBoxDappartment";
            this.textBoxDappartment.Size = new System.Drawing.Size(64, 23);
            this.textBoxDappartment.TabIndex = 88;
            this.textBoxDappartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDindex_KeyPress);
            this.textBoxDappartment.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDindex_Validating);
            this.textBoxDappartment.Validated += new System.EventHandler(this.textBoxDindex_Validated);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label16.Location = new System.Drawing.Point(221, 223);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 15);
            this.label16.TabIndex = 87;
            this.label16.Text = "Квартира";
            // 
            // textBoxDhouse
            // 
            this.textBoxDhouse.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.textBoxDhouse.Location = new System.Drawing.Point(78, 220);
            this.textBoxDhouse.Name = "textBoxDhouse";
            this.textBoxDhouse.Size = new System.Drawing.Size(64, 23);
            this.textBoxDhouse.TabIndex = 86;
            this.textBoxDhouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDindex_KeyPress);
            this.textBoxDhouse.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDindex_Validating);
            this.textBoxDhouse.Validated += new System.EventHandler(this.textBoxDindex_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label15.Location = new System.Drawing.Point(13, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 15);
            this.label15.TabIndex = 85;
            this.label15.Text = "Дом";
            // 
            // textBoxDstreet
            // 
            this.textBoxDstreet.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.textBoxDstreet.Location = new System.Drawing.Point(78, 180);
            this.textBoxDstreet.Name = "textBoxDstreet";
            this.textBoxDstreet.Size = new System.Drawing.Size(278, 23);
            this.textBoxDstreet.TabIndex = 84;
            this.textBoxDstreet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDstreet_KeyPress);
            this.textBoxDstreet.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDindex_Validating);
            this.textBoxDstreet.Validated += new System.EventHandler(this.textBoxDindex_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label14.Location = new System.Drawing.Point(13, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 15);
            this.label14.TabIndex = 83;
            this.label14.Text = "Улица";
            // 
            // textBoxDindex
            // 
            this.textBoxDindex.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.textBoxDindex.Location = new System.Drawing.Point(78, 26);
            this.textBoxDindex.Name = "textBoxDindex";
            this.textBoxDindex.Size = new System.Drawing.Size(278, 23);
            this.textBoxDindex.TabIndex = 82;
            this.textBoxDindex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDindex_KeyPress);
            this.textBoxDindex.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDindex_Validating);
            this.textBoxDindex.Validated += new System.EventHandler(this.textBoxDindex_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label13.Location = new System.Drawing.Point(13, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 15);
            this.label13.TabIndex = 80;
            this.label13.Text = "Город";
            // 
            // comboBoxDcity
            // 
            this.comboBoxDcity.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxDcity.FormattingEnabled = true;
            this.comboBoxDcity.Location = new System.Drawing.Point(78, 140);
            this.comboBoxDcity.Name = "comboBoxDcity";
            this.comboBoxDcity.Size = new System.Drawing.Size(278, 23);
            this.comboBoxDcity.TabIndex = 81;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label9.Location = new System.Drawing.Point(13, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 78;
            this.label9.Text = "Регион";
            // 
            // comboBoxDregion
            // 
            this.comboBoxDregion.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxDregion.FormattingEnabled = true;
            this.comboBoxDregion.Location = new System.Drawing.Point(78, 100);
            this.comboBoxDregion.Name = "comboBoxDregion";
            this.comboBoxDregion.Size = new System.Drawing.Size(278, 23);
            this.comboBoxDregion.TabIndex = 79;
            this.comboBoxDregion.SelectedIndexChanged += new System.EventHandler(this.comboBoxDregion_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label10.Location = new System.Drawing.Point(13, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 76;
            this.label10.Text = "Страна";
            // 
            // comboBoxDcountry
            // 
            this.comboBoxDcountry.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.comboBoxDcountry.FormattingEnabled = true;
            this.comboBoxDcountry.Location = new System.Drawing.Point(78, 62);
            this.comboBoxDcountry.Name = "comboBoxDcountry";
            this.comboBoxDcountry.Size = new System.Drawing.Size(278, 23);
            this.comboBoxDcountry.TabIndex = 77;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label11.Location = new System.Drawing.Point(13, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 15);
            this.label11.TabIndex = 75;
            this.label11.Text = "Индекс";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 15);
            this.label12.TabIndex = 72;
            this.label12.Text = "Введите адрес доставки";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(17, 488);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(213, 15);
            this.label17.TabIndex = 82;
            this.label17.Text = "Приблизительная дата доставки";
            // 
            // labelDeliveryDate
            // 
            this.labelDeliveryDate.AutoSize = true;
            this.labelDeliveryDate.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.labelDeliveryDate.Location = new System.Drawing.Point(241, 488);
            this.labelDeliveryDate.Name = "labelDeliveryDate";
            this.labelDeliveryDate.Size = new System.Drawing.Size(69, 15);
            this.labelDeliveryDate.TabIndex = 83;
            this.labelDeliveryDate.Text = "21.12.2021";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic);
            this.label19.Location = new System.Drawing.Point(17, 546);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 15);
            this.label19.TabIndex = 89;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(18, 539);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 15);
            this.label20.TabIndex = 90;
            this.label20.Text = "Товары";
            // 
            // listBoxGoodsNames
            // 
            this.listBoxGoodsNames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.listBoxGoodsNames.Font = new System.Drawing.Font("Cambria", 9F);
            this.listBoxGoodsNames.FormattingEnabled = true;
            this.listBoxGoodsNames.ItemHeight = 14;
            this.listBoxGoodsNames.Location = new System.Drawing.Point(21, 583);
            this.listBoxGoodsNames.Name = "listBoxGoodsNames";
            this.listBoxGoodsNames.Size = new System.Drawing.Size(354, 74);
            this.listBoxGoodsNames.TabIndex = 91;
            // 
            // listBoxResultNumber
            // 
            this.listBoxResultNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.listBoxResultNumber.Font = new System.Drawing.Font("Cambria", 9F);
            this.listBoxResultNumber.FormattingEnabled = true;
            this.listBoxResultNumber.ItemHeight = 14;
            this.listBoxResultNumber.Location = new System.Drawing.Point(498, 583);
            this.listBoxResultNumber.Name = "listBoxResultNumber";
            this.listBoxResultNumber.Size = new System.Drawing.Size(44, 74);
            this.listBoxResultNumber.TabIndex = 92;
            // 
            // listBoxGoodsPrices
            // 
            this.listBoxGoodsPrices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.listBoxGoodsPrices.Font = new System.Drawing.Font("Cambria", 9F);
            this.listBoxGoodsPrices.FormattingEnabled = true;
            this.listBoxGoodsPrices.ItemHeight = 14;
            this.listBoxGoodsPrices.Location = new System.Drawing.Point(377, 583);
            this.listBoxGoodsPrices.Name = "listBoxGoodsPrices";
            this.listBoxGoodsPrices.Size = new System.Drawing.Size(73, 74);
            this.listBoxGoodsPrices.TabIndex = 93;
            // 
            // listBoxGoodsResultCost
            // 
            this.listBoxGoodsResultCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.listBoxGoodsResultCost.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.listBoxGoodsResultCost.FormattingEnabled = true;
            this.listBoxGoodsResultCost.ItemHeight = 14;
            this.listBoxGoodsResultCost.Location = new System.Drawing.Point(544, 583);
            this.listBoxGoodsResultCost.Name = "listBoxGoodsResultCost";
            this.listBoxGoodsResultCost.Size = new System.Drawing.Size(73, 74);
            this.listBoxGoodsResultCost.TabIndex = 94;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Italic);
            this.label21.Location = new System.Drawing.Point(17, 562);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(131, 14);
            this.label21.TabIndex = 89;
            this.label21.Text = "Артикул, наименование";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Italic);
            this.label22.Location = new System.Drawing.Point(374, 562);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 14);
            this.label22.TabIndex = 95;
            this.label22.Text = "Цена";
            // 
            // listBoxGoodsDiscounts
            // 
            this.listBoxGoodsDiscounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.listBoxGoodsDiscounts.Font = new System.Drawing.Font("Cambria", 9F);
            this.listBoxGoodsDiscounts.FormattingEnabled = true;
            this.listBoxGoodsDiscounts.ItemHeight = 14;
            this.listBoxGoodsDiscounts.Location = new System.Drawing.Point(452, 583);
            this.listBoxGoodsDiscounts.Name = "listBoxGoodsDiscounts";
            this.listBoxGoodsDiscounts.Size = new System.Drawing.Size(44, 74);
            this.listBoxGoodsDiscounts.TabIndex = 96;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Italic);
            this.label23.Location = new System.Drawing.Point(449, 562);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 14);
            this.label23.TabIndex = 97;
            this.label23.Text = "Скидка";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Italic);
            this.label24.Location = new System.Drawing.Point(498, 562);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 14);
            this.label24.TabIndex = 98;
            this.label24.Text = "Кол-во";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label25.Location = new System.Drawing.Point(541, 561);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 15);
            this.label25.TabIndex = 99;
            this.label25.Text = "Итого";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(21, 679);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 15);
            this.label26.TabIndex = 100;
            this.label26.Text = "ИТОГО";
            // 
            // labelResultCost
            // 
            this.labelResultCost.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelResultCost.Location = new System.Drawing.Point(501, 679);
            this.labelResultCost.Name = "labelResultCost";
            this.labelResultCost.Size = new System.Drawing.Size(116, 15);
            this.labelResultCost.TabIndex = 101;
            this.labelResultCost.Text = "2980";
            this.labelResultCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDeliveryCost
            // 
            this.labelDeliveryCost.AutoSize = true;
            this.labelDeliveryCost.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.labelDeliveryCost.Location = new System.Drawing.Point(162, 514);
            this.labelDeliveryCost.Name = "labelDeliveryCost";
            this.labelDeliveryCost.Size = new System.Drawing.Size(45, 15);
            this.labelDeliveryCost.TabIndex = 102;
            this.labelDeliveryCost.Text = "560,00";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label29.Location = new System.Drawing.Point(17, 514);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(133, 15);
            this.label29.TabIndex = 103;
            this.label29.Text = "Стоимость доставки";
            // 
            // buttonAddToSC
            // 
            this.buttonAddToSC.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAddToSC.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonAddToSC.Location = new System.Drawing.Point(506, 107);
            this.buttonAddToSC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddToSC.Name = "buttonAddToSC";
            this.buttonAddToSC.Size = new System.Drawing.Size(128, 29);
            this.buttonAddToSC.TabIndex = 104;
            this.buttonAddToSC.Text = "Оформить";
            this.buttonAddToSC.UseVisualStyleBackColor = false;
            this.buttonAddToSC.Click += new System.EventHandler(this.buttonAddToSC_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.buttonCancel.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonCancel.Location = new System.Drawing.Point(506, 141);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(128, 29);
            this.buttonCancel.TabIndex = 105;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // OrderFormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(650, 456);
            this.Controls.Add(this.panelPickupAddress);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddToSC);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.labelDeliveryCost);
            this.Controls.Add(this.labelResultCost);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.listBoxGoodsDiscounts);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.listBoxGoodsResultCost);
            this.Controls.Add(this.listBoxGoodsPrices);
            this.Controls.Add(this.listBoxResultNumber);
            this.Controls.Add(this.listBoxGoodsNames);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.labelDeliveryDate);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.labelBuyer);
            this.Controls.Add(this.comboBoxDeliveryMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPaymentMethod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelGoodName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelAddressDelivery);
            this.Name = "OrderFormWindow";
            this.Text = "OrderFormWindow";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelPickupAddress.ResumeLayout(false);
            this.panelPickupAddress.PerformLayout();
            this.panelAddressDelivery.ResumeLayout(false);
            this.panelAddressDelivery.PerformLayout();
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
        private System.Windows.Forms.Label labelGoodName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPaymentMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDeliveryMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelPickupAddress;
        private System.Windows.Forms.CheckedListBox checkedListBoxPaddresses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxPcity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPregion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPcountry;
        private System.Windows.Forms.Label labelBuyer;
        private System.Windows.Forms.Panel panelAddressDelivery;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDappartment;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxDhouse;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxDstreet;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxDindex;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxDcity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDregion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDcountry;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelDeliveryDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListBox listBoxGoodsNames;
        private System.Windows.Forms.ListBox listBoxResultNumber;
        private System.Windows.Forms.ListBox listBoxGoodsPrices;
        private System.Windows.Forms.ListBox listBoxGoodsResultCost;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox listBoxGoodsDiscounts;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label labelResultCost;
        private System.Windows.Forms.Label labelDeliveryCost;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button buttonAddToSC;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}