
// frmMainMenu.cs — Main application menu with search
// Ref: UC P2.1 Search Rental, role-based navigation

using System;
using System.Data;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent(); //создаёт все кнопки, панели, поля которые ты нарисовала в Designer
            //Вызывается автоматически когда форма открывается
        }

        // ==== Form Load ====
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            ApplyRoleUI();
        }

       
        private void ApplyRoleUI()
        {
            pnlRenter.Visible = false;
            pnlHost.Visible = false;
            pnlAdmin.Visible = false;
            plnCard.Visible = false;
            dgvResult.Visible = false;

            string role = (CurrentUser.Role ?? "").Trim();

            if (string.IsNullOrEmpty(role))
            {
                // Not signed in — show search card for browsing
                plnCard.Visible = true;
                dgvResult.Visible = true;
                return;
            }

            if (role == "Renter")
            {
                pnlRenter.Visible = true;
                pnlRenter.BringToFront();
                plnCard.Visible = true;
                dgvResult.Visible = true;
            }
            else if (role == "Host")
            {
                pnlRenter.Visible = true; 
                pnlHost.Visible = true;
                pnlHost.BringToFront();    
                plnCard.Visible = true;
                dgvResult.Visible = true;
            }
            else if (role == "Admin")
            {

                // pnlAdmin отдельная панель — не связана с pnlRenter
                // Admin видит только кнопки управления без поиска жилья
                pnlAdmin.Visible = true;
                pnlAdmin.BringToFront();
            }
        }

    
        private void mnuSignIn_Click(object sender, EventArgs e)
        {
            OpenLoginDialog();
        }

    
        private void OpenLoginDialog()
        {
            using (frmLogin frm = new frmLogin())
            {
                if (frm.ShowDialog(this) == DialogResult.OK) // ShowDialog(this) — открывает форму как модальное дочернее окно
                                                             // this = frmMainMenu является родительской формой
                                                             // Пользователь не может кликнуть на главное меню пока frmLogin открыта
                    ApplyRoleUI();
            }
        }

        private void mnuCreateAcc_Click(object sender, EventArgs e)
        {
            using (frmRegisterAccount frm = new frmRegisterAccount())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }


        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Close();
        }

     
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter a city or country.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Передаём значения из контролов формы в метод класса
                // .Text — для TextBox (строка)
                // .Value.Date — для DateTimePicker (только дата без времени)
                // (int).Value — для NumericUpDown (конвертируем decimal в int)

                DataTable dt = Property.SearchAvailable(
                    txtLocation.Text.Trim(),
                    dtpCheckIn.Value.Date,
                    dtpCheckOut.Value.Date,
                    (int)nudGuests.Value);

                dgvResult.DataSource = dt;

                // Format the results grid
                Utility.FormatGrid(dgvResult);
                Utility.HideColumn(dgvResult, "PROPERTYID");
                Utility.SetColumnFormat(dgvResult, "PRICE", "C2");// Utility.FormatGrid — базовое форматирование грида (ReadOnly, FullRowSelect)
                                                                  // Utility.HideColumn — скрываем PROPERTYID от пользователя (нужен только программе)
                                                                  // Utility.SetColumnFormat — форматируем цену как валюту €120.00
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {       
            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);

            if (dtpCheckOut.Value < dtpCheckOut.MinDate)
                dtpCheckOut.Value = dtpCheckOut.MinDate;
        }


        // Срабатывает при двойном клике на строку грида
        // e.RowIndex < 0 — клик на заголовок → игнорируем
        // Берём скрытый PROPERTYID из выбранной строки
        // Передаём ID + даты + гостей в frmPropertyDetails
        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Ref: C# Book Section 2.2 "Manipulating Data" — Type Conversion
            int propertyId = Convert.ToInt32(
                dgvResult.Rows[e.RowIndex].Cells["PROPERTYID"].Value);

            using (frmPropertyDetails frm = new frmPropertyDetails(
                propertyId, dtpCheckIn.Value.Date, dtpCheckOut.Value.Date, (int)nudGuests.Value))
            {
                frm.ShowDialog(this);
            }
        }


      
      
        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsLoggedIn)
            {
                MessageBox.Show("Please sign in first.", "Not Signed In",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmMyBookings frm = new frmMyBookings())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        
        private void btnAccountDetails_Click(object sender, EventArgs e)
        {
            OpenAccountDetails();
        }

   
        private void btnMyProperties_Click(object sender, EventArgs e)
        {
            using (frmMyProperties frm = new frmMyProperties())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

      
        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            using (frmAddProperty frm = new frmAddProperty())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            using (frmManageAccounts frm = new frmManageAccounts())
            {
                frm.ShowDialog(this);
            }
        }

    
        private void btnBookingAnalysis_Click(object sender, EventArgs e)
        {
            using (frmBookingAnalysis frm = new frmBookingAnalysis())
            {
                frm.ShowDialog(this);
            }
        }

    
        private void btnRevenueAnalysis_Click(object sender, EventArgs e)
        {
            using (frmRevenueAnalysis frm = new frmRevenueAnalysis())
            {
                frm.ShowDialog(this);
            }
        }

   
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            PerformSignOut();
        }

        private void btnSign_Out_Click(object sender, EventArgs e)
        {
            PerformSignOut();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            PerformSignOut();
        }

      
        private void PerformSignOut()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to sign out?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            CurrentUser.Clear();
            ApplyRoleUI();

            MessageBox.Show("Signed out successfully.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void OpenAccountDetails()
        {
            using (frmViewAccount frm = new frmViewAccount())
            {
                DialogResult result = frm.ShowDialog(this);

               
                if (result == DialogResult.Abort) // DialogResult.Abort — специальный сигнал что пользователь деактивировал аккаунт
                                                  // OK и Cancel уже используются для других действий
                                                  // При получении Abort → обновляем UI через ApplyRoleUI()
                    ApplyRoleUI();
            }
        }
        private void btnHostAccountDetails_Click_1(object sender, EventArgs e)
        {
            OpenAccountDetails();
        } // Кнопка Account Details для Host
          // _1 в названии потому что btnAccountDetails_Click уже существует для Renter
          // Оба вызывают один метод OpenAccountDetails()
    }
}
