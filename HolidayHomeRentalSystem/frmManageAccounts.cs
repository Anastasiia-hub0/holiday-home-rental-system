
// frmManageAccounts.cs — Admin manages user accounts (role/status)
// Ref: UC P5.1 — Manage Accounts
using System;
using System.Data;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmManageAccounts : Form
    {
        public frmManageAccounts()
        {
            InitializeComponent();
        }

        private void frmManageAccounts_Load(object sender, EventArgs e)
        {
            Utility.FormatGrid(dgvAccounts);

            // Populate combo boxes
            cboRole.Items.Clear();
            cboRole.Items.Add("Renter");
            cboRole.Items.Add("Host");
            cboRole.Items.Add("Admin");

            cboStatus.Items.Clear();
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Inactive");

            LoadAccounts();
        }

        ///Loads all accounts into the grid
        private void LoadAccounts()
        {
            try
            {
                DataTable dt = Account.GetAllAccounts();
                dgvAccounts.DataSource = dt;

                Utility.SetColumnHeader(dgvAccounts, "ACCOUNT_ID", "ID");
                Utility.SetColumnHeader(dgvAccounts, "FIRST_NAME", "First Name");
                Utility.SetColumnHeader(dgvAccounts, "LAST_NAME", "Last Name");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedAccountId()
        {
            if (dgvAccounts.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dgvAccounts.CurrentRow.Cells["ACCOUNT_ID"].Value);
        }

        private void btnLoadSelected_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow == null)
            {
                MessageBox.Show("Please select an account.", "Validation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = dgvAccounts.CurrentRow.Cells["ROLE"].Value.ToString().Trim();
            string status = dgvAccounts.CurrentRow.Cells["STATUS"].Value.ToString().Trim();

            cboRole.SelectedItem = role;
            cboStatus.SelectedItem = status;

            if (cboRole.SelectedIndex == -1) cboRole.Text = role;
            if (cboStatus.SelectedIndex == -1) cboStatus.Text = status;
        }

        // Update button: save new role/status
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int accountId = GetSelectedAccountId();

            if (accountId == -1)
            {
                MessageBox.Show("Please select an account.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cboRole.Text))
            {
                MessageBox.Show("Please select a role.", "Validation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cboStatus.Text))
            {
                MessageBox.Show("Please select a status.", "Validation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rows = Account.AdminUpdateAccount(accountId, cboRole.Text, cboStatus.Text);

                if (rows > 0)
                {
                    MessageBox.Show("Account updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                }
                else
                {
                    MessageBox.Show("Nothing was updated.", "Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating account: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---- Close button ----
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
