using System.Drawing;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    partial class fmPasswordRecovery
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerSubtitleLabel = new System.Windows.Forms.Label();
            this.headerLogoBackPanel = new System.Windows.Forms.Panel();
            this.headerLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.lblEmailAndPhone = new System.Windows.Forms.Label();
            this.txtEmailAndPhone = new System.Windows.Forms.TextBox();
            this.btnSendCode = new System.Windows.Forms.Button();
            this.pnlCodeVerification = new System.Windows.Forms.Panel();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.codeUnderline = new System.Windows.Forms.Panel();
            this.pnlPasswordChange = new System.Windows.Forms.Panel();
            this.pictureBoxConfirmPassword = new System.Windows.Forms.PictureBox();
            this.pictureBoxNewPassword = new System.Windows.Forms.PictureBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSavePassword = new System.Windows.Forms.Button();
            this.newPasswordUnderline = new System.Windows.Forms.Panel();
            this.confirmPasswordUnderline = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.emailUnderline = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.headerLogoBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).BeginInit();
            this.pnlCodeVerification.SuspendLayout();
            this.pnlPasswordChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewPassword)).BeginInit();
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
            this.headerPanel.Size = new System.Drawing.Size(400, 70);
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
            this.headerSubtitleLabel.Size = new System.Drawing.Size(200, 19);
            this.headerSubtitleLabel.TabIndex = 3;
            this.headerSubtitleLabel.Text = "Восстановление пароля";
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
            this.headerLogoPictureBox.Image = global::KitchenBoss.Properties.Resources.chef_hat1;
            this.headerLogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.headerLogoPictureBox.Name = "headerLogoPictureBox";
            this.headerLogoPictureBox.Padding = new System.Windows.Forms.Padding(10);
            this.headerLogoPictureBox.Size = new System.Drawing.Size(70, 70);
            this.headerLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.headerLogoPictureBox.TabIndex = 0;
            this.headerLogoPictureBox.TabStop = false;
            // 
            // lblEmailAndPhone
            // 
            this.lblEmailAndPhone.AutoSize = true;
            this.lblEmailAndPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailAndPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmailAndPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblEmailAndPhone.Location = new System.Drawing.Point(30, 90);
            this.lblEmailAndPhone.Name = "lblEmailAndPhone";
            this.lblEmailAndPhone.Size = new System.Drawing.Size(159, 19);
            this.lblEmailAndPhone.TabIndex = 4;
            this.lblEmailAndPhone.Text = "Email / номер телефона";
            // 
            // txtEmailAndPhone
            // 
            this.txtEmailAndPhone.BackColor = System.Drawing.Color.White;
            this.txtEmailAndPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmailAndPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmailAndPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtEmailAndPhone.Location = new System.Drawing.Point(30, 112);
            this.txtEmailAndPhone.Name = "txtEmailAndPhone";
            this.txtEmailAndPhone.Size = new System.Drawing.Size(340, 18);
            this.txtEmailAndPhone.TabIndex = 1;
            this.txtEmailAndPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailAndPhone_KeyDown);
            // 
            // btnSendCode
            // 
            this.btnSendCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSendCode.FlatAppearance.BorderSize = 0;
            this.btnSendCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnSendCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(43)))), ((int)(((byte)(59)))));
            this.btnSendCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendCode.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendCode.ForeColor = System.Drawing.Color.White;
            this.btnSendCode.Location = new System.Drawing.Point(30, 150);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.Size = new System.Drawing.Size(340, 36);
            this.btnSendCode.TabIndex = 2;
            this.btnSendCode.Text = "Отправить код";
            this.btnSendCode.UseVisualStyleBackColor = false;
            this.btnSendCode.Click += new System.EventHandler(this.btnSendCode_Click);
            // 
            // pnlCodeVerification
            // 
            this.pnlCodeVerification.Controls.Add(this.lblCode);
            this.pnlCodeVerification.Controls.Add(this.txtCode);
            this.pnlCodeVerification.Controls.Add(this.btnVerify);
            this.pnlCodeVerification.Controls.Add(this.codeUnderline);
            this.pnlCodeVerification.Location = new System.Drawing.Point(0, 200);
            this.pnlCodeVerification.Name = "pnlCodeVerification";
            this.pnlCodeVerification.Size = new System.Drawing.Size(400, 140);
            this.pnlCodeVerification.TabIndex = 3;
            this.pnlCodeVerification.Visible = false;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblCode.Location = new System.Drawing.Point(30, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(101, 19);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "Код из письма";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCode.Location = new System.Drawing.Point(30, 42);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(340, 18);
            this.txtCode.TabIndex = 3;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnVerify.FlatAppearance.BorderSize = 0;
            this.btnVerify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnVerify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(43)))), ((int)(((byte)(59)))));
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(30, 80);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(340, 36);
            this.btnVerify.TabIndex = 4;
            this.btnVerify.Text = "Подтвердить";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // codeUnderline
            // 
            this.codeUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.codeUnderline.Location = new System.Drawing.Point(30, 62);
            this.codeUnderline.Name = "codeUnderline";
            this.codeUnderline.Size = new System.Drawing.Size(340, 2);
            this.codeUnderline.TabIndex = 12;
            // 
            // pnlPasswordChange
            // 
            this.pnlPasswordChange.Controls.Add(this.pictureBoxConfirmPassword);
            this.pnlPasswordChange.Controls.Add(this.pictureBoxNewPassword);
            this.pnlPasswordChange.Controls.Add(this.lblNewPassword);
            this.pnlPasswordChange.Controls.Add(this.txtNewPassword);
            this.pnlPasswordChange.Controls.Add(this.lblConfirmPassword);
            this.pnlPasswordChange.Controls.Add(this.txtConfirmPassword);
            this.pnlPasswordChange.Controls.Add(this.btnSavePassword);
            this.pnlPasswordChange.Controls.Add(this.newPasswordUnderline);
            this.pnlPasswordChange.Controls.Add(this.confirmPasswordUnderline);
            this.pnlPasswordChange.Location = new System.Drawing.Point(0, 200);
            this.pnlPasswordChange.Name = "pnlPasswordChange";
            this.pnlPasswordChange.Size = new System.Drawing.Size(400, 200);
            this.pnlPasswordChange.TabIndex = 4;
            this.pnlPasswordChange.Visible = false;
            // 
            // pictureBoxConfirmPassword
            // 
            this.pictureBoxConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxConfirmPassword.Image = global::KitchenBoss.Properties.Resources.regular_eye_x20;
            this.pictureBoxConfirmPassword.Location = new System.Drawing.Point(350, 102);
            this.pictureBoxConfirmPassword.Name = "pictureBoxConfirmPassword";
            this.pictureBoxConfirmPassword.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxConfirmPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxConfirmPassword.TabIndex = 16;
            this.pictureBoxConfirmPassword.TabStop = false;
            this.pictureBoxConfirmPassword.Click += new System.EventHandler(this.pictureBoxConfirmPassword_Click);
            // 
            // pictureBoxNewPassword
            // 
            this.pictureBoxNewPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNewPassword.Image = global::KitchenBoss.Properties.Resources.regular_eye_x20;
            this.pictureBoxNewPassword.Location = new System.Drawing.Point(350, 42);
            this.pictureBoxNewPassword.Name = "pictureBoxNewPassword";
            this.pictureBoxNewPassword.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxNewPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNewPassword.TabIndex = 15;
            this.pictureBoxNewPassword.TabStop = false;
            this.pictureBoxNewPassword.Click += new System.EventHandler(this.pictureBoxNewPassword_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblNewPassword.Location = new System.Drawing.Point(30, 20);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(101, 19);
            this.lblNewPassword.TabIndex = 5;
            this.lblNewPassword.Text = "Новый пароль";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNewPassword.Location = new System.Drawing.Point(30, 42);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(310, 18);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPassword_KeyDown);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(30, 80);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(111, 19);
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "Подтверждение";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(30, 102);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(310, 18);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            // 
            // btnSavePassword
            // 
            this.btnSavePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSavePassword.FlatAppearance.BorderSize = 0;
            this.btnSavePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnSavePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(43)))), ((int)(((byte)(59)))));
            this.btnSavePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePassword.ForeColor = System.Drawing.Color.White;
            this.btnSavePassword.Location = new System.Drawing.Point(210, 150);
            this.btnSavePassword.Name = "btnSavePassword";
            this.btnSavePassword.Size = new System.Drawing.Size(160, 36);
            this.btnSavePassword.TabIndex = 7;
            this.btnSavePassword.Text = "Сохранить пароль";
            this.btnSavePassword.UseVisualStyleBackColor = false;
            this.btnSavePassword.Click += new System.EventHandler(this.btnSavePassword_Click);
            // 
            // newPasswordUnderline
            // 
            this.newPasswordUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.newPasswordUnderline.Location = new System.Drawing.Point(30, 62);
            this.newPasswordUnderline.Name = "newPasswordUnderline";
            this.newPasswordUnderline.Size = new System.Drawing.Size(340, 2);
            this.newPasswordUnderline.TabIndex = 13;
            // 
            // confirmPasswordUnderline
            // 
            this.confirmPasswordUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.confirmPasswordUnderline.Location = new System.Drawing.Point(30, 122);
            this.confirmPasswordUnderline.Name = "confirmPasswordUnderline";
            this.confirmPasswordUnderline.Size = new System.Drawing.Size(340, 2);
            this.confirmPasswordUnderline.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnCancel.Location = new System.Drawing.Point(30, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // emailUnderline
            // 
            this.emailUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.emailUnderline.Location = new System.Drawing.Point(30, 132);
            this.emailUnderline.Name = "emailUnderline";
            this.emailUnderline.Size = new System.Drawing.Size(340, 2);
            this.emailUnderline.TabIndex = 11;
            // 
            // fmPasswordRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.emailUnderline);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlPasswordChange);
            this.Controls.Add(this.pnlCodeVerification);
            this.Controls.Add(this.btnSendCode);
            this.Controls.Add(this.txtEmailAndPhone);
            this.Controls.Add(this.lblEmailAndPhone);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmPasswordRecovery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KitchenBoss - Восстановление пароля";
            this.headerPanel.ResumeLayout(false);
            this.headerLogoBackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerLogoPictureBox)).EndInit();
            this.pnlCodeVerification.ResumeLayout(false);
            this.pnlCodeVerification.PerformLayout();
            this.pnlPasswordChange.ResumeLayout(false);
            this.pnlPasswordChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox headerLogoPictureBox;
        private System.Windows.Forms.Panel headerLogoBackPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerSubtitleLabel;
        private System.Windows.Forms.Label lblEmailAndPhone;
        private System.Windows.Forms.TextBox txtEmailAndPhone;
        private System.Windows.Forms.Button btnSendCode;
        private System.Windows.Forms.Panel pnlCodeVerification;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Panel pnlPasswordChange;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSavePassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel emailUnderline;
        private System.Windows.Forms.Panel codeUnderline;
        private System.Windows.Forms.Panel newPasswordUnderline;
        private System.Windows.Forms.Panel confirmPasswordUnderline;
        private PictureBox pictureBoxNewPassword;
        private PictureBox pictureBoxConfirmPassword;
    }
}