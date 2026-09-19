
// frmMyProperties.cs — Host's property list with Edit/Remove/Availability
// Ref: UC P3.2 Edit, P3.4 Remove, P4.1/P4.2 Manage Availability
using System;
using System.Data;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmMyProperties : Form
    {
        public frmMyProperties()
        {
            InitializeComponent();
        }

        //Form Load
        private void frmMyProperties_Load(object sender, EventArgs e)
        {
            Utility.FormatGrid(dgvMyProps);
            LoadMyProperties();
        }

     
        private void LoadMyProperties()
        {
            if (!CurrentUser.IsLoggedIn)
            {
                MessageBox.Show("You must sign in first.", "Not Signed In",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = Property.GetPropertiesByOwner(CurrentUser.AccountId);

                // DataSource автоматически создаёт колонки и строки из DataTable
                // Грид сам отображает все данные из Oracle
                // После этого прячем служебные колонки и форматируем вид
                dgvMyProps.DataSource = dt;

                Utility.HideColumn(dgvMyProps, "PROPERTYID");
                Utility.SetColumnFormat(dgvMyProps, "PRICE", "C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading properties: " + ex.Message, "Error",

                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Вспомогательный метод — используется в Edit, Remove и Availability кнопках
        // Избегает дублирования кода в трёх местах
        // Возвращает -1 если ничего не выбрано
        // Возвращает реальный PropertyID если строка выбрана
        private int GetSelectedPropertyId()
        {
            if (dgvMyProps.CurrentRow == null)
                return -1;

            return Convert.ToInt32(dgvMyProps.CurrentRow.Cells["PROPERTYID"].Value);
        }

        //Edit button
        // Ref: UC P3.2 — Edit Property
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int propertyId = GetSelectedPropertyId();

            // Возвращаем -1 если строка не выбрана
            // -1 используется как сигнал "ничего не выбрано"
            // 0 нельзя использовать — он означает Add mode в frmAddProperty
            if (propertyId == -1)
            {
                MessageBox.Show("Please select a property.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmAddProperty frm = new frmAddProperty(propertyId))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadMyProperties(); // refresh after edit
            }
        }

        //Remove button
        // Ref: UC P3.4 — Remove Property (set Status to Inactive)
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int propertyId = GetSelectedPropertyId();

            if (propertyId == -1)
            {
                MessageBox.Show("Please select a property.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to remove this property?",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                int rows = Property.RemoveProperty(propertyId, CurrentUser.AccountId);

                if (rows > 0)
                {
                    MessageBox.Show("Property removed successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMyProperties();
                }
                else
                {
                    MessageBox.Show("Remove failed. This property may not belong to you.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Manage Availability button
        // Ref: UC P4.1, P4.2
        private void btnAvailabiliies_Click(object sender, EventArgs e)
        {
            int propertyId = GetSelectedPropertyId();

            if (propertyId == -1)
            {
                MessageBox.Show("Please select a property.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmManageAvailability frm = new frmManageAvailability(propertyId))
            {
                frm.ShowDialog(this);
            }
        }

        //Close button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
