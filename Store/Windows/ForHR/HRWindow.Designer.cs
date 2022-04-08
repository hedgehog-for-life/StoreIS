
namespace Store.Windows.ForHR
{
    partial class HRWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewCurrApps = new System.Windows.Forms.DataGridView();
            this.ColumnAppId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnApplicantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnApplicantFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnApplicantBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hrIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResumeIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnSeniority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTake = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.employmentAppBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewHrApps = new System.Windows.Forms.DataGridView();
            this.FactColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactColumnApplicantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactColumnApplicantFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactColumnApplicantDateBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactColumnApplicantPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactColumnApplicantEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hrIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactColumnResumeIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.FactColumnApplicantSeniority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactColumnAppStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.employmentAppBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxLogOut = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.saveResumeFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrApps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employmentAppBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHrApps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employmentAppBindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(450, 19);
            this.tabControl1.Location = new System.Drawing.Point(12, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(909, 396);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.tabPage1.Controls.Add(this.dataGridViewCurrApps);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(901, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Текущие заявки";
            // 
            // dataGridViewCurrApps
            // 
            this.dataGridViewCurrApps.AllowUserToAddRows = false;
            this.dataGridViewCurrApps.AutoGenerateColumns = false;
            this.dataGridViewCurrApps.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.dataGridViewCurrApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrApps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAppId,
            this.ColumnApplicantId,
            this.ColumnApplicantFIO,
            this.ColumnApplicantBirthDate,
            this.hrIdDataGridViewTextBoxColumn,
            this.ColumnResumeIcon,
            this.ColumnSeniority,
            this.ColumnTake});
            this.dataGridViewCurrApps.DataSource = this.employmentAppBindingSource;
            this.dataGridViewCurrApps.Location = new System.Drawing.Point(16, 16);
            this.dataGridViewCurrApps.Name = "dataGridViewCurrApps";
            this.dataGridViewCurrApps.Size = new System.Drawing.Size(655, 329);
            this.dataGridViewCurrApps.TabIndex = 0;
            this.dataGridViewCurrApps.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCurrApps_CellEndEdit);
            this.dataGridViewCurrApps.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCurrApps_CellFormatting);
            // 
            // ColumnAppId
            // 
            this.ColumnAppId.DataPropertyName = "Id";
            this.ColumnAppId.HeaderText = "Id";
            this.ColumnAppId.Name = "ColumnAppId";
            this.ColumnAppId.Visible = false;
            // 
            // ColumnApplicantId
            // 
            this.ColumnApplicantId.DataPropertyName = "ApplicantId";
            this.ColumnApplicantId.HeaderText = "ApplicantId";
            this.ColumnApplicantId.Name = "ColumnApplicantId";
            this.ColumnApplicantId.Visible = false;
            // 
            // ColumnApplicantFIO
            // 
            this.ColumnApplicantFIO.HeaderText = "ФИО пользователя";
            this.ColumnApplicantFIO.Name = "ColumnApplicantFIO";
            this.ColumnApplicantFIO.ReadOnly = true;
            this.ColumnApplicantFIO.Width = 200;
            // 
            // ColumnApplicantBirthDate
            // 
            this.ColumnApplicantBirthDate.HeaderText = "Дата рождения пользователя";
            this.ColumnApplicantBirthDate.Name = "ColumnApplicantBirthDate";
            this.ColumnApplicantBirthDate.ReadOnly = true;
            this.ColumnApplicantBirthDate.Width = 110;
            // 
            // hrIdDataGridViewTextBoxColumn
            // 
            this.hrIdDataGridViewTextBoxColumn.DataPropertyName = "HrId";
            this.hrIdDataGridViewTextBoxColumn.HeaderText = "HrId";
            this.hrIdDataGridViewTextBoxColumn.Name = "hrIdDataGridViewTextBoxColumn";
            this.hrIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // ColumnResumeIcon
            // 
            this.ColumnResumeIcon.HeaderText = "Резюме";
            this.ColumnResumeIcon.Image = global::Store.Properties.Resources.pdf;
            this.ColumnResumeIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnResumeIcon.Name = "ColumnResumeIcon";
            this.ColumnResumeIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnResumeIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnSeniority
            // 
            this.ColumnSeniority.DataPropertyName = "Seniority";
            this.ColumnSeniority.HeaderText = "Стаж работы";
            this.ColumnSeniority.Name = "ColumnSeniority";
            this.ColumnSeniority.ReadOnly = true;
            // 
            // ColumnTake
            // 
            this.ColumnTake.HeaderText = "Взять на рассмотрение";
            this.ColumnTake.Name = "ColumnTake";
            // 
            // employmentAppBindingSource
            // 
            this.employmentAppBindingSource.DataSource = typeof(Store.DataBase.Entities.EmploymentApp);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.tabPage2.Controls.Add(this.dataGridViewHrApps);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(901, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "В моем ведомстве";
            // 
            // dataGridViewHrApps
            // 
            this.dataGridViewHrApps.AllowUserToAddRows = false;
            this.dataGridViewHrApps.AutoGenerateColumns = false;
            this.dataGridViewHrApps.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.dataGridViewHrApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHrApps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FactColumnId,
            this.FactColumnApplicantId,
            this.FactColumnApplicantFIO,
            this.FactColumnApplicantDateBirth,
            this.FactColumnApplicantPhone,
            this.FactColumnApplicantEmail,
            this.hrIdDataGridViewTextBoxColumn1,
            this.FactColumnResumeIcon,
            this.FactColumnApplicantSeniority,
            this.appStatusDataGridViewTextBoxColumn,
            this.FactColumnAppStatus});
            this.dataGridViewHrApps.DataSource = this.employmentAppBindingSource1;
            this.dataGridViewHrApps.Location = new System.Drawing.Point(16, 16);
            this.dataGridViewHrApps.Name = "dataGridViewHrApps";
            this.dataGridViewHrApps.Size = new System.Drawing.Size(867, 336);
            this.dataGridViewHrApps.TabIndex = 0;
            this.dataGridViewHrApps.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHrApps_CellDoubleClick);
            this.dataGridViewHrApps.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHrApps_CellEndEdit);
            this.dataGridViewHrApps.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewHrApps_CellFormatting);
            this.dataGridViewHrApps.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewHrApps_UserDeletingRow);
            // 
            // FactColumnId
            // 
            this.FactColumnId.DataPropertyName = "Id";
            this.FactColumnId.HeaderText = "Id";
            this.FactColumnId.Name = "FactColumnId";
            this.FactColumnId.Visible = false;
            // 
            // FactColumnApplicantId
            // 
            this.FactColumnApplicantId.DataPropertyName = "ApplicantId";
            this.FactColumnApplicantId.HeaderText = "ApplicantId";
            this.FactColumnApplicantId.Name = "FactColumnApplicantId";
            this.FactColumnApplicantId.Visible = false;
            // 
            // FactColumnApplicantFIO
            // 
            this.FactColumnApplicantFIO.HeaderText = "ФИО пользователя";
            this.FactColumnApplicantFIO.Name = "FactColumnApplicantFIO";
            this.FactColumnApplicantFIO.ReadOnly = true;
            this.FactColumnApplicantFIO.Width = 200;
            // 
            // FactColumnApplicantDateBirth
            // 
            this.FactColumnApplicantDateBirth.HeaderText = "Дата рождения пользователя";
            this.FactColumnApplicantDateBirth.Name = "FactColumnApplicantDateBirth";
            this.FactColumnApplicantDateBirth.ReadOnly = true;
            // 
            // FactColumnApplicantPhone
            // 
            this.FactColumnApplicantPhone.HeaderText = "Телефон пользователя";
            this.FactColumnApplicantPhone.Name = "FactColumnApplicantPhone";
            this.FactColumnApplicantPhone.ReadOnly = true;
            // 
            // FactColumnApplicantEmail
            // 
            this.FactColumnApplicantEmail.HeaderText = "Адрес почты пользователя";
            this.FactColumnApplicantEmail.Name = "FactColumnApplicantEmail";
            this.FactColumnApplicantEmail.ReadOnly = true;
            this.FactColumnApplicantEmail.Width = 120;
            // 
            // hrIdDataGridViewTextBoxColumn1
            // 
            this.hrIdDataGridViewTextBoxColumn1.DataPropertyName = "HrId";
            this.hrIdDataGridViewTextBoxColumn1.HeaderText = "HrId";
            this.hrIdDataGridViewTextBoxColumn1.Name = "hrIdDataGridViewTextBoxColumn1";
            this.hrIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // FactColumnResumeIcon
            // 
            this.FactColumnResumeIcon.HeaderText = "Резюме";
            this.FactColumnResumeIcon.Image = global::Store.Properties.Resources.pdf;
            this.FactColumnResumeIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.FactColumnResumeIcon.Name = "FactColumnResumeIcon";
            // 
            // FactColumnApplicantSeniority
            // 
            this.FactColumnApplicantSeniority.DataPropertyName = "Seniority";
            this.FactColumnApplicantSeniority.HeaderText = "Стаж работы пользователя";
            this.FactColumnApplicantSeniority.Name = "FactColumnApplicantSeniority";
            this.FactColumnApplicantSeniority.ReadOnly = true;
            // 
            // appStatusDataGridViewTextBoxColumn
            // 
            this.appStatusDataGridViewTextBoxColumn.DataPropertyName = "AppStatus";
            this.appStatusDataGridViewTextBoxColumn.HeaderText = "AppStatus";
            this.appStatusDataGridViewTextBoxColumn.Name = "appStatusDataGridViewTextBoxColumn";
            this.appStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // FactColumnAppStatus
            // 
            this.FactColumnAppStatus.HeaderText = "Статус заявки";
            this.FactColumnAppStatus.Name = "FactColumnAppStatus";
            // 
            // employmentAppBindingSource1
            // 
            this.employmentAppBindingSource1.DataSource = typeof(Store.DataBase.Entities.EmploymentApp);
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
            this.panel1.Size = new System.Drawing.Size(939, 63);
            this.panel1.TabIndex = 4;
            // 
            // pictureBoxLogOut
            // 
            this.pictureBoxLogOut.Image = global::Store.Properties.Resources.logout;
            this.pictureBoxLogOut.Location = new System.Drawing.Point(850, 15);
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
            this.pictureBoxExit.Location = new System.Drawing.Point(893, 15);
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
            this.pictureBoxIcon.Location = new System.Drawing.Point(362, 9);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(216, 47);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // HRWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(937, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Cambria", 9F);
            this.Name = "HRWindow";
            this.Text = "HRWindow";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrApps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employmentAppBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHrApps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employmentAppBindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLogOut;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.DataGridView dataGridViewCurrApps;
        private System.Windows.Forms.BindingSource employmentAppBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewHrApps;
        private System.Windows.Forms.BindingSource employmentAppBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAppId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnApplicantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnApplicantFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnApplicantBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn hrIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn ColumnResumeIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSeniority;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTake;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactColumnApplicantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactColumnApplicantFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactColumnApplicantDateBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactColumnApplicantPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactColumnApplicantEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn hrIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn FactColumnResumeIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactColumnApplicantSeniority;
        private System.Windows.Forms.DataGridViewTextBoxColumn appStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn FactColumnAppStatus;
        private System.Windows.Forms.SaveFileDialog saveResumeFileDialog;
    }
}