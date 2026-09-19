namespace HolidayHomeRentalSystem
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateAcc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSignIn = new System.Windows.Forms.ToolStripMenuItem();
            this.plnCard = new System.Windows.Forms.Panel();
            this.lblNumOfGuests = new System.Windows.Forms.Label();
            this.lblWhereto = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.nudGuests = new System.Windows.Forms.NumericUpDown();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.pnlRenter = new System.Windows.Forms.Panel();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnAccountDetails = new System.Windows.Forms.Button();
            this.btnMyBookings = new System.Windows.Forms.Button();
            this.pnlHost = new System.Windows.Forms.Panel();
            this.btnHostAccountDetails = new System.Windows.Forms.Button();
            this.btnSign_Out = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.btnMyProperties = new System.Windows.Forms.Button();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnBookingAnalysis = new System.Windows.Forms.Button();
            this.btnRevenueAnalysis = new System.Windows.Forms.Button();
            this.btnManageAccounts = new System.Windows.Forms.Button();
            this.mnuMain.SuspendLayout();
            this.plnCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.pnlRenter.SuspendLayout();
            this.pnlHost.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.Color.SteelBlue;
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogo,
            this.mnuExit,
            this.mnuCreateAcc,
            this.mnuSignIn});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(1047, 43);
            this.mnuMain.TabIndex = 0;
            // 
            // mnuLogo
            // 
            this.mnuLogo.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuLogo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mnuLogo.Name = "mnuLogo";
            this.mnuLogo.Size = new System.Drawing.Size(171, 39);
            this.mnuLogo.Text = "Hommy.ie";
            // 
            // mnuExit
            // 
            this.mnuExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuExit.BackColor = System.Drawing.Color.SteelBlue;
            this.mnuExit.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(64, 39);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuCreateAcc
            // 
            this.mnuCreateAcc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuCreateAcc.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuCreateAcc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mnuCreateAcc.Name = "mnuCreateAcc";
            this.mnuCreateAcc.Size = new System.Drawing.Size(175, 39);
            this.mnuCreateAcc.Text = "Create Account";
            this.mnuCreateAcc.Click += new System.EventHandler(this.mnuCreateAcc_Click);
            // 
            // mnuSignIn
            // 
            this.mnuSignIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuSignIn.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSignIn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mnuSignIn.Name = "mnuSignIn";
            this.mnuSignIn.Size = new System.Drawing.Size(85, 39);
            this.mnuSignIn.Text = "Sign In";
            this.mnuSignIn.Click += new System.EventHandler(this.mnuSignIn_Click);
            // 
            // plnCard
            // 
            this.plnCard.BackColor = System.Drawing.Color.White;
            this.plnCard.Controls.Add(this.lblNumOfGuests);
            this.plnCard.Controls.Add(this.lblWhereto);
            this.plnCard.Controls.Add(this.btnSearch);
            this.plnCard.Controls.Add(this.nudGuests);
            this.plnCard.Controls.Add(this.dtpCheckOut);
            this.plnCard.Controls.Add(this.dtpCheckIn);
            this.plnCard.Controls.Add(this.txtLocation);
            this.plnCard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.plnCard.Location = new System.Drawing.Point(227, 69);
            this.plnCard.Name = "plnCard";
            this.plnCard.Size = new System.Drawing.Size(615, 283);
            this.plnCard.TabIndex = 1;
            // 
            // lblNumOfGuests
            // 
            this.lblNumOfGuests.AutoSize = true;
            this.lblNumOfGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfGuests.Location = new System.Drawing.Point(14, 107);
            this.lblNumOfGuests.Name = "lblNumOfGuests";
            this.lblNumOfGuests.Size = new System.Drawing.Size(167, 22);
            this.lblNumOfGuests.TabIndex = 7;
            this.lblNumOfGuests.Text = "Number of guests";
            // 
            // lblWhereto
            // 
            this.lblWhereto.AutoSize = true;
            this.lblWhereto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhereto.Location = new System.Drawing.Point(14, 18);
            this.lblWhereto.Name = "lblWhereto";
            this.lblWhereto.Size = new System.Drawing.Size(91, 22);
            this.lblWhereto.TabIndex = 6;
            this.lblWhereto.Text = "Where to";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(18, 215);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(576, 43);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // nudGuests
            // 
            this.nudGuests.Location = new System.Drawing.Point(18, 132);
            this.nudGuests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGuests.Name = "nudGuests";
            this.nudGuests.Size = new System.Drawing.Size(576, 24);
            this.nudGuests.TabIndex = 3;
            this.nudGuests.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.Location = new System.Drawing.Point(326, 175);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(217, 24);
            this.dtpCheckOut.TabIndex = 2;
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(65, 175);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(219, 24);
            this.dtpCheckIn.TabIndex = 1;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(18, 43);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(576, 46);
            this.txtLocation.TabIndex = 0;
            // 
            // dgvResult
            // 
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvResult.Location = new System.Drawing.Point(47, 380);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvResult.RowTemplate.Height = 24;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(959, 221);
            this.dgvResult.TabIndex = 2;
            this.dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
            // 
            // pnlRenter
            // 
            this.pnlRenter.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlRenter.Controls.Add(this.btnSignOut);
            this.pnlRenter.Controls.Add(this.btnAccountDetails);
            this.pnlRenter.Controls.Add(this.btnMyBookings);
            this.pnlRenter.Location = new System.Drawing.Point(294, 0);
            this.pnlRenter.Name = "pnlRenter";
            this.pnlRenter.Size = new System.Drawing.Size(753, 33);
            this.pnlRenter.TabIndex = 3;
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(484, 6);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(140, 31);
            this.btnSignOut.TabIndex = 5;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnAccountDetails
            // 
            this.btnAccountDetails.Location = new System.Drawing.Point(307, 6);
            this.btnAccountDetails.Name = "btnAccountDetails";
            this.btnAccountDetails.Size = new System.Drawing.Size(140, 31);
            this.btnAccountDetails.TabIndex = 4;
            this.btnAccountDetails.Text = "Account Details";
            this.btnAccountDetails.UseVisualStyleBackColor = true;
            this.btnAccountDetails.Click += new System.EventHandler(this.btnAccountDetails_Click);
            // 
            // btnMyBookings
            // 
            this.btnMyBookings.Location = new System.Drawing.Point(129, 6);
            this.btnMyBookings.Name = "btnMyBookings";
            this.btnMyBookings.Size = new System.Drawing.Size(140, 31);
            this.btnMyBookings.TabIndex = 3;
            this.btnMyBookings.Text = "My Bookings";
            this.btnMyBookings.UseVisualStyleBackColor = true;
            this.btnMyBookings.Click += new System.EventHandler(this.btnMyBookings_Click);
            // 
            // pnlHost
            // 
            this.pnlHost.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHost.Controls.Add(this.btnHostAccountDetails);
            this.pnlHost.Controls.Add(this.btnSign_Out);
            this.pnlHost.Controls.Add(this.btnAddProperty);
            this.pnlHost.Controls.Add(this.btnMyProperties);
            this.pnlHost.Location = new System.Drawing.Point(225, 0);
            this.pnlHost.Name = "pnlHost";
            this.pnlHost.Size = new System.Drawing.Size(822, 33);
            this.pnlHost.TabIndex = 4;
            this.pnlHost.Visible = false;
           
            // 
            // btnHostAccountDetails
            // 
            this.btnHostAccountDetails.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnHostAccountDetails.Location = new System.Drawing.Point(67, -8);
            this.btnHostAccountDetails.Name = "btnHostAccountDetails";
            this.btnHostAccountDetails.Size = new System.Drawing.Size(160, 38);
            this.btnHostAccountDetails.TabIndex = 5;
            this.btnHostAccountDetails.Text = "Account Details";
            this.btnHostAccountDetails.UseVisualStyleBackColor = true;
            this.btnHostAccountDetails.Click += new System.EventHandler(this.btnHostAccountDetails_Click_1);
            // 
            // btnSign_Out
            // 
            this.btnSign_Out.Location = new System.Drawing.Point(651, -8);
            this.btnSign_Out.Name = "btnSign_Out";
            this.btnSign_Out.Size = new System.Drawing.Size(142, 38);
            this.btnSign_Out.TabIndex = 4;
            this.btnSign_Out.Text = "Sign Out";
            this.btnSign_Out.UseVisualStyleBackColor = true;
            this.btnSign_Out.Click += new System.EventHandler(this.btnSign_Out_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Location = new System.Drawing.Point(468, -8);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(147, 38);
            this.btnAddProperty.TabIndex = 3;
            this.btnAddProperty.Text = "Add Property";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // btnMyProperties
            // 
            this.btnMyProperties.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnMyProperties.Location = new System.Drawing.Point(271, -8);
            this.btnMyProperties.Name = "btnMyProperties";
            this.btnMyProperties.Size = new System.Drawing.Size(152, 38);
            this.btnMyProperties.TabIndex = 2;
            this.btnMyProperties.Text = "My Properties";
            this.btnMyProperties.UseVisualStyleBackColor = true;
            this.btnMyProperties.Click += new System.EventHandler(this.btnMyProperties_Click);
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdmin.Controls.Add(this.btnSign);
            this.pnlAdmin.Controls.Add(this.btnBookingAnalysis);
            this.pnlAdmin.Controls.Add(this.btnRevenueAnalysis);
            this.pnlAdmin.Controls.Add(this.btnManageAccounts);
            this.pnlAdmin.Location = new System.Drawing.Point(97, 126);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(921, 475);
            this.pnlAdmin.TabIndex = 5;
            this.pnlAdmin.Visible = false;
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(763, 411);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(146, 38);
            this.btnSign.TabIndex = 6;
            this.btnSign.Text = "Sign Out";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnBookingAnalysis
            // 
            this.btnBookingAnalysis.Location = new System.Drawing.Point(297, 228);
            this.btnBookingAnalysis.Name = "btnBookingAnalysis";
            this.btnBookingAnalysis.Size = new System.Drawing.Size(254, 56);
            this.btnBookingAnalysis.TabIndex = 4;
            this.btnBookingAnalysis.Text = "Booking Analysis";
            this.btnBookingAnalysis.UseVisualStyleBackColor = true;
            this.btnBookingAnalysis.Click += new System.EventHandler(this.btnBookingAnalysis_Click);
            // 
            // btnRevenueAnalysis
            // 
            this.btnRevenueAnalysis.Location = new System.Drawing.Point(297, 125);
            this.btnRevenueAnalysis.Name = "btnRevenueAnalysis";
            this.btnRevenueAnalysis.Size = new System.Drawing.Size(254, 59);
            this.btnRevenueAnalysis.TabIndex = 3;
            this.btnRevenueAnalysis.Text = "Revenue Analysis";
            this.btnRevenueAnalysis.UseVisualStyleBackColor = true;
            this.btnRevenueAnalysis.Click += new System.EventHandler(this.btnRevenueAnalysis_Click);
            // 
            // btnManageAccounts
            // 
            this.btnManageAccounts.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnManageAccounts.Location = new System.Drawing.Point(297, 21);
            this.btnManageAccounts.Name = "btnManageAccounts";
            this.btnManageAccounts.Size = new System.Drawing.Size(254, 61);
            this.btnManageAccounts.TabIndex = 2;
            this.btnManageAccounts.Text = "Manage Accounts";
            this.btnManageAccounts.UseVisualStyleBackColor = true;
            this.btnManageAccounts.Click += new System.EventHandler(this.btnManageAccounts_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::HolidayHomeRentalSystem.Properties.Resources.background_cloud_3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1047, 613);
            this.Controls.Add(this.pnlHost);
            this.Controls.Add(this.pnlAdmin);
            this.Controls.Add(this.pnlRenter);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.plnCard);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Holiday Home Rental System";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.plnCard.ResumeLayout(false);
            this.plnCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.pnlRenter.ResumeLayout(false);
            this.pnlHost.ResumeLayout(false);
            this.pnlAdmin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuLogo;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Panel plnCard;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.NumericUpDown nudGuests;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Label lblWhereto;
        private System.Windows.Forms.Label lblNumOfGuests;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateAcc;
        private System.Windows.Forms.ToolStripMenuItem mnuSignIn;
        private System.Windows.Forms.Panel pnlRenter;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnAccountDetails;
        private System.Windows.Forms.Button btnMyBookings;
        private System.Windows.Forms.Panel pnlHost;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.Button btnMyProperties;
        private System.Windows.Forms.Button btnSign_Out;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.Button btnBookingAnalysis;
        private System.Windows.Forms.Button btnRevenueAnalysis;
        private System.Windows.Forms.Button btnManageAccounts;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnHostAccountDetails;
    }
}

