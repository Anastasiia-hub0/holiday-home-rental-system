
// frmManageAvailability.cs — Host adds/removes availability slots
// Ref: UC P4.1 Add Availability, UC P4.2 Remove Availability

using System;
using System.Data;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmManageAvailability : Form
    {
        private int _propertyId;

        public frmManageAvailability(int propertyId)
        {
            InitializeComponent();
            _propertyId = propertyId;
        }

        private void frmManageAvailability_Load(object sender, EventArgs e)
        {
            Utility.FormatGrid(dgvAvailability);

            // Ref: DateTimePicker doc — MinDate so start cannot be in the past
            dtpStart.MinDate = DateTime.Today;
            dtpEnd.MinDate = DateTime.Today.AddDays(1);

      

            LoadAvailability();
        }

        private void LoadAvailability()
        {
            try
            {
                DataTable dt = Availability.GetByProperty(_propertyId);
                dgvAvailability.DataSource = dt;

                Utility.HideColumn(dgvAvailability, "AVAILABILITYID");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading availability: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///Returns selected AvailabilityID or -1
        private int GetSelectedAvailabilityId()
        {
            if (dgvAvailability.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dgvAvailability.CurrentRow.Cells["AVAILABILITYID"].Value);
        }

        // Add button
        // Ref: UC P4.1 — Add Availability
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dtpEnd.Value.Date <= dtpStart.Value.Date)
            {
                MessageBox.Show("End date must be after start date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rows = Availability.AddAvailability(
                    _propertyId, dtpStart.Value.Date, dtpEnd.Value.Date);

                if (rows > 0)
                {
                    MessageBox.Show("Availability added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAvailability();
                }
                else
                {
                    MessageBox.Show("Nothing was added.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Remove button
        // Ref: UC P4.2 — Remove Availability
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int availabilityId = GetSelectedAvailabilityId();

            if (availabilityId == -1)
            {
                MessageBox.Show("Please select an availability row.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to close this availability?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                int rows = Availability.RemoveAvailability(availabilityId);

                if (rows > 0)
                {
                    MessageBox.Show("Availability closed successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAvailability();
                }
                else
                {
                    MessageBox.Show("Nothing was updated.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Close button 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
