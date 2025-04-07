namespace KitchenBoss.AppForms
{
    partial class fmClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmClients));
            this.ordersButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerSubtitleLabel = new System.Windows.Forms.Label();
            this.headerLogoBackPanel = new System.Windows.Forms.Panel();
            this.headerLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            this.headerLogoBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersButton
            // 
            this.ordersButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ordersButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ordersButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.ordersButton.FlatAppearance.BorderSize = 2;
            this.ordersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.ordersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordersButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.ordersButton.Image = global::KitchenBoss.Properties.Resources.regular_orders_x20;
            this.ordersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersButton.Location = new System.Drawing.Point(12, 206);
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.Size = new System.Drawing.Size(86, 28);
            this.ordersButton.TabIndex = 20;
            this.ordersButton.Text = "Заказы";
            this.ordersButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ordersButton.UseVisualStyleBackColor = false;
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
            this.headerPanel.Size = new System.Drawing.Size(800, 60);
            this.headerPanel.TabIndex = 21;
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
            this.headerSubtitleLabel.Size = new System.Drawing.Size(80, 25);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Клиенты";
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
            // fmClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.ordersButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fmClients";
            this.ShowIcon = false;
            this.Text = "KitchenBoss - Клиенты";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ordersButton;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
    }
}