namespace KitchenBoss.AppForms
{
    partial class fmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.headerSubtitleLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerLogoBackPanel = new System.Windows.Forms.Panel();
            this.headerLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.loginAndPositionLabel = new System.Windows.Forms.Label();
            this.employeesButton = new System.Windows.Forms.Button();
            this.dishesButton = new System.Windows.Forms.Button();
            this.clientsButton = new System.Windows.Forms.Button();
            this.userControlButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.headerLogoBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
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
            this.headerSubtitleLabel.Size = new System.Drawing.Size(138, 25);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Главная панель";
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
            this.headerPanel.Size = new System.Drawing.Size(354, 60);
            this.headerPanel.TabIndex = 1;
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
            // loginAndPositionLabel
            // 
            this.loginAndPositionLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginAndPositionLabel.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.loginAndPositionLabel.Location = new System.Drawing.Point(12, 165);
            this.loginAndPositionLabel.Name = "loginAndPositionLabel";
            this.loginAndPositionLabel.Size = new System.Drawing.Size(194, 38);
            this.loginAndPositionLabel.TabIndex = 4;
            this.loginAndPositionLabel.Text = "ФИО: ???\r\nДоступ: ???";
            this.loginAndPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeesButton
            // 
            this.employeesButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.employeesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.employeesButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.employeesButton.FlatAppearance.BorderSize = 2;
            this.employeesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.employeesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeesButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 20F);
            this.employeesButton.Image = global::KitchenBoss.Properties.Resources.regular_employee_x30;
            this.employeesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesButton.Location = new System.Drawing.Point(164, 66);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Size = new System.Drawing.Size(178, 45);
            this.employeesButton.TabIndex = 14;
            this.employeesButton.Text = "Сотрудники";
            this.employeesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.employeesButton.UseVisualStyleBackColor = false;
            // 
            // dishesButton
            // 
            this.dishesButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dishesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dishesButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.dishesButton.FlatAppearance.BorderSize = 2;
            this.dishesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.dishesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dishesButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 20F);
            this.dishesButton.Image = global::KitchenBoss.Properties.Resources.regular_dishes_x30;
            this.dishesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dishesButton.Location = new System.Drawing.Point(12, 117);
            this.dishesButton.Name = "dishesButton";
            this.dishesButton.Size = new System.Drawing.Size(127, 45);
            this.dishesButton.TabIndex = 15;
            this.dishesButton.Text = "Блюда";
            this.dishesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dishesButton.UseVisualStyleBackColor = false;
            // 
            // clientsButton
            // 
            this.clientsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clientsButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.clientsButton.FlatAppearance.BorderSize = 2;
            this.clientsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.clientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientsButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 20F);
            this.clientsButton.Image = global::KitchenBoss.Properties.Resources.regular_clients_x30;
            this.clientsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsButton.Location = new System.Drawing.Point(12, 66);
            this.clientsButton.Name = "clientsButton";
            this.clientsButton.Size = new System.Drawing.Size(146, 45);
            this.clientsButton.TabIndex = 17;
            this.clientsButton.Text = "Клиенты";
            this.clientsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clientsButton.UseVisualStyleBackColor = false;
            // 
            // userControlButton
            // 
            this.userControlButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.userControlButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.userControlButton.Enabled = false;
            this.userControlButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.userControlButton.FlatAppearance.BorderSize = 2;
            this.userControlButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.userControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userControlButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 20F);
            this.userControlButton.Image = global::KitchenBoss.Properties.Resources.regular_control_panel_x30;
            this.userControlButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userControlButton.Location = new System.Drawing.Point(145, 117);
            this.userControlButton.Name = "userControlButton";
            this.userControlButton.Size = new System.Drawing.Size(197, 45);
            this.userControlButton.TabIndex = 21;
            this.userControlButton.Text = "Управ. Польз";
            this.userControlButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userControlButton.UseVisualStyleBackColor = false;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.logoutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.logoutButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.logoutButton.FlatAppearance.BorderSize = 2;
            this.logoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.logoutButton.Image = global::KitchenBoss.Properties.Resources.regular_logout_x20;
            this.logoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.Location = new System.Drawing.Point(265, 175);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(77, 28);
            this.logoutButton.TabIndex = 22;
            this.logoutButton.Text = "Выйти";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 209);
            this.Controls.Add(this.loginAndPositionLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.userControlButton);
            this.Controls.Add(this.clientsButton);
            this.Controls.Add(this.dishesButton);
            this.Controls.Add(this.employeesButton);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KitchenBoss - Главная панель";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
        private System.Windows.Forms.Label loginAndPositionLabel;
        private System.Windows.Forms.Button employeesButton;
        private System.Windows.Forms.Button dishesButton;
        private System.Windows.Forms.Button clientsButton;
        private System.Windows.Forms.Button userControlButton;
        private System.Windows.Forms.Button logoutButton;
    }
}