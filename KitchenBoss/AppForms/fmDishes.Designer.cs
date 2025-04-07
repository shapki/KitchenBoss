namespace KitchenBoss.AppForms
{
    partial class fmDishes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmDishes));
            this.dishesIngredientsButton = new System.Windows.Forms.Button();
            this.dishesCategoriesButton = new System.Windows.Forms.Button();
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
            // dishesIngredientsButton
            // 
            this.dishesIngredientsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dishesIngredientsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dishesIngredientsButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.dishesIngredientsButton.FlatAppearance.BorderSize = 2;
            this.dishesIngredientsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.dishesIngredientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dishesIngredientsButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.dishesIngredientsButton.Image = global::KitchenBoss.Properties.Resources.regular_ingredients_x20;
            this.dishesIngredientsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dishesIngredientsButton.Location = new System.Drawing.Point(149, 254);
            this.dishesIngredientsButton.Name = "dishesIngredientsButton";
            this.dishesIngredientsButton.Size = new System.Drawing.Size(117, 28);
            this.dishesIngredientsButton.TabIndex = 20;
            this.dishesIngredientsButton.Text = "Ингредиенты";
            this.dishesIngredientsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dishesIngredientsButton.UseVisualStyleBackColor = false;
            // 
            // dishesCategoriesButton
            // 
            this.dishesCategoriesButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dishesCategoriesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dishesCategoriesButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.dishesCategoriesButton.FlatAppearance.BorderSize = 2;
            this.dishesCategoriesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.dishesCategoriesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dishesCategoriesButton.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 10F);
            this.dishesCategoriesButton.Image = global::KitchenBoss.Properties.Resources.regular_dish_category_x20;
            this.dishesCategoriesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dishesCategoriesButton.Location = new System.Drawing.Point(12, 254);
            this.dishesCategoriesButton.Name = "dishesCategoriesButton";
            this.dishesCategoriesButton.Size = new System.Drawing.Size(132, 28);
            this.dishesCategoriesButton.TabIndex = 19;
            this.dishesCategoriesButton.Text = "Категории блюд";
            this.dishesCategoriesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dishesCategoriesButton.UseVisualStyleBackColor = false;
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
            this.headerSubtitleLabel.Size = new System.Drawing.Size(63, 25);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Блюда";
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
            // fmDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.dishesIngredientsButton);
            this.Controls.Add(this.dishesCategoriesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fmDishes";
            this.ShowIcon = false;
            this.Text = "KitchenBoss - Блюда";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dishesIngredientsButton;
        private System.Windows.Forms.Button dishesCategoriesButton;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
    }
}