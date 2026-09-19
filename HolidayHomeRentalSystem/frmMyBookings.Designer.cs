namespace HolidayHomeRentalSystem
{
    partial class frmMyBookings
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvMyBookings = new System.Windows.Forms.DataGridView();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(388, 26);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(162, 29);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "My Bookings";
            // 
            // dgvMyBookings
            // 
            this.dgvMyBookings.AllowUserToAddRows = false;
            this.dgvMyBookings.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMyBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyBookings.Location = new System.Drawing.Point(12, 74);
            this.dgvMyBookings.MultiSelect = false;
            this.dgvMyBookings.Name = "dgvMyBookings";
            this.dgvMyBookings.ReadOnly = true;
            this.dgvMyBookings.RowHeadersWidth = 51;
            this.dgvMyBookings.RowTemplate.Height = 24;
            this.dgvMyBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyBookings.Size = new System.Drawing.Size(901, 275);
            this.dgvMyBookings.TabIndex = 1;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.BackColor = System.Drawing.Color.Tomato;
            this.btnCancelBooking.Location = new System.Drawing.Point(604, 390);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(150, 39);
            this.btnCancelBooking.TabIndex = 2;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Location = new System.Drawing.Point(782, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 39);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMyBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(925, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.dgvMyBookings);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmMyBookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMyBookings";
            this.Load += new System.EventHandler(this.frmMyBookings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgvMyBookings;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnClose;
    }
}