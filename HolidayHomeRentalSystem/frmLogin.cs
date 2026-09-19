
// frmLogin.cs — Login form
// Ref: UC AC-01

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmLogin : Form
    {
       
        private readonly Color PlaceholderColor = Color.Silver;
        private readonly Color NormalColor = Color.Black;

        public frmLogin()
        {
            InitializeComponent();

            // Attach placeholder handlers
            txtEmail.Enter += Txt_Enter;
            txtPassword.Enter += Txt_Enter;
            txtEmail.Leave += Txt_Leave;
            txtPassword.Leave += Txt_Leave;
        }

        // ---- Placeholder logic ----
        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox; //as means casting 
            if (txt == null) return;

            txt.ForeColor = NormalColor;

            if (txt.Text == "Email" || txt.Text == "Password")
                txt.Text = "";

            if (txt == txtPassword)
                txt.UseSystemPasswordChar = true;
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;
            if (!string.IsNullOrWhiteSpace(txt.Text)) return;

            txt.ForeColor = PlaceholderColor;

            if (txt == txtEmail)
            {
                txt.Text = "Email";
            }
            else if (txt == txtPassword)
            {
                txt.UseSystemPasswordChar = false;
                txt.Text = "Password";
            }
        }

        // Create Account button 
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            using (frmRegisterAccount frm = new frmRegisterAccount())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        // Sign In button 
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Email")
            {
                MessageBox.Show("Please enter your email.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Password")
            {
                MessageBox.Show("Please enter your password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                // Use the Account business class for login
                DataTable dt = Account.Login(txtEmail.Text.Trim(), txtPassword.Text);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = dt.Rows[0];
                string status = row["STATUS"].ToString().Trim();

                if (status != "Active")
                {
                    MessageBox.Show("Your account is not active. Please contact the administrator.",
                        "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
//                Бизнес - логика проверки: if (status != "Active")
//                    Требование проекта: Согласно твоей спецификации(Requirements Engineering), все пользователи при регистрации получают статус Active
//                    .
//Запрет входа: Если пользователь решил удалить аккаунт(Unregister), система не удаляет запись физически, а меняет её статус на Inactive или Removed
//.
//Результат: Твой код проверяет это бизнес - правило: если статус в базе данных любой другой, кроме "Active", программа выдает предупреждение и прерывает процесс входа(return), не пуская пользователя в систему

                // Set session
                CurrentUser.AccountId = Convert.ToInt32(row["ACCOUNT_ID"]);
                CurrentUser.FirstName = row["FIRST_NAME"].ToString().Trim();
                CurrentUser.Role = row["ROLE"].ToString().Trim();
                CurrentUser.Email = txtEmail.Text.Trim();

           
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
