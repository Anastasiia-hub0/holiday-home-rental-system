
// Utility.cs — Shared helper methods for UI formatting
// Ref: Formatting a DataGridView document
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
   
    internal static class Utility
    {
        
        public static void FormatGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows  = false;
        }

      
        public static void HideColumn(DataGridView dgv, string columnName)
        {
            if (dgv.Columns[columnName] != null)
            {
                dgv.Columns[columnName].Visible = false;
            }
        }

      
        public static void SetColumnFormat(DataGridView dgv, string columnName, string format)
        {
            if (dgv.Columns[columnName] != null)
            {
                dgv.Columns[columnName].DefaultCellStyle.Format = format;
            }
        }

    
        public static void SetColumnHeader(DataGridView dgv, string columnName, string headerText)
        {
            if (dgv.Columns[columnName] != null)
            {
                dgv.Columns[columnName].HeaderText = headerText;
            }
        }
    }
}
