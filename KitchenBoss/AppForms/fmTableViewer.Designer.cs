namespace KitchenBoss.AppForms
{
    partial class fmTableViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTableViewer));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerSubtitleLabel = new System.Windows.Forms.Label();
            this.headerLogoBackPanel = new System.Windows.Forms.Panel();
            this.headerLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.tableViewerDgv = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.positionsButton = new System.Windows.Forms.Button();
            this.clientOrderDishesButton = new System.Windows.Forms.Button();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.dishesIngredientsButton = new System.Windows.Forms.Button();
            this.dishesCategoriesButton = new System.Windows.Forms.Button();
            this.sortParamLabel = new System.Windows.Forms.Label();
            this.sortParamComboBox = new System.Windows.Forms.ComboBox();
            this.headerPanel.SuspendLayout();
            this.headerLogoBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableViewerDgv)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.headerPanel.Controls.Add(this.sortParamComboBox);
            this.headerPanel.Controls.Add(this.sortParamLabel);
            this.headerPanel.Controls.Add(this.headerTitleLabel);
            this.headerPanel.Controls.Add(this.headerSubtitleLabel);
            this.headerPanel.Controls.Add(this.headerLogoBackPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(500, 70);
            this.headerPanel.TabIndex = 13;
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
            this.headerSubtitleLabel.Size = new System.Drawing.Size(308, 19);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Сотрудники";
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
            // tableViewerDgv
            // 
            this.tableViewerDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableViewerDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableViewerDgv.BackgroundColor = System.Drawing.Color.White;
            this.tableViewerDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableViewerDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableViewerDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tableViewerDgv.Location = new System.Drawing.Point(10, 80);
            this.tableViewerDgv.Name = "tableViewerDgv";
            this.tableViewerDgv.RowHeadersVisible = false;
            this.tableViewerDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableViewerDgv.Size = new System.Drawing.Size(480, 300);
            this.tableViewerDgv.TabIndex = 18;
            this.tableViewerDgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableViewerDgv_CellValueChanged);
            this.tableViewerDgv.CurrentCellDirtyStateChanged += new System.EventHandler(this.tableViewerDgv_CurrentCellDirtyStateChanged);
            this.tableViewerDgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableViewerDgv_DataError);
            this.tableViewerDgv.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.tableViewerDgv_DefaultValuesNeeded);
            this.tableViewerDgv.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.tableViewerDgv_UserDeletedRow);
            this.tableViewerDgv.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.tableViewerDgv_UserDeletingRow);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.Enabled = false;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.saveButton.Image = global::KitchenBoss.Properties.Resources.regular_save_x20;
            this.saveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveButton.Location = new System.Drawing.Point(380, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // positionsButton
            // 
            this.positionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.positionsButton.BackColor = System.Drawing.Color.White;
            this.positionsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.positionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.positionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.positionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positionsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.positionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.positionsButton.Image = global::KitchenBoss.Properties.Resources.regular_job_x20;
            this.positionsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.positionsButton.Location = new System.Drawing.Point(10, 5);
            this.positionsButton.Name = "positionsButton";
            this.positionsButton.Size = new System.Drawing.Size(110, 30);
            this.positionsButton.TabIndex = 21;
            this.positionsButton.Text = "Должности";
            this.positionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.positionsButton.UseVisualStyleBackColor = false;
            this.positionsButton.Click += new System.EventHandler(this.positionsButton_Click);
            // 
            // clientOrderDishesButton
            // 
            this.clientOrderDishesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clientOrderDishesButton.BackColor = System.Drawing.Color.White;
            this.clientOrderDishesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.clientOrderDishesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.clientOrderDishesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.clientOrderDishesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientOrderDishesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.clientOrderDishesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.clientOrderDishesButton.Image = global::KitchenBoss.Properties.Resources.regular_orders_x20;
            this.clientOrderDishesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientOrderDishesButton.Location = new System.Drawing.Point(113, 5);
            this.clientOrderDishesButton.Name = "clientOrderDishesButton";
            this.clientOrderDishesButton.Size = new System.Drawing.Size(127, 30);
            this.clientOrderDishesButton.TabIndex = 23;
            this.clientOrderDishesButton.Text = "Позиции заказа";
            this.clientOrderDishesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clientOrderDishesButton.UseVisualStyleBackColor = false;
            this.clientOrderDishesButton.Visible = false;
            this.clientOrderDishesButton.Click += new System.EventHandler(this.clientOrderDishesButton_Click);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.buttonsPanel.Controls.Add(this.dishesIngredientsButton);
            this.buttonsPanel.Controls.Add(this.dishesCategoriesButton);
            this.buttonsPanel.Controls.Add(this.positionsButton);
            this.buttonsPanel.Controls.Add(this.clientOrderDishesButton);
            this.buttonsPanel.Controls.Add(this.saveButton);
            this.buttonsPanel.Location = new System.Drawing.Point(0, 390);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(500, 40);
            this.buttonsPanel.TabIndex = 24;
            // 
            // dishesIngredientsButton
            // 
            this.dishesIngredientsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dishesIngredientsButton.BackColor = System.Drawing.Color.White;
            this.dishesIngredientsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dishesIngredientsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dishesIngredientsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dishesIngredientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dishesIngredientsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dishesIngredientsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dishesIngredientsButton.Image = global::KitchenBoss.Properties.Resources.regular_ingredients_x20;
            this.dishesIngredientsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dishesIngredientsButton.Location = new System.Drawing.Point(186, 5);
            this.dishesIngredientsButton.Name = "dishesIngredientsButton";
            this.dishesIngredientsButton.Size = new System.Drawing.Size(113, 30);
            this.dishesIngredientsButton.TabIndex = 25;
            this.dishesIngredientsButton.Text = "Ингредиенты";
            this.dishesIngredientsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dishesIngredientsButton.UseVisualStyleBackColor = false;
            this.dishesIngredientsButton.Visible = false;
            this.dishesIngredientsButton.Click += new System.EventHandler(this.dishesIngredientsButton_Click);
            // 
            // dishesCategoriesButton
            // 
            this.dishesCategoriesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dishesCategoriesButton.BackColor = System.Drawing.Color.White;
            this.dishesCategoriesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dishesCategoriesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dishesCategoriesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dishesCategoriesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dishesCategoriesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dishesCategoriesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dishesCategoriesButton.Image = global::KitchenBoss.Properties.Resources.regular_dish_category_x20;
            this.dishesCategoriesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dishesCategoriesButton.Location = new System.Drawing.Point(147, 5);
            this.dishesCategoriesButton.Name = "dishesCategoriesButton";
            this.dishesCategoriesButton.Size = new System.Drawing.Size(129, 30);
            this.dishesCategoriesButton.TabIndex = 24;
            this.dishesCategoriesButton.Text = "Категории блюд";
            this.dishesCategoriesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dishesCategoriesButton.UseVisualStyleBackColor = false;
            this.dishesCategoriesButton.Visible = false;
            this.dishesCategoriesButton.Click += new System.EventHandler(this.dishesCategoriesButton_Click);
            // 
            // sortParamLabel
            // 
            this.sortParamLabel.BackColor = System.Drawing.Color.Transparent;
            this.sortParamLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.sortParamLabel.ForeColor = System.Drawing.Color.Silver;
            this.sortParamLabel.Location = new System.Drawing.Point(272, 10);
            this.sortParamLabel.Name = "sortParamLabel";
            this.sortParamLabel.Size = new System.Drawing.Size(216, 19);
            this.sortParamLabel.TabIndex = 5;
            this.sortParamLabel.Text = "Сортировать блюда по";
            this.sortParamLabel.Visible = false;
            // 
            // sortParamComboBox
            // 
            this.sortParamComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sortParamComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortParamComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.sortParamComboBox.ForeColor = System.Drawing.Color.Silver;
            this.sortParamComboBox.FormattingEnabled = true;
            this.sortParamComboBox.Location = new System.Drawing.Point(276, 32);
            this.sortParamComboBox.Name = "sortParamComboBox";
            this.sortParamComboBox.Size = new System.Drawing.Size(153, 25);
            this.sortParamComboBox.TabIndex = 6;
            this.sortParamComboBox.Visible = false;
            // 
            // fmTableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 430);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.tableViewerDgv);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(516, 469);
            this.Name = "fmTableViewer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KitchenBoss - Сотрудники";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmTableViewer_FormClosing);
            this.headerPanel.ResumeLayout(false);
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableViewerDgv)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
        private System.Windows.Forms.DataGridView tableViewerDgv;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button positionsButton;
        private System.Windows.Forms.Button clientOrderDishesButton;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Button dishesCategoriesButton;
        private System.Windows.Forms.Button dishesIngredientsButton;
        private System.Windows.Forms.ComboBox sortParamComboBox;
        private System.Windows.Forms.Label sortParamLabel;
    }
}