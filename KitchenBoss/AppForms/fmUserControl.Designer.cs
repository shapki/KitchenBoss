namespace KitchenBoss.AppForms
{
    partial class fmUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmUserControl));
            this.headerSubtitleLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerLogoBackPanel = new System.Windows.Forms.Panel();
            this.headerLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.usersDgv = new System.Windows.Forms.DataGridView();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.headerPanel.SuspendLayout();
            this.headerLogoBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // headerSubtitleLabel
            // 
            this.headerSubtitleLabel.AutoSize = true;
            this.headerSubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerSubtitleLabel.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 15F);
            this.headerSubtitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.headerSubtitleLabel.Location = new System.Drawing.Point(66, 35);
            this.headerSubtitleLabel.Name = "headerSubtitleLabel";
            this.headerSubtitleLabel.Size = new System.Drawing.Size(241, 25);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Управление пользователями";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.IndianRed;
            this.headerPanel.Controls.Add(this.headerTitleLabel);
            this.headerPanel.Controls.Add(this.headerSubtitleLabel);
            this.headerPanel.Controls.Add(this.headerLogoBackPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(481, 60);
            this.headerPanel.TabIndex = 12;
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.AutoSize = true;
            this.headerTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerTitleLabel.Font = new System.Drawing.Font("Franklin Gothic Heavy", 20F);
            this.headerTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.headerTitleLabel.Location = new System.Drawing.Point(66, 4);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(200, 34);
            this.headerTitleLabel.TabIndex = 4;
            this.headerTitleLabel.Text = "KITCHEN BOSS\r\n";
            // 
            // headerLogoBackPanel
            // 
            this.headerLogoBackPanel.BackColor = System.Drawing.Color.Orange;
            this.headerLogoBackPanel.Controls.Add(this.headerLogoPictureBox);
            this.headerLogoBackPanel.Location = new System.Drawing.Point(0, 0);
            this.headerLogoBackPanel.Name = "headerLogoBackPanel";
            this.headerLogoBackPanel.Size = new System.Drawing.Size(60, 60);
            this.headerLogoBackPanel.TabIndex = 1;
            // 
            // headerLogoPictureBox
            // 
            this.headerLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("headerLogoPictureBox.Image")));
            this.headerLogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.headerLogoPictureBox.Name = "headerLogoPictureBox";
            this.headerLogoPictureBox.Size = new System.Drawing.Size(60, 60);
            this.headerLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.headerLogoPictureBox.TabIndex = 0;
            this.headerLogoPictureBox.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveButton.Enabled = false;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.saveButton.FlatAppearance.BorderSize = 2;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.saveButton.Image = global::KitchenBoss.Properties.Resources.regular_save_x20;
            this.saveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveButton.Location = new System.Drawing.Point(370, 352);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 28);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Сохранить";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // usersDgv
            // 
            this.usersDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username,
            this.password,
            this.employee,
            this.position});
            this.usersDgv.Location = new System.Drawing.Point(12, 66);
            this.usersDgv.Name = "usersDgv";
            this.usersDgv.Size = new System.Drawing.Size(457, 280);
            this.usersDgv.TabIndex = 16;
            this.usersDgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.usersDgv_CellBeginEdit);
            this.usersDgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersDgv_CellValueChanged);
            this.usersDgv.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.usersDgv_UserAddedRow);
            this.usersDgv.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.usersDgv_UserDeletedRow);
            // 
            // username
            // 
            this.username.HeaderText = "Логин";
            this.username.Name = "username";
            // 
            // password
            // 
            this.password.HeaderText = "Пароль";
            this.password.Name = "password";
            // 
            // employee
            // 
            this.employee.HeaderText = "ФИО сотрудника";
            this.employee.Name = "employee";
            this.employee.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.employee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // position
            // 
            this.position.HeaderText = "Доступ";
            this.position.Name = "position";
            this.position.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fmUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 392);
            this.Controls.Add(this.usersDgv);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.Name = "fmUserControl";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KitchenBoss - Управление пользователями";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView usersDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewComboBoxColumn employee;
        private System.Windows.Forms.DataGridViewComboBoxColumn position;
    }
}