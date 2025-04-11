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
            this.headerPanel.SuspendLayout();
            this.headerLogoBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableViewerDgv)).BeginInit();
            this.SuspendLayout();
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
            this.headerPanel.TabIndex = 13;
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
            // headerSubtitleLabel
            // 
            this.headerSubtitleLabel.AutoSize = true;
            this.headerSubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerSubtitleLabel.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 15F);
            this.headerSubtitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.headerSubtitleLabel.Location = new System.Drawing.Point(66, 35);
            this.headerSubtitleLabel.Name = "headerSubtitleLabel";
            this.headerSubtitleLabel.Size = new System.Drawing.Size(105, 25);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Сотрудники";
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
            // tableViewerDgv
            // 
            this.tableViewerDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableViewerDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableViewerDgv.Location = new System.Drawing.Point(12, 66);
            this.tableViewerDgv.Name = "tableViewerDgv";
            this.tableViewerDgv.Size = new System.Drawing.Size(457, 280);
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
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // positionsButton
            // 
            this.positionsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.positionsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.positionsButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.positionsButton.FlatAppearance.BorderSize = 2;
            this.positionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.positionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positionsButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.positionsButton.Image = global::KitchenBoss.Properties.Resources.regular_job_x20;
            this.positionsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.positionsButton.Location = new System.Drawing.Point(12, 352);
            this.positionsButton.Name = "positionsButton";
            this.positionsButton.Size = new System.Drawing.Size(103, 28);
            this.positionsButton.TabIndex = 21;
            this.positionsButton.Text = "Должности";
            this.positionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.positionsButton.UseVisualStyleBackColor = false;
            this.positionsButton.Click += new System.EventHandler(this.positionsButton_Click);
            // 
            // clientOrderDishesButton
            // 
            this.clientOrderDishesButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientOrderDishesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clientOrderDishesButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.clientOrderDishesButton.FlatAppearance.BorderSize = 2;
            this.clientOrderDishesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.clientOrderDishesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientOrderDishesButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.clientOrderDishesButton.Image = global::KitchenBoss.Properties.Resources.regular_orders_x20;
            this.clientOrderDishesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientOrderDishesButton.Location = new System.Drawing.Point(121, 352);
            this.clientOrderDishesButton.Name = "clientOrderDishesButton";
            this.clientOrderDishesButton.Size = new System.Drawing.Size(108, 28);
            this.clientOrderDishesButton.TabIndex = 23;
            this.clientOrderDishesButton.Text = "Чек клиента";
            this.clientOrderDishesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clientOrderDishesButton.UseVisualStyleBackColor = false;
            this.clientOrderDishesButton.Visible = false;
            this.clientOrderDishesButton.Click += new System.EventHandler(this.clientOrderDishesButton_Click);
            // 
            // fmTableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 392);
            this.Controls.Add(this.clientOrderDishesButton);
            this.Controls.Add(this.positionsButton);
            this.Controls.Add(this.tableViewerDgv);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fmTableViewer";
            this.ShowIcon = false;
            this.Text = "KitchenBoss - Сотрудники";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmTableViewer_FormClosing);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableViewerDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
        private System.Windows.Forms.DataGridView tableViewerDgv;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button positionsButton;
        private System.Windows.Forms.Button clientOrderDishesButton;
    }
}