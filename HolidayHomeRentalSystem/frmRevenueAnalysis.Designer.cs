namespace HolidayHomeRentalSystem
{
    partial class frmRevenueAnalysis
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
            this.lblRevenueAnalysis = new System.Windows.Forms.Label();
            this.dgvRevenue = new System.Windows.Forms.DataGridView();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
            this.SuspendLayout();
          
            this.lblRevenueAnalysis.AutoSize = true;
            this.lblRevenueAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueAnalysis.Location = new System.Drawing.Point(351, 46);
            this.lblRevenueAnalysis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueAnalysis.Name = "lblRevenueAnalysis";
            this.lblRevenueAnalysis.Size = new System.Drawing.Size(203, 29);
            this.lblRevenueAnalysis.TabIndex = 0;
            this.lblRevenueAnalysis.Text = "Revenue Analysis";
            // 
            // dgvRevenue
            // 
            this.dgvRevenue.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRevenue.Location = new System.Drawing.Point(62, 199);
            this.dgvRevenue.Name = "dgvRevenue";
            this.dgvRevenue.RowHeadersWidth = 51;
            this.dgvRevenue.RowTemplate.Height = 24;
            this.dgvRevenue.Size = new System.Drawing.Size(782, 199);
            this.dgvRevenue.TabIndex = 1;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(181, 137);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(48, 22);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(261, 124);
            this.txtYear.Multiline = true;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(225, 35);
            this.txtYear.TabIndex = 3;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LimeGreen;
            this.btnRun.Location = new System.Drawing.Point(529, 124);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(121, 35);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Location = new System.Drawing.Point(755, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 44);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRevenueAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(908, 486);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.dgvRevenue);
            this.Controls.Add(this.lblRevenueAnalysis);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRevenueAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRevenueAnalysis";
            this.Load += new System.EventHandler(this.frmRevenueAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRevenueAnalysis;
        private System.Windows.Forms.DataGridView dgvRevenue;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
    }
}