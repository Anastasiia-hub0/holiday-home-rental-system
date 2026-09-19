
// frmAddProperty.cs — Add or Edit a property
// Ref: UC P3.1 Register Property, UC P3.2 Edit Property

using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace HolidayHomeRentalSystem
{
    public partial class frmAddProperty : Form
    {
        private int _propertyId = 0; // 0 = Add mode, > 0 = Edit mode

      
        public frmAddProperty()
        {
            InitializeComponent();
        }

        public frmAddProperty(int propertyId)
        {
            InitializeComponent();
            _propertyId = propertyId;
        }

        private void frmAddProperty_Load(object sender, EventArgs e)
        {
            // If editing, load existing property data
            if (_propertyId > 0)
                LoadPropertyData();
        }

     
        private void LoadPropertyData()
        {
            try
            {
                DataTable dt = Property.GetPropertyById(_propertyId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Property not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                // Verify ownership
                // Проверяем что залогиненный Host является владельцем этого жилья
                // Защита на случай если форма открыта с чужим PropertyID
                // Двойная защита: проверка в форме + WHERE OwnerID в SQL
                int ownerId = Convert.ToInt32(row["OWNERID"]);
                if (ownerId != CurrentUser.AccountId)
                {
                    MessageBox.Show("You are not the owner of this property.", "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                txtTitle.Text = row["TITLE"].ToString();
                txtDescription.Text = row["DESCRIPTION"].ToString();
                txtAddress.Text = row["ADDRESS"].ToString();
                txtCountry.Text = row["COUNTRY"].ToString();
                nudMaxGuests.Value = Convert.ToDecimal(row["MAXGUESTS"]);
                nudPrice.Value = Convert.ToDecimal(row["PRICE"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading property: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



       // Ref: Microsoft C# Documentation — System.Windows.Forms.OpenFileDialog
        // Allows user to browse and select an image file from their computer
        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Select a photo";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                picPhoto.ImageLocation = openFileDialog1.FileName;
        } 

        //Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Save button: Add or Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate using Property business class
            string error;

            if (!Property.ValidateTitle(txtTitle.Text, out error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (!Property.ValidateAddress(txtAddress.Text, out error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            if (!Property.ValidateCountry(txtCountry.Text, out error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCountry.Focus();
                return;
            }

            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than zero.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPrice.Focus();
                return;
            }

            if (nudMaxGuests.Value < 1)
            {
                MessageBox.Show("Max guests must be at least 1.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMaxGuests.Focus();
                return;
            }

            try
            {
                int rows;

                if (_propertyId == 0)
                {
                    // Ref: UC P3.1 — Register Property
                    rows = Property.AddProperty(
                        CurrentUser.AccountId,
                        txtTitle.Text, txtDescription.Text,
                        txtAddress.Text, txtCountry.Text,
                        nudPrice.Value, (int)nudMaxGuests.Value);

                    if (rows > 0)
                        MessageBox.Show("Property added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Ref: UC P3.2 — Edit Property
                    rows = Property.UpdateProperty(
                        _propertyId, CurrentUser.AccountId,
                        txtTitle.Text, txtDescription.Text,
                        txtAddress.Text, txtCountry.Text,
                        nudPrice.Value, (int)nudMaxGuests.Value);

                    if (rows > 0)
                        MessageBox.Show("Property updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (rows > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nothing was saved.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

 
        }
    }
}
