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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerSubtitleLabel = new System.Windows.Forms.Label();
            this.headerLogoBackPanel = new System.Windows.Forms.Panel();
            this.headerLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.loginAndPositionLabel = new System.Windows.Forms.Label();
            this.employeesButton = new System.Windows.Forms.Button();
            this.dishesButton = new System.Windows.Forms.Button();
            this.clientsButton = new System.Windows.Forms.Button();
            this.userControlButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.ordersButton = new System.Windows.Forms.Button();
            this.tablesButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.headerLogoBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.headerPanel.Controls.Add(this.headerTitleLabel);
            this.headerPanel.Controls.Add(this.headerSubtitleLabel);
            this.headerPanel.Controls.Add(this.headerLogoBackPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(439, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.headerTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.headerTitleLabel.Location = new System.Drawing.Point(80, 10);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(177, 32);
            this.headerTitleLabel.TabIndex = 4;
            this.headerTitleLabel.Text = "KITCHEN BOSS";
            // 
            // headerSubtitleLabel
            // 
            this.headerSubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerSubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.headerSubtitleLabel.ForeColor = System.Drawing.Color.Silver;
            this.headerSubtitleLabel.Location = new System.Drawing.Point(82, 42);
            this.headerSubtitleLabel.Name = "headerSubtitleLabel";
            this.headerSubtitleLabel.Size = new System.Drawing.Size(107, 19);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Главная панель";
            // 
            // headerLogoBackPanel
            // 
            this.headerLogoBackPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.headerLogoBackPanel.Controls.Add(this.headerLogoPictureBox);
            this.headerLogoBackPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.headerLogoBackPanel.Location = new System.Drawing.Point(0, 0);
            this.headerLogoBackPanel.Name = "headerLogoBackPanel";
            this.headerLogoBackPanel.Size = new System.Drawing.Size(70, 70);
            this.headerLogoBackPanel.TabIndex = 1;
            // 
            // headerLogoPictureBox
            // 
            this.headerLogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("headerLogoPictureBox.Image")));
            this.headerLogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.headerLogoPictureBox.Name = "headerLogoPictureBox";
            this.headerLogoPictureBox.Padding = new System.Windows.Forms.Padding(10);
            this.headerLogoPictureBox.Size = new System.Drawing.Size(70, 70);
            this.headerLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.headerLogoPictureBox.TabIndex = 0;
            this.headerLogoPictureBox.TabStop = false;
            // 
            // loginAndPositionLabel
            // 
            this.loginAndPositionLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginAndPositionLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.loginAndPositionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.loginAndPositionLabel.Location = new System.Drawing.Point(3, 130);
            this.loginAndPositionLabel.Name = "loginAndPositionLabel";
            this.loginAndPositionLabel.Size = new System.Drawing.Size(200, 40);
            this.loginAndPositionLabel.TabIndex = 4;
            this.loginAndPositionLabel.Text = "ФИО: ???\r\nДолжность: ???";
            this.loginAndPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeesButton
            // 
            this.employeesButton.BackColor = System.Drawing.Color.White;
            this.employeesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.employeesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.employeesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.employeesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.employeesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.employeesButton.Image = global::KitchenBoss.Properties.Resources.regular_employee_x30;
            this.employeesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesButton.Location = new System.Drawing.Point(261, 15);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.employeesButton.Size = new System.Drawing.Size(152, 45);
            this.employeesButton.TabIndex = 16;
            this.employeesButton.Text = "Сотрудники";
            this.employeesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.employeesButton.UseVisualStyleBackColor = false;
            this.employeesButton.Click += new System.EventHandler(this.employeesButton_Click);
            // 
            // dishesButton
            // 
            this.dishesButton.BackColor = System.Drawing.Color.White;
            this.dishesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dishesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dishesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dishesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dishesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dishesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dishesButton.Image = global::KitchenBoss.Properties.Resources.regular_dishes_x30;
            this.dishesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dishesButton.Location = new System.Drawing.Point(140, 15);
            this.dishesButton.Name = "dishesButton";
            this.dishesButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dishesButton.Size = new System.Drawing.Size(115, 45);
            this.dishesButton.TabIndex = 15;
            this.dishesButton.Text = "Блюда";
            this.dishesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dishesButton.UseVisualStyleBackColor = false;
            this.dishesButton.Click += new System.EventHandler(this.dishesButton_Click);
            // 
            // clientsButton
            // 
            this.clientsButton.BackColor = System.Drawing.Color.White;
            this.clientsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.clientsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.clientsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.clientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.clientsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.clientsButton.Image = global::KitchenBoss.Properties.Resources.regular_clients_x30;
            this.clientsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsButton.Location = new System.Drawing.Point(3, 15);
            this.clientsButton.Name = "clientsButton";
            this.clientsButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.clientsButton.Size = new System.Drawing.Size(131, 45);
            this.clientsButton.TabIndex = 14;
            this.clientsButton.Text = "Клиенты";
            this.clientsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clientsButton.UseVisualStyleBackColor = false;
            this.clientsButton.Click += new System.EventHandler(this.clientsButton_Click);
            // 
            // userControlButton
            // 
            this.userControlButton.BackColor = System.Drawing.Color.White;
            this.userControlButton.Enabled = false;
            this.userControlButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.userControlButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.userControlButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.userControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userControlButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.userControlButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.userControlButton.Image = global::KitchenBoss.Properties.Resources.regular_control_panel_x30;
            this.userControlButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userControlButton.Location = new System.Drawing.Point(261, 70);
            this.userControlButton.Name = "userControlButton";
            this.userControlButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.userControlButton.Size = new System.Drawing.Size(152, 45);
            this.userControlButton.TabIndex = 19;
            this.userControlButton.Text = "Упр. польз";
            this.userControlButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userControlButton.UseVisualStyleBackColor = false;
            this.userControlButton.Click += new System.EventHandler(this.userControlButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.BackColor = System.Drawing.Color.White;
            this.logoutButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.logoutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.logoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.logoutButton.Image = global::KitchenBoss.Properties.Resources.regular_logout_x20;
            this.logoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.Location = new System.Drawing.Point(323, 136);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(90, 30);
            this.logoutButton.TabIndex = 20;
            this.logoutButton.Text = "Выйти";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // ordersButton
            // 
            this.ordersButton.BackColor = System.Drawing.Color.White;
            this.ordersButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.ordersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ordersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ordersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordersButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.ordersButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ordersButton.Image = global::KitchenBoss.Properties.Resources.regular_orders_x30;
            this.ordersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersButton.Location = new System.Drawing.Point(3, 70);
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ordersButton.Size = new System.Drawing.Size(131, 45);
            this.ordersButton.TabIndex = 17;
            this.ordersButton.Text = "Заказы";
            this.ordersButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ordersButton.UseVisualStyleBackColor = false;
            this.ordersButton.Click += new System.EventHandler(this.ordersButton_Click);
            // 
            // tablesButton
            // 
            this.tablesButton.BackColor = System.Drawing.Color.White;
            this.tablesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.tablesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.tablesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tablesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tablesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.tablesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tablesButton.Image = global::KitchenBoss.Properties.Resources.regular_tables_x30;
            this.tablesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tablesButton.Location = new System.Drawing.Point(140, 70);
            this.tablesButton.Name = "tablesButton";
            this.tablesButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tablesButton.Size = new System.Drawing.Size(115, 45);
            this.tablesButton.TabIndex = 18;
            this.tablesButton.Text = "Столы";
            this.tablesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tablesButton.UseVisualStyleBackColor = false;
            this.tablesButton.Click += new System.EventHandler(this.tablesButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.loginAndPositionLabel);
            this.mainPanel.Controls.Add(this.clientsButton);
            this.mainPanel.Controls.Add(this.tablesButton);
            this.mainPanel.Controls.Add(this.dishesButton);
            this.mainPanel.Controls.Add(this.ordersButton);
            this.mainPanel.Controls.Add(this.employeesButton);
            this.mainPanel.Controls.Add(this.userControlButton);
            this.mainPanel.Controls.Add(this.logoutButton);
            this.mainPanel.Location = new System.Drawing.Point(10, 80);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(419, 170);
            this.mainPanel.TabIndex = 25;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(439, 260);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KitchenBoss - Главная панель";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.headerPanel.ResumeLayout(false);
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
        private System.Windows.Forms.Label loginAndPositionLabel;
        private System.Windows.Forms.Button employeesButton;
        private System.Windows.Forms.Button dishesButton;
        private System.Windows.Forms.Button clientsButton;
        private System.Windows.Forms.Button userControlButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button ordersButton;
        private System.Windows.Forms.Button tablesButton;
        private System.Windows.Forms.Panel mainPanel;
    }
}