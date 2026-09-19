
// frmMyBookings.cs — Renter's bookings list with Cancel
// Ref: UC P2.3 Cancel Reservation

using System;
using System.Data;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmMyBookings : Form
    {
        public frmMyBookings()
        {
            InitializeComponent();
        }

        private void frmMyBookings_Load(object sender, EventArgs e)
        {
            Utility.FormatGrid(dgvMyBookings);
            LoadMyBookings();
        }

     
        /// Loads all active bookings for the current renter.
     
        private void LoadMyBookings()
        {
            try
            {
                DataTable dt = Rental.GetBookingsByRenter(CurrentUser.AccountId);
                dgvMyBookings.DataSource = dt;

                // Hide internal IDs from the user
                Utility.HideColumn(dgvMyBookings, "RENTALID");
                Utility.HideColumn(dgvMyBookings, "PROPERTYID");

                // Format price column
                Utility.SetColumnFormat(dgvMyBookings, "TOTALPRICE", "C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        // Ref: UC P2.3 — Cancel Reservation
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                int rentalId = Convert.ToInt32(dgvMyBookings.CurrentRow.Cells["RENTALID"].Value);
                int propertyId  = Convert.ToInt32(dgvMyBookings.CurrentRow.Cells["PROPERTYID"].Value);
                DateTime startDate = Convert.ToDateTime(dgvMyBookings.CurrentRow.Cells["STARTDATE"].Value);
                DateTime endDate = Convert.ToDateTime(dgvMyBookings.CurrentRow.Cells["ENDDATE"].Value);

                Rental.CancelBooking(rentalId, CurrentUser.AccountId, propertyId, startDate, endDate);

                MessageBox.Show("Booking cancelled successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMyBookings(); // refresh grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling booking: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
