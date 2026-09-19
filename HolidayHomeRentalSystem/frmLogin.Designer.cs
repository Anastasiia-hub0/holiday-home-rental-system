namespace HolidayHomeRentalSystem
{
    partial class frmLogin
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lblDash = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOr = new System.Windows.Forms.Label();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblName.Location = new System.Drawing.Point(213, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 32);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Sign In";
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.Color.Silver;
            this.txtEmail.Location = new System.Drawing.Point(94, 125);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(355, 43);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Text = "Email";
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtPassword.Location = new System.Drawing.Point(94, 194);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(355, 43);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Password";
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(94, 288);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(355, 52);
            this.btnSignIn.TabIndex = 9;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.ForeColor = System.Drawing.Color.Gray;
            this.lblDash.Location = new System.Drawing.Point(91, 386);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(159, 16);
            this.lblDash.TabIndex = 10;
            this.lblDash.Text = "--------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(282, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "----------------------------------------";
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOr.ForeColor = System.Drawing.Color.Gray;
            this.lblOr.Location = new System.Drawing.Point(254, 384);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(22, 18);
            this.lblOr.TabIndex = 12;
            this.lblOr.Text = "or";
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(94, 445);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(355, 51);
            this.btnCreateAccount.TabIndex = 13;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(547, 559);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDash);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Button btnCreateAccount;
    }
}