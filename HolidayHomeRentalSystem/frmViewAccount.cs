
// frmViewAccount.cs — View, Update and Unregister own account
// Ref: UC AC-02 Update Account, UC AC-03 Unregister Account

using System;
using System.Data;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmViewAccount : Form
    {
        public frmViewAccount()
        {
            InitializeComponent();
        }

        //Form Load: populate fields with current account data
        private void frmViewAccount_Load(object sender, EventArgs e)
        {
            LoadAccountData();
        }


        private void LoadAccountData()
        {
            try
            {
                DataTable dt = Account.GetAccountById(CurrentUser.AccountId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Account not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = dt.Rows[0];

                txtFirstName.Text = row["FIRST_NAME"].ToString().Trim();
                txtLastName.Text = row["LAST_NAME"].ToString().Trim();
                txtEmail.Text = row["EMAIL"].ToString().Trim();
                txtPhone.Text = row["PHONE"] == DBNull.Value ? "" : row["PHONE"].ToString().Trim();

                // Read-only fields
                txtRole.Text = row["ROLE"].ToString().Trim();
                txtStatus.Text = row["STATUS"].ToString().Trim();
                txtDateRegistered.Text = Convert.ToDateTime(row["DATE_REGISTERED"]).ToString("dd-MMM-yyyy");

                // Role, Status and Date are display-only
                txtRole.ReadOnly = true;
                txtStatus.ReadOnly = true;
                txtDateRegistered.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading account: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Save button: update editable profile fields
        // Ref: UC AC-02 — Update Account
        private void btnSave_Click(object sender, EventArgs e)
        {
            string error;

            // Validate First Name
            if (!Account.ValidateName(txtFirstName.Text, out error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            // Validate Last Name
            if (!Account.ValidateName(txtLastName.Text, out error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }

            // Validate Email
            if (!Account.ValidateEmail(txtEmail.Text, out error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validate Phone (optional)
            if (!Account.ValidatePhone(txtPhone.Text, out error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // Check email uniqueness (exclude own account)
            if (Account.EmailExistsForOther(txtEmail.Text, CurrentUser.AccountId))
            {
                MessageBox.Show("This email is already used by another account.",
                    "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                int rows = Account.UpdateAccount(
                    CurrentUser.AccountId,
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtEmail.Text,
                    txtPhone.Text);

                if (rows > 0)
                {
                    // Update session email in case it changed
                    CurrentUser.Email = txtEmail.Text.Trim();
                    CurrentUser.FirstName = txtFirstName.Text.Trim();

                    MessageBox.Show("Account updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No changes were saved.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating account: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Unregister button: deactivate own account
        // Ref: UC AC-03 — Unregister Account
        private void btnUnregister_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to deactivate your account?\n" +
                "You will be signed out and will no longer be able to log in.",
                "Confirm Unregister",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                int rows = Account.UnregisterAccount(CurrentUser.AccountId);

                if (rows > 0)
                {
                    MessageBox.Show("Your account has been deactivated.", "Unregistered",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear session
                    CurrentUser.Clear();

                    this.DialogResult = DialogResult.Abort; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Could not deactivate account.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
