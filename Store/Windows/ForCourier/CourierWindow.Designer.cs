
namespace Store.Windows.ForCourier
{
    partial class CourierWindow
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
            this.tabControlCourier = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.buttonSubmitChanges = new System.Windows.Forms.Button();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.tabPageCDeliveries = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxLogOut = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCourierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCourier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddressId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPaymentMethodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTakeOrderToDeliver = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnUserFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnUserPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnCourierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnCourier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnAddressId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnPaymentMethodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnDeliveryPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnIsVerified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InPrColumnStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InPrColumnStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabControlCourier.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.tabPageCDeliveries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlCourier
            // 
            this.tabControlCourier.Controls.Add(this.tabPageOrders);
            this.tabControlCourier.Controls.Add(this.tabPageCDeliveries);
            this.tabControlCourier.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlCourier.ItemSize = new System.Drawing.Size(486, 19);
            this.tabControlCourier.Location = new System.Drawing.Point(4, 68);
            this.tabControlCourier.Name = "tabControlCourier";
            this.tabControlCourier.SelectedIndex = 0;
            this.tabControlCourier.Size = new System.Drawing.Size(975, 430);
            this.tabControlCourier.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlCourier.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.tabPageOrders.Controls.Add(this.buttonSubmitChanges);
            this.tabPageOrders.Controls.Add(this.dataGridViewOrders);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 23);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(967, 403);
            this.tabPageOrders.TabIndex = 0;
            this.tabPageOrders.Text = "Заказы";
            // 
            // buttonSubmitChanges
            // 
            this.buttonSubmitChanges.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonSubmitChanges.Location = new System.Drawing.Point(439, 374);
            this.buttonSubmitChanges.Name = "buttonSubmitChanges";
            this.buttonSubmitChanges.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmitChanges.TabIndex = 1;
            this.buttonSubmitChanges.Text = "Ok";
            this.buttonSubmitChanges.UseVisualStyleBackColor = false;
            this.buttonSubmitChanges.Click += new System.EventHandler(this.buttonSubmitChanges_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.AutoGenerateColumns = false;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnOrderNumber,
            this.ColumnUserId,
            this.ColumnUser,
            this.ColumnCourierId,
            this.ColumnCourier,
            this.ColumnAddressId,
            this.ColumnAddress,
            this.ColumnPaymentMethodId,
            this.ColumnPaymentMethod,
            this.deliveryPriceDataGridViewTextBoxColumn,
            this.ColumnDeliveryDate,
            this.totalCostDataGridViewTextBoxColumn,
            this.ColumnTakeOrderToDeliver});
            this.dataGridViewOrders.DataSource = this.orderBindingSource;
            this.dataGridViewOrders.Location = new System.Drawing.Point(6, 14);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(954, 354);
            this.dataGridViewOrders.TabIndex = 0;
            this.dataGridViewOrders.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellEndEdit);
            this.dataGridViewOrders.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellEnter);
            this.dataGridViewOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewOrders_CellFormatting);
            this.dataGridViewOrders.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellValidated);
            this.dataGridViewOrders.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewOrders_CellValidating);
            // 
            // tabPageCDeliveries
            // 
            this.tabPageCDeliveries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.tabPageCDeliveries.Controls.Add(this.dataGridView1);
            this.tabPageCDeliveries.Location = new System.Drawing.Point(4, 23);
            this.tabPageCDeliveries.Name = "tabPageCDeliveries";
            this.tabPageCDeliveries.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCDeliveries.Size = new System.Drawing.Size(967, 403);
            this.tabPageCDeliveries.TabIndex = 1;
            this.tabPageCDeliveries.Text = "Мои доставки";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.InPrColumnOrderNumber,
            this.InPrColumnUserId,
            this.InPrColumnUserFIO,
            this.InPrColumnUserPhone,
            this.InPrColumnCourierId,
            this.InPrColumnCourier,
            this.InPrColumnAddressId,
            this.InPrColumnAddress,
            this.InPrColumnPaymentMethodId,
            this.InPrColumnPaymentMethod,
            this.InPrColumnDeliveryPrice,
            this.InPrColumnTotalCost,
            this.InPrColumnDeliveryDate,
            this.InPrColumnIsVerified,
            this.InPrColumnStatusId,
            this.InPrColumnStatus});
            this.dataGridView1.DataSource = this.orderBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(939, 372);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(22)))), ((int)(((byte)(81)))));
            this.panel1.Controls.Add(this.pictureBoxLogOut);
            this.panel1.Controls.Add(this.pictureBoxExit);
            this.panel1.Controls.Add(this.pictureBoxAvatar);
            this.panel1.Controls.Add(this.pictureBoxIcon);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 63);
            this.panel1.TabIndex = 2;
            // 
            // pictureBoxLogOut
            // 
            this.pictureBoxLogOut.Image = global::Store.Properties.Resources.logout;
            this.pictureBoxLogOut.Location = new System.Drawing.Point(898, 21);
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
            this.pictureBoxExit.Location = new System.Drawing.Point(941, 21);
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
            this.pictureBoxIcon.Location = new System.Drawing.Point(431, 9);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(216, 47);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(Store.DataBase.Entities.Order);
            // 
            // orderBindingSource1
            // 
            this.orderBindingSource1.DataSource = typeof(Store.DataBase.Entities.Order);
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnOrderNumber
            // 
            this.ColumnOrderNumber.DataPropertyName = "OrderNumber";
            this.ColumnOrderNumber.HeaderText = "Номер заказа";
            this.ColumnOrderNumber.Name = "ColumnOrderNumber";
            this.ColumnOrderNumber.ReadOnly = true;
            // 
            // ColumnUserId
            // 
            this.ColumnUserId.DataPropertyName = "UserId";
            this.ColumnUserId.HeaderText = "UserId";
            this.ColumnUserId.Name = "ColumnUserId";
            this.ColumnUserId.Visible = false;
            // 
            // ColumnUser
            // 
            this.ColumnUser.HeaderText = "Покупатель";
            this.ColumnUser.Name = "ColumnUser";
            this.ColumnUser.Width = 150;
            // 
            // ColumnCourierId
            // 
            this.ColumnCourierId.DataPropertyName = "CourierId";
            this.ColumnCourierId.HeaderText = "CourierId";
            this.ColumnCourierId.Name = "ColumnCourierId";
            this.ColumnCourierId.Visible = false;
            // 
            // ColumnCourier
            // 
            this.ColumnCourier.HeaderText = "Курьер";
            this.ColumnCourier.Name = "ColumnCourier";
            this.ColumnCourier.Width = 150;
            // 
            // ColumnAddressId
            // 
            this.ColumnAddressId.DataPropertyName = "AddressId";
            this.ColumnAddressId.HeaderText = "AddressId";
            this.ColumnAddressId.Name = "ColumnAddressId";
            this.ColumnAddressId.Visible = false;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.HeaderText = "Адрес доставки";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.ReadOnly = true;
            // 
            // ColumnPaymentMethodId
            // 
            this.ColumnPaymentMethodId.DataPropertyName = "PaymentMethod";
            this.ColumnPaymentMethodId.HeaderText = "PaymentMethod";
            this.ColumnPaymentMethodId.Name = "ColumnPaymentMethodId";
            this.ColumnPaymentMethodId.Visible = false;
            // 
            // ColumnPaymentMethod
            // 
            this.ColumnPaymentMethod.HeaderText = "Способ оплаты";
            this.ColumnPaymentMethod.Name = "ColumnPaymentMethod";
            this.ColumnPaymentMethod.ReadOnly = true;
            // 
            // deliveryPriceDataGridViewTextBoxColumn
            // 
            this.deliveryPriceDataGridViewTextBoxColumn.DataPropertyName = "DeliveryPrice";
            this.deliveryPriceDataGridViewTextBoxColumn.HeaderText = "Стоимость доставки";
            this.deliveryPriceDataGridViewTextBoxColumn.Name = "deliveryPriceDataGridViewTextBoxColumn";
            this.deliveryPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryPriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // ColumnDeliveryDate
            // 
            this.ColumnDeliveryDate.DataPropertyName = "DeliveryDate";
            this.ColumnDeliveryDate.HeaderText = "Дата доставки";
            this.ColumnDeliveryDate.Name = "ColumnDeliveryDate";
            this.ColumnDeliveryDate.ReadOnly = true;
            // 
            // totalCostDataGridViewTextBoxColumn
            // 
            this.totalCostDataGridViewTextBoxColumn.DataPropertyName = "TotalCost";
            this.totalCostDataGridViewTextBoxColumn.HeaderText = "Итоговая стоимость";
            this.totalCostDataGridViewTextBoxColumn.Name = "totalCostDataGridViewTextBoxColumn";
            this.totalCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalCostDataGridViewTextBoxColumn.Width = 80;
            // 
            // ColumnTakeOrderToDeliver
            // 
            this.ColumnTakeOrderToDeliver.HeaderText = "Взять";
            this.ColumnTakeOrderToDeliver.Name = "ColumnTakeOrderToDeliver";
            this.ColumnTakeOrderToDeliver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTakeOrderToDeliver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnTakeOrderToDeliver.Width = 50;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // InPrColumnOrderNumber
            // 
            this.InPrColumnOrderNumber.DataPropertyName = "OrderNumber";
            this.InPrColumnOrderNumber.HeaderText = "Номер заказа";
            this.InPrColumnOrderNumber.Name = "InPrColumnOrderNumber";
            this.InPrColumnOrderNumber.ReadOnly = true;
            // 
            // InPrColumnUserId
            // 
            this.InPrColumnUserId.DataPropertyName = "UserId";
            this.InPrColumnUserId.HeaderText = "UserId";
            this.InPrColumnUserId.Name = "InPrColumnUserId";
            this.InPrColumnUserId.Visible = false;
            // 
            // InPrColumnUserFIO
            // 
            this.InPrColumnUserFIO.HeaderText = "ФИО покупателя";
            this.InPrColumnUserFIO.Name = "InPrColumnUserFIO";
            this.InPrColumnUserFIO.ReadOnly = true;
            // 
            // InPrColumnUserPhone
            // 
            this.InPrColumnUserPhone.HeaderText = "Номер покупателя";
            this.InPrColumnUserPhone.Name = "InPrColumnUserPhone";
            this.InPrColumnUserPhone.ReadOnly = true;
            // 
            // InPrColumnCourierId
            // 
            this.InPrColumnCourierId.DataPropertyName = "CourierId";
            this.InPrColumnCourierId.HeaderText = "CourierId";
            this.InPrColumnCourierId.Name = "InPrColumnCourierId";
            this.InPrColumnCourierId.Visible = false;
            // 
            // InPrColumnCourier
            // 
            this.InPrColumnCourier.HeaderText = "Курьер";
            this.InPrColumnCourier.Name = "InPrColumnCourier";
            this.InPrColumnCourier.ReadOnly = true;
            // 
            // InPrColumnAddressId
            // 
            this.InPrColumnAddressId.DataPropertyName = "AddressId";
            this.InPrColumnAddressId.HeaderText = "AddressId";
            this.InPrColumnAddressId.Name = "InPrColumnAddressId";
            this.InPrColumnAddressId.Visible = false;
            // 
            // InPrColumnAddress
            // 
            this.InPrColumnAddress.HeaderText = "Адрес";
            this.InPrColumnAddress.Name = "InPrColumnAddress";
            this.InPrColumnAddress.ReadOnly = true;
            // 
            // InPrColumnPaymentMethodId
            // 
            this.InPrColumnPaymentMethodId.DataPropertyName = "PaymentMethod";
            this.InPrColumnPaymentMethodId.HeaderText = "PaymentMethod";
            this.InPrColumnPaymentMethodId.Name = "InPrColumnPaymentMethodId";
            this.InPrColumnPaymentMethodId.Visible = false;
            // 
            // InPrColumnPaymentMethod
            // 
            this.InPrColumnPaymentMethod.HeaderText = "Способ оплаты";
            this.InPrColumnPaymentMethod.Name = "InPrColumnPaymentMethod";
            this.InPrColumnPaymentMethod.ReadOnly = true;
            // 
            // InPrColumnDeliveryPrice
            // 
            this.InPrColumnDeliveryPrice.DataPropertyName = "DeliveryPrice";
            this.InPrColumnDeliveryPrice.HeaderText = "Стоимость доставки";
            this.InPrColumnDeliveryPrice.Name = "InPrColumnDeliveryPrice";
            this.InPrColumnDeliveryPrice.ReadOnly = true;
            // 
            // InPrColumnTotalCost
            // 
            this.InPrColumnTotalCost.DataPropertyName = "TotalCost";
            this.InPrColumnTotalCost.HeaderText = "Итого";
            this.InPrColumnTotalCost.Name = "InPrColumnTotalCost";
            this.InPrColumnTotalCost.ReadOnly = true;
            // 
            // InPrColumnDeliveryDate
            // 
            this.InPrColumnDeliveryDate.DataPropertyName = "DeliveryDate";
            this.InPrColumnDeliveryDate.HeaderText = "Дата доставки";
            this.InPrColumnDeliveryDate.Name = "InPrColumnDeliveryDate";
            // 
            // InPrColumnIsVerified
            // 
            this.InPrColumnIsVerified.DataPropertyName = "Verified";
            this.InPrColumnIsVerified.HeaderText = "Подтвержден";
            this.InPrColumnIsVerified.Name = "InPrColumnIsVerified";
            this.InPrColumnIsVerified.ReadOnly = true;
            // 
            // InPrColumnStatusId
            // 
            this.InPrColumnStatusId.DataPropertyName = "OrderStatus";
            this.InPrColumnStatusId.HeaderText = "OrderStatus";
            this.InPrColumnStatusId.Name = "InPrColumnStatusId";
            this.InPrColumnStatusId.Visible = false;
            // 
            // InPrColumnStatus
            // 
            this.InPrColumnStatus.HeaderText = "Статус";
            this.InPrColumnStatus.Name = "InPrColumnStatus";
            this.InPrColumnStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InPrColumnStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CourierWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(984, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlCourier);
            this.Name = "CourierWindow";
            this.Text = "CourierWindow";
            this.tabControlCourier.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.tabPageCDeliveries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCourier;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.TabPage tabPageCDeliveries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLogOut;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.Button buttonSubmitChanges;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource orderBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCourierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCourier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddressId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPaymentMethodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTakeOrderToDeliver;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnUserFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnUserPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnCourierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnCourier;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnAddressId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnPaymentMethodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnDeliveryPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnDeliveryDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn InPrColumnIsVerified;
        private System.Windows.Forms.DataGridViewTextBoxColumn InPrColumnStatusId;
        private System.Windows.Forms.DataGridViewComboBoxColumn InPrColumnStatus;
    }
}