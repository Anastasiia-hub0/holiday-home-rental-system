namespace HolidayHomeRentalSystem
{
    partial class frmPropertyDetails
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
            this.picProperty = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblMaxGuests = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpBookingSum = new System.Windows.Forms.GroupBox();
            this.lblNights = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblGuests = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProperty)).BeginInit();
            this.grpBookingSum.SuspendLayout();
            this.SuspendLayout();
            // 
            // picProperty
            // 
            this.picProperty.Image = global::HolidayHomeRentalSystem.Properties.Resources.default_image;
            this.picProperty.InitialImage = null;
            this.picProperty.Location = new System.Drawing.Point(489, 22);
            this.picProperty.Name = "picProperty";
            this.picProperty.Size = new System.Drawing.Size(276, 188);
            this.picProperty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProperty.TabIndex = 1;
            this.picProperty.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(53, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 22);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(53, 66);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(81, 22);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Address:";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(53, 101);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(78, 22);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "Country:";
            // 
            // lblMaxGuests
            // 
            this.lblMaxGuests.AutoSize = true;
            this.lblMaxGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxGuests.Location = new System.Drawing.Point(53, 139);
            this.lblMaxGuests.Name = "lblMaxGuests";
            this.lblMaxGuests.Size = new System.Drawing.Size(110, 22);
            this.lblMaxGuests.TabIndex = 5;
            this.lblMaxGuests.Text = "Max Guests:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(53, 177);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(103, 22);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price/Night:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(39, 234);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(726, 110);
            this.txtDescription.TabIndex = 7;
            // 
            // grpBookingSum
            // 
            this.grpBookingSum.Controls.Add(this.lblNights);
            this.grpBookingSum.Controls.Add(this.lblTotal);
            this.grpBookingSum.Controls.Add(this.lblGuests);
            this.grpBookingSum.Controls.Add(this.lblCheckOut);
            this.grpBookingSum.Controls.Add(this.lblCheckIn);
            this.grpBookingSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookingSum.Location = new System.Drawing.Point(37, 371);
            this.grpBookingSum.Name = "grpBookingSum";
            this.grpBookingSum.Size = new System.Drawing.Size(727, 171);
            this.grpBookingSum.TabIndex = 8;
            this.grpBookingSum.TabStop = false;
            this.grpBookingSum.Text = "Booking Summary";
            // 
            // lblNights
            // 
            this.lblNights.AutoSize = true;
            this.lblNights.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNights.Location = new System.Drawing.Point(390, 101);
            this.lblNights.Name = "lblNights";
            this.lblNights.Size = new System.Drawing.Size(66, 22);
            this.lblNights.TabIndex = 7;
            this.lblNights.Text = "Nights:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(44, 133);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 22);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total:";
            // 
            // lblGuests
            // 
            this.lblGuests.AutoSize = true;
            this.lblGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuests.Location = new System.Drawing.Point(44, 91);
            this.lblGuests.Name = "lblGuests";
            this.lblGuests.Size = new System.Drawing.Size(72, 22);
            this.lblGuests.TabIndex = 5;
            this.lblGuests.Text = "Guests:";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.Location = new System.Drawing.Point(390, 46);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(100, 22);
            this.lblCheckOut.TabIndex = 4;
            this.lblCheckOut.Text = "Check Out:";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.Location = new System.Drawing.Point(44, 46);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(85, 22);
            this.lblCheckIn.TabIndex = 3;
            this.lblCheckIn.Text = "Check In:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(505, 582);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 38);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBook.Location = new System.Drawing.Point(649, 582);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(115, 38);
            this.btnBook.TabIndex = 10;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // frmPropertyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 632);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpBookingSum);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblMaxGuests);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picProperty);
            this.Name = "frmPropertyDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPropertyDetails";
            this.Load += new System.EventHandler(this.frmPropertyDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProperty)).EndInit();
            this.grpBookingSum.ResumeLayout(false);
            this.grpBookingSum.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picProperty;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblMaxGuests;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpBookingSum;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblGuests;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBook;
    }
}