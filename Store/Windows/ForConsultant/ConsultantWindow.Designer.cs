
namespace Store.Windows.ForConsultant
{
    partial class ConsultantWindow
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
            this.pictureBoxLogOut = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.tabPageThemes = new System.Windows.Forms.TabPage();
            this.dataGridViewQThemes = new System.Windows.Forms.DataGridView();
            this.tabPageConsultants = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddToSC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuestionId = new System.Windows.Forms.TextBox();
            this.dataGridViewConsultantQuestions = new System.Windows.Forms.DataGridView();
            this.InfoColumnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoColumnTheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageUnanswered = new System.Windows.Forms.TabPage();
            this.dataGridViewQuestions = new System.Windows.Forms.DataGridView();
            this.ColumnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTheme = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnConsultant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuestionStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabControlQuestions = new System.Windows.Forms.TabControl();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQPublishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConsultantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAnswerPublishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuestionStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InfoColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoColumnUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoColumnThemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publishQDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publishADateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnQThemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThemeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThemeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qThemeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.tabPageThemes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQThemes)).BeginInit();
            this.tabPageConsultants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultantQuestions)).BeginInit();
            this.tabPageUnanswered.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).BeginInit();
            this.tabControlQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qThemeBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1128, 63);
            this.panel1.TabIndex = 3;
            // 
            // pictureBoxLogOut
            // 
            this.pictureBoxLogOut.Image = global::Store.Properties.Resources.logout;
            this.pictureBoxLogOut.Location = new System.Drawing.Point(1040, 19);
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
            this.pictureBoxExit.Location = new System.Drawing.Point(1083, 19);
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
            // tabPageThemes
            // 
            this.tabPageThemes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.tabPageThemes.Controls.Add(this.dataGridViewQThemes);
            this.tabPageThemes.Location = new System.Drawing.Point(4, 23);
            this.tabPageThemes.Name = "tabPageThemes";
            this.tabPageThemes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThemes.Size = new System.Drawing.Size(1120, 394);
            this.tabPageThemes.TabIndex = 2;
            this.tabPageThemes.Text = "Управление тематикой вопросов";
            // 
            // dataGridViewQThemes
            // 
            this.dataGridViewQThemes.AutoGenerateColumns = false;
            this.dataGridViewQThemes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.dataGridViewQThemes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQThemes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnQThemeId,
            this.ColumnThemeName,
            this.ColumnThemeDesc});
            this.dataGridViewQThemes.DataSource = this.qThemeBindingSource;
            this.dataGridViewQThemes.Location = new System.Drawing.Point(16, 22);
            this.dataGridViewQThemes.Name = "dataGridViewQThemes";
            this.dataGridViewQThemes.Size = new System.Drawing.Size(545, 349);
            this.dataGridViewQThemes.TabIndex = 0;
            this.dataGridViewQThemes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewQThemes_CellEndEdit);
            this.dataGridViewQThemes.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewQThemes_CellValidated);
            this.dataGridViewQThemes.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewQThemes_CellValidating);
            this.dataGridViewQThemes.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewQThemes_RowValidated);
            this.dataGridViewQThemes.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewQThemes_RowValidating);
            this.dataGridViewQThemes.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewQThemes_UserAddedRow);
            this.dataGridViewQThemes.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewQThemes_UserDeletedRow);
            this.dataGridViewQThemes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewQThemes_UserDeletingRow);
            // 
            // tabPageConsultants
            // 
            this.tabPageConsultants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.tabPageConsultants.Controls.Add(this.label2);
            this.tabPageConsultants.Controls.Add(this.buttonAddToSC);
            this.tabPageConsultants.Controls.Add(this.label1);
            this.tabPageConsultants.Controls.Add(this.textBoxQuestionId);
            this.tabPageConsultants.Controls.Add(this.dataGridViewConsultantQuestions);
            this.tabPageConsultants.Location = new System.Drawing.Point(4, 23);
            this.tabPageConsultants.Name = "tabPageConsultants";
            this.tabPageConsultants.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConsultants.Size = new System.Drawing.Size(1120, 394);
            this.tabPageConsultants.TabIndex = 1;
            this.tabPageConsultants.Text = "Мои ответы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 107;
            this.label2.Text = "Введите id вопроса";
            // 
            // buttonAddToSC
            // 
            this.buttonAddToSC.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonAddToSC.Font = new System.Drawing.Font("Cambria", 9F);
            this.buttonAddToSC.Location = new System.Drawing.Point(121, 11);
            this.buttonAddToSC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddToSC.Name = "buttonAddToSC";
            this.buttonAddToSC.Size = new System.Drawing.Size(47, 29);
            this.buttonAddToSC.TabIndex = 106;
            this.buttonAddToSC.Text = "Ок";
            this.buttonAddToSC.UseVisualStyleBackColor = false;
            this.buttonAddToSC.Click += new System.EventHandler(this.buttonAddToSC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Просмотреть личные данные автора вопроса";
            // 
            // textBoxQuestionId
            // 
            this.textBoxQuestionId.Location = new System.Drawing.Point(16, 15);
            this.textBoxQuestionId.Name = "textBoxQuestionId";
            this.textBoxQuestionId.Size = new System.Drawing.Size(100, 22);
            this.textBoxQuestionId.TabIndex = 1;
            // 
            // dataGridViewConsultantQuestions
            // 
            this.dataGridViewConsultantQuestions.AllowUserToAddRows = false;
            this.dataGridViewConsultantQuestions.AutoGenerateColumns = false;
            this.dataGridViewConsultantQuestions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.dataGridViewConsultantQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsultantQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InfoColumnId,
            this.InfoColumnUserId,
            this.InfoColumnUser,
            this.InfoColumnThemeId,
            this.InfoColumnTheme,
            this.qTextDataGridViewTextBoxColumn,
            this.publishQDateDataGridViewTextBoxColumn,
            this.aTextDataGridViewTextBoxColumn,
            this.publishADateDataGridViewTextBoxColumn});
            this.dataGridViewConsultantQuestions.DataSource = this.questionBindingSource1;
            this.dataGridViewConsultantQuestions.Location = new System.Drawing.Point(16, 75);
            this.dataGridViewConsultantQuestions.Name = "dataGridViewConsultantQuestions";
            this.dataGridViewConsultantQuestions.ReadOnly = true;
            this.dataGridViewConsultantQuestions.Size = new System.Drawing.Size(1088, 301);
            this.dataGridViewConsultantQuestions.TabIndex = 0;
            this.dataGridViewConsultantQuestions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewConsultantQuestions_CellFormatting);
            this.dataGridViewConsultantQuestions.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewConsultantQuestions_UserDeletingRow);
            // 
            // InfoColumnUser
            // 
            this.InfoColumnUser.HeaderText = "Пользователь";
            this.InfoColumnUser.Name = "InfoColumnUser";
            this.InfoColumnUser.ReadOnly = true;
            // 
            // InfoColumnTheme
            // 
            this.InfoColumnTheme.HeaderText = "Тема";
            this.InfoColumnTheme.Name = "InfoColumnTheme";
            this.InfoColumnTheme.ReadOnly = true;
            // 
            // tabPageUnanswered
            // 
            this.tabPageUnanswered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.tabPageUnanswered.Controls.Add(this.dataGridViewQuestions);
            this.tabPageUnanswered.Location = new System.Drawing.Point(4, 23);
            this.tabPageUnanswered.Name = "tabPageUnanswered";
            this.tabPageUnanswered.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUnanswered.Size = new System.Drawing.Size(1120, 394);
            this.tabPageUnanswered.TabIndex = 0;
            this.tabPageUnanswered.Text = "Вопросы";
            // 
            // dataGridViewQuestions
            // 
            this.dataGridViewQuestions.AllowUserToAddRows = false;
            this.dataGridViewQuestions.AutoGenerateColumns = false;
            this.dataGridViewQuestions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(131)))));
            this.dataGridViewQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnUserId,
            this.ColumnUser,
            this.ColumnThemeId,
            this.ColumnTheme,
            this.ColumnQText,
            this.ColumnQPublishDate,
            this.ColumnConsultantId,
            this.ColumnConsultant,
            this.ColumnAText,
            this.ColumnAnswerPublishDate,
            this.ColumnQuestionStatusId,
            this.ColumnQuestionStatus});
            this.dataGridViewQuestions.DataSource = this.questionBindingSource;
            this.dataGridViewQuestions.Location = new System.Drawing.Point(20, 19);
            this.dataGridViewQuestions.Name = "dataGridViewQuestions";
            this.dataGridViewQuestions.Size = new System.Drawing.Size(1076, 354);
            this.dataGridViewQuestions.TabIndex = 0;
            this.dataGridViewQuestions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewQuestions_CellBeginEdit);
            this.dataGridViewQuestions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewQuestions_CellEndEdit);
            this.dataGridViewQuestions.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewQuestions_CellEnter);
            this.dataGridViewQuestions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewQuestions_CellFormatting);
            this.dataGridViewQuestions.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewQuestions_UserDeletingRow);
            // 
            // ColumnUser
            // 
            this.ColumnUser.HeaderText = "Пользователь";
            this.ColumnUser.Name = "ColumnUser";
            this.ColumnUser.ReadOnly = true;
            // 
            // ColumnTheme
            // 
            this.ColumnTheme.HeaderText = "Тема";
            this.ColumnTheme.Name = "ColumnTheme";
            this.ColumnTheme.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTheme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnConsultant
            // 
            this.ColumnConsultant.HeaderText = "Консультант";
            this.ColumnConsultant.Name = "ColumnConsultant";
            this.ColumnConsultant.ReadOnly = true;
            // 
            // ColumnQuestionStatus
            // 
            this.ColumnQuestionStatus.HeaderText = "Статус";
            this.ColumnQuestionStatus.Name = "ColumnQuestionStatus";
            this.ColumnQuestionStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnQuestionStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabControlQuestions
            // 
            this.tabControlQuestions.Controls.Add(this.tabPageUnanswered);
            this.tabControlQuestions.Controls.Add(this.tabPageConsultants);
            this.tabControlQuestions.Controls.Add(this.tabPageThemes);
            this.tabControlQuestions.Font = new System.Drawing.Font("Cambria", 9F);
            this.tabControlQuestions.ItemSize = new System.Drawing.Size(375, 19);
            this.tabControlQuestions.Location = new System.Drawing.Point(0, 68);
            this.tabControlQuestions.Name = "tabControlQuestions";
            this.tabControlQuestions.SelectedIndex = 0;
            this.tabControlQuestions.Size = new System.Drawing.Size(1128, 421);
            this.tabControlQuestions.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlQuestions.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnUserId
            // 
            this.ColumnUserId.DataPropertyName = "UserId";
            this.ColumnUserId.HeaderText = "UserId";
            this.ColumnUserId.Name = "ColumnUserId";
            this.ColumnUserId.Visible = false;
            // 
            // ColumnThemeId
            // 
            this.ColumnThemeId.DataPropertyName = "ThemeId";
            this.ColumnThemeId.HeaderText = "ThemeId";
            this.ColumnThemeId.Name = "ColumnThemeId";
            this.ColumnThemeId.Visible = false;
            // 
            // ColumnQText
            // 
            this.ColumnQText.DataPropertyName = "QText";
            this.ColumnQText.HeaderText = "Вопрос";
            this.ColumnQText.Name = "ColumnQText";
            this.ColumnQText.ReadOnly = true;
            this.ColumnQText.Width = 350;
            // 
            // ColumnQPublishDate
            // 
            this.ColumnQPublishDate.DataPropertyName = "PublishQDate";
            this.ColumnQPublishDate.HeaderText = "Дата публикации вопроса";
            this.ColumnQPublishDate.Name = "ColumnQPublishDate";
            this.ColumnQPublishDate.ReadOnly = true;
            this.ColumnQPublishDate.Width = 90;
            // 
            // ColumnConsultantId
            // 
            this.ColumnConsultantId.DataPropertyName = "ConsultantId";
            this.ColumnConsultantId.HeaderText = "ConsultantId";
            this.ColumnConsultantId.Name = "ColumnConsultantId";
            this.ColumnConsultantId.Visible = false;
            // 
            // ColumnAText
            // 
            this.ColumnAText.DataPropertyName = "AText";
            this.ColumnAText.HeaderText = "Ответ";
            this.ColumnAText.Name = "ColumnAText";
            this.ColumnAText.Width = 350;
            // 
            // ColumnAnswerPublishDate
            // 
            this.ColumnAnswerPublishDate.DataPropertyName = "PublishADate";
            this.ColumnAnswerPublishDate.HeaderText = "Дата публикации ответа";
            this.ColumnAnswerPublishDate.Name = "ColumnAnswerPublishDate";
            this.ColumnAnswerPublishDate.ReadOnly = true;
            this.ColumnAnswerPublishDate.Width = 90;
            // 
            // ColumnQuestionStatusId
            // 
            this.ColumnQuestionStatusId.DataPropertyName = "QStatus";
            this.ColumnQuestionStatusId.HeaderText = "QStatus";
            this.ColumnQuestionStatusId.Name = "ColumnQuestionStatusId";
            this.ColumnQuestionStatusId.Visible = false;
            // 
            // questionBindingSource
            // 
            this.questionBindingSource.DataSource = typeof(Store.DataBase.Entities.Question);
            // 
            // InfoColumnId
            // 
            this.InfoColumnId.DataPropertyName = "Id";
            this.InfoColumnId.HeaderText = "Id";
            this.InfoColumnId.Name = "InfoColumnId";
            this.InfoColumnId.ReadOnly = true;
            // 
            // InfoColumnUserId
            // 
            this.InfoColumnUserId.DataPropertyName = "UserId";
            this.InfoColumnUserId.HeaderText = "UserId";
            this.InfoColumnUserId.Name = "InfoColumnUserId";
            this.InfoColumnUserId.ReadOnly = true;
            this.InfoColumnUserId.Visible = false;
            // 
            // InfoColumnThemeId
            // 
            this.InfoColumnThemeId.DataPropertyName = "ThemeId";
            this.InfoColumnThemeId.HeaderText = "ThemeId";
            this.InfoColumnThemeId.Name = "InfoColumnThemeId";
            this.InfoColumnThemeId.ReadOnly = true;
            this.InfoColumnThemeId.Visible = false;
            // 
            // qTextDataGridViewTextBoxColumn
            // 
            this.qTextDataGridViewTextBoxColumn.DataPropertyName = "QText";
            this.qTextDataGridViewTextBoxColumn.HeaderText = "Вопрос";
            this.qTextDataGridViewTextBoxColumn.Name = "qTextDataGridViewTextBoxColumn";
            this.qTextDataGridViewTextBoxColumn.ReadOnly = true;
            this.qTextDataGridViewTextBoxColumn.Width = 350;
            // 
            // publishQDateDataGridViewTextBoxColumn
            // 
            this.publishQDateDataGridViewTextBoxColumn.DataPropertyName = "PublishQDate";
            this.publishQDateDataGridViewTextBoxColumn.HeaderText = "Дата публикации вопроса";
            this.publishQDateDataGridViewTextBoxColumn.Name = "publishQDateDataGridViewTextBoxColumn";
            this.publishQDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aTextDataGridViewTextBoxColumn
            // 
            this.aTextDataGridViewTextBoxColumn.DataPropertyName = "AText";
            this.aTextDataGridViewTextBoxColumn.HeaderText = "Ответ";
            this.aTextDataGridViewTextBoxColumn.Name = "aTextDataGridViewTextBoxColumn";
            this.aTextDataGridViewTextBoxColumn.ReadOnly = true;
            this.aTextDataGridViewTextBoxColumn.Width = 350;
            // 
            // publishADateDataGridViewTextBoxColumn
            // 
            this.publishADateDataGridViewTextBoxColumn.DataPropertyName = "PublishADate";
            this.publishADateDataGridViewTextBoxColumn.HeaderText = "Дата публикации ответа";
            this.publishADateDataGridViewTextBoxColumn.Name = "publishADateDataGridViewTextBoxColumn";
            this.publishADateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // questionBindingSource1
            // 
            this.questionBindingSource1.DataSource = typeof(Store.DataBase.Entities.Question);
            // 
            // ColumnQThemeId
            // 
            this.ColumnQThemeId.DataPropertyName = "Id";
            this.ColumnQThemeId.HeaderText = "Id";
            this.ColumnQThemeId.Name = "ColumnQThemeId";
            this.ColumnQThemeId.Visible = false;
            // 
            // ColumnThemeName
            // 
            this.ColumnThemeName.DataPropertyName = "ThemeName";
            this.ColumnThemeName.HeaderText = "Название темы";
            this.ColumnThemeName.Name = "ColumnThemeName";
            this.ColumnThemeName.Width = 200;
            // 
            // ColumnThemeDesc
            // 
            this.ColumnThemeDesc.DataPropertyName = "ThemeDescription";
            this.ColumnThemeDesc.HeaderText = "Описание темы";
            this.ColumnThemeDesc.Name = "ColumnThemeDesc";
            this.ColumnThemeDesc.Width = 300;
            // 
            // qThemeBindingSource
            // 
            this.qThemeBindingSource.DataSource = typeof(Store.DataBase.Entities.QTheme);
            // 
            // ConsultantWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1130, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlQuestions);
            this.Name = "ConsultantWindow";
            this.Text = "ConsultantWindow";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.tabPageThemes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQThemes)).EndInit();
            this.tabPageConsultants.ResumeLayout(false);
            this.tabPageConsultants.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultantQuestions)).EndInit();
            this.tabPageUnanswered.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).EndInit();
            this.tabControlQuestions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qThemeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLogOut;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.BindingSource questionBindingSource;
        private System.Windows.Forms.TabPage tabPageThemes;
        private System.Windows.Forms.TabPage tabPageConsultants;
        private System.Windows.Forms.TabPage tabPageUnanswered;
        private System.Windows.Forms.DataGridView dataGridViewQuestions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThemeId;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQPublishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConsultantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConsultant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAnswerPublishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuestionStatusId;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnQuestionStatus;
        private System.Windows.Forms.TabControl tabControlQuestions;
        private System.Windows.Forms.DataGridView dataGridViewConsultantQuestions;
        private System.Windows.Forms.BindingSource questionBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoColumnUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoColumnUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoColumnThemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoColumnTheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn publishQDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn publishADateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridViewQThemes;
        private System.Windows.Forms.BindingSource qThemeBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQuestionId;
        private System.Windows.Forms.Button buttonAddToSC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQThemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThemeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThemeDesc;
    }
}