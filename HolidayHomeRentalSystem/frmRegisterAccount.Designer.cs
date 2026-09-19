namespace HolidayHomeRentalSystem
{
    partial class frmRegisterAccount
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
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblSelectRole = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPhone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblName.Location = new System.Drawing.Point(154, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(231, 32);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Create Account ";
            // 
            // txtFirstName
            // 
            this.txtFirstName.ForeColor = System.Drawing.Color.Silver;
            this.txtFirstName.Location = new System.Drawing.Point(96, 98);
            this.txtFirstName.Multiline = true;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(355, 43);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            this.txtLastName.ForeColor = System.Drawing.Color.Silver;
            this.txtLastName.Location = new System.Drawing.Point(96, 158);
            this.txtLastName.Multiline = true;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(355, 43);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Text = "Last Name";
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.Color.Silver;
            this.txtEmail.Location = new System.Drawing.Point(96, 221);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(355, 43);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "Email";
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtPassword.Location = new System.Drawing.Point(96, 395);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(355, 43);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtConfirmPassword.Location = new System.Drawing.Point(96, 455);
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(355, 43);
            this.txtConfirmPassword.TabIndex = 5;
            this.txtConfirmPassword.Text = "Confirm Password";
            // 
            // cboRole
            // 
            this.cboRole.BackColor = System.Drawing.Color.SteelBlue;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(96, 546);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(355, 24);
            this.cboRole.TabIndex = 6;
            // 
            // lblSelectRole
            // 
            this.lblSelectRole.AutoSize = true;
            this.lblSelectRole.Location = new System.Drawing.Point(93, 515);
            this.lblSelectRole.Name = "lblSelectRole";
            this.lblSelectRole.Size = new System.Drawing.Size(86, 16);
            this.lblSelectRole.TabIndex = 7;
            this.lblSelectRole.Text = "Select Role...";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(366, 608);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(142, 36);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create Account";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(31, 608);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(169, 609);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 36);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // txtPhone
            // 
            this.txtPhone.ForeColor = System.Drawing.Color.Silver;
            this.txtPhone.Location = new System.Drawing.Point(96, 281);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(355, 43);
            this.txtPhone.TabIndex = 11;
            this.txtPhone.Text = "Phone";
            // 
            // frmRegisterAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(547, 670);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblSelectRole);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegisterAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRegisterAccount";
            this.Load += new System.EventHandler(this.frmRegisterAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblSelectRole;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.TextBox txtPhone;
    }
}