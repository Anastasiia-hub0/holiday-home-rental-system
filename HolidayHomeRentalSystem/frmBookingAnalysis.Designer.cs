namespace HolidayHomeRentalSystem
{
    partial class frmBookingAnalysis
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
            this.lblBookingAnalysis = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBookingAnalysis
            // 
            this.lblBookingAnalysis.AutoSize = true;
            this.lblBookingAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingAnalysis.Location = new System.Drawing.Point(486, 41);
            this.lblBookingAnalysis.Name = "lblBookingAnalysis";
            this.lblBookingAnalysis.Size = new System.Drawing.Size(196, 29);
            this.lblBookingAnalysis.TabIndex = 0;
            this.lblBookingAnalysis.Text = "Booking Analysis";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(383, 135);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(48, 22);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(466, 119);
            this.txtYear.Multiline = true;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(239, 38);
            this.txtYear.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LimeGreen;
            this.btnRun.Location = new System.Drawing.Point(737, 119);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(131, 38);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Location = new System.Drawing.Point(992, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 38);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvBookings
            // 
            this.dgvBookings.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(184, 189);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.RowTemplate.Height = 24;
            this.dgvBookings.Size = new System.Drawing.Size(807, 186);
            this.dgvBookings.TabIndex = 5;
            // 
            // frmBookingAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1144, 469);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblBookingAnalysis);
            this.Name = "frmBookingAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBookingAnalysis";
            this.Load += new System.EventHandler(this.frmBookingAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookingAnalysis;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvBookings;
    }
}