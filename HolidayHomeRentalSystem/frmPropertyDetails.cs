
// frmPropertyDetails.cs — View property details and create a booking
// Ref: UC P3.3 View Property Details, UC P2.2 Create Booking

using System;
using System.Data;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmPropertyDetails : Form
    {
        // Приватные переменные нужны потому что данные передаются извне
        // frmRegisterAccount не нуждается в них — пользователь сам вводит данные
        // Здесь данные приходят из frmMainMenu через конструктор
        private int _propertyId;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private int _guests;
        private decimal _pricePerNight = 0m;

       
        public frmPropertyDetails()
        {
            InitializeComponent();
        }

        // Parameterised constructor — called from search results
        public frmPropertyDetails(int propertyId, DateTime checkIn, DateTime checkOut, int guests)
        {
            InitializeComponent();
            _propertyId = propertyId;
            _checkIn = checkIn;
            _checkOut = checkOut;
            _guests = guests;
        }

        // Form Load
        private void frmPropertyDetails_Load(object sender, EventArgs e)
        {
            // Display booking summary from search
            lblCheckIn.Text = _checkIn.ToString("dd-MMM-yyyy");
            lblCheckOut.Text = _checkOut.ToString("dd-MMM-yyyy");
            lblGuests.Text = _guests.ToString();

            int nights = (_checkOut - _checkIn).Days;
            if (nights < 1) nights = 1;
            lblNights.Text = nights.ToString();

            LoadProperty();
        }

    
        private void LoadProperty()
        {
            try
            {
                DataTable dt = Property.GetPropertyById(_propertyId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Property not found.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                lblTitle.Text = row["TITLE"].ToString();
                txtDescription.Text = row["DESCRIPTION"].ToString();
                lblAddress.Text = row["ADDRESS"].ToString();
                lblCountry.Text = row["COUNTRY"].ToString();
                lblMaxGuests.Text = row["MAXGUESTS"].ToString();

                _pricePerNight = Convert.ToDecimal(row["PRICE"]);
                lblPrice.Text = _pricePerNight.ToString("C2");

                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading property: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTotal()
        {
            int nights = (_checkOut - _checkIn).Days;
            if (nights < 1) nights = 1;

            decimal total = _pricePerNight * nights;
            lblTotal.Text = total.ToString("C2");
        }

        //Book button
        // Ref: UC P2.2 — Create Booking
        private void btnBook_Click(object sender, EventArgs e)
        {
            // Must be logged in
            if (!CurrentUser.IsLoggedIn)
            {
                using (frmLogin frm = new frmLogin())
                {
                    if (frm.ShowDialog(this) != DialogResult.OK)
                        return;
                }
            }

            // Only renters can book
            if (CurrentUser.Role != "Renter")
            {
                MessageBox.Show("Only renters can book properties.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nights = (_checkOut - _checkIn).Days;
            if (nights < 1)
            {
                MessageBox.Show("Invalid dates.", "Validation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalPrice = nights * _pricePerNight;

            // Confirm booking with total price shown
            DialogResult confirm = MessageBox.Show(
                "Confirm booking?\n\n" +
                "Property: " + lblTitle.Text + "\n" +
                "Dates: " + _checkIn.ToString("dd-MMM-yyyy") + " to " + _checkOut.ToString("dd-MMM-yyyy") + "\n" +
                "Nights: " + nights + "\n" +
                "Guests: " + _guests + "\n" +
                "Total Price: " + totalPrice.ToString("C2"),
                "Confirm Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Use Rental business class for transactional booking
                Rental.CreateBooking(_propertyId, CurrentUser.AccountId,
                    _checkIn, _checkOut, _guests, totalPrice);


                // Send confirmation emails
                try
                {
                    EmailService.SendBookingConfirmation(
                        CurrentUser.Email,
                        CurrentUser.FirstName,
                        lblTitle.Text,
                        _checkIn, _checkOut,
                        _guests, totalPrice);

                    MessageBox.Show("Confirmation email sent!", "Email",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                  
                    MessageBox.Show("Booking saved but email could not be sent.", "Email",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                MessageBox.Show("Booking successful!", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking failed: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Close button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
