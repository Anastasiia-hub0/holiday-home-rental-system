
// frmRegisterAccount.cs — Register a new user account
// Ref: UC AC-01 — Register Account

using System;
using System.Drawing;
using System.Windows.Forms;

namespace HolidayHomeRentalSystem
{
    public partial class frmRegisterAccount : Form
    {

        // Ref: Microsoft C# Documentation — System.Drawing.Color
        // Silver colour for placeholder text, Black for normal input

        private readonly Color PlaceholderColor = Color.Silver;
        private readonly Color NormalColor = Color.Black;

        public frmRegisterAccount()
        {
            InitializeComponent();

            // Attach placeholder handlers for text fields
            txtFirstName.Enter += Txt_Enter;
            txtLastName.Enter += Txt_Enter;
            txtEmail.Enter += Txt_Enter;
            txtPhone.Enter += Txt_Enter;
            txtPassword.Enter += Txt_Enter;
            txtConfirmPassword.Enter += Txt_Enter;

            txtFirstName.Leave += Txt_Leave;
            txtLastName.Leave += Txt_Leave;
            txtEmail.Leave += Txt_Leave;
            txtPhone.Leave += Txt_Leave;
            txtPassword.Leave += Txt_Leave;
            txtConfirmPassword.Leave += Txt_Leave;
        }

      
        private void frmRegisterAccount_Load(object sender, EventArgs e)
        {
            cboRole.Items.Clear();
            cboRole.Items.Add("Renter");
            cboRole.Items.Add("Host");
            cboRole.Items.Add("Admin");
            cboRole.SelectedIndex = -1; // SelectedIndex = -1 — ничего не выбрано по умолчанию. Пользователь сам должен выбрать!

        }


        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            txt.ForeColor = NormalColor;

            if (txt.Text == "First Name" || txt.Text == "Last Name" ||
                txt.Text == "Email" || txt.Text == "Phone" ||
                txt.Text == "Password" || txt.Text == "Confirm Password")
            {
                txt.Text = "";
            }

            if (txt == txtPassword || txt == txtConfirmPassword)
                txt.UseSystemPasswordChar = true;
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;
            if (!string.IsNullOrWhiteSpace(txt.Text)) return;

            txt.ForeColor = PlaceholderColor;

            if (txt == txtFirstName) txt.Text = "First Name";
            else if (txt == txtLastName) txt.Text = "Last Name";
            else if (txt == txtEmail) txt.Text = "Email";
            else if (txt == txtPhone) txt.Text = "Phone";
            else if (txt == txtPassword) { txt.UseSystemPasswordChar = false; txt.Text = "Password"; }
            else if (txt == txtConfirmPassword) { txt.UseSystemPasswordChar = false; txt.Text = "Confirm Password"; }
        }

        // GetFieldValue нужен потому что 6 полей с placeholder
        // Проверяет цвет И текст — если placeholder → вернуть ""
        // Избегает дублирования одного и того же кода для каждого поля
        private string GetFieldValue(TextBox txt, string placeholder)
        {
            if (txt.ForeColor == PlaceholderColor || txt.Text == placeholder)
                return "";

            return txt.Text.Trim();
        }
//        // Для каждого поля отдельно:
//if (txtFirstName.ForeColor == PlaceholderColor || txtFirstName.Text == "First Name")
//    firstName = "";
//else
//    firstName = txtFirstName.Text.Trim();

//if (txtLastName.ForeColor == PlaceholderColor || txtLastName.Text == "Last Name")
//    lastName = "";
//else
//    lastName = txtLastName.Text.Trim();

//// И так для каждого из 6 полей!

        private bool ValidateForm()
        {
            errProvider.Clear();
            bool valid = true;
            string error;
            // string error — пустая переменная
            // Account.Validate*() заполняет её текстом ошибки через out
            // errProvider.SetError() показывает этот текст рядом с полем


            if (!Account.ValidateName(GetFieldValue(txtFirstName, "First Name"), out error))
            {
                errProvider.SetError(txtFirstName, error);
                valid = false;
            }

            
            if (!Account.ValidateName(GetFieldValue(txtLastName, "Last Name"), out error))
            {

                // ErrorProvider — displays validation error icons next to controls
                // Ref: Microsoft C# Documentation — System.Windows.Forms.ErrorProvider
                errProvider.SetError(txtLastName, error);
                valid = false;
            }

          
            string emailValue = GetFieldValue(txtEmail, "Email");
            if (!Account.ValidateEmail(emailValue, out error))
            {
                errProvider.SetError(txtEmail, error);
                valid = false;
            }

           
            string passwordValue = GetFieldValue(txtPassword, "Password");
            if (!Account.ValidatePassword(passwordValue, out error))
            {
                errProvider.SetError(txtPassword, error);
                MessageBox.Show(error, "Password Rules",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }

            // Confirm Password (Ref: UC AC-01 Step 6 — passwords must match)
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errProvider.SetError(txtConfirmPassword, "Passwords do not match.");
                valid = false;
            }

            // Role (Ref: UC AC-01 )
            if (cboRole.SelectedIndex == -1)
            {
                errProvider.SetError(cboRole, "Please select a role.");
                valid = false;
            }

            // Phone — optional, digits only
            string phoneValue = GetFieldValue(txtPhone, "Phone (Optional)");
            if (!Account.ValidatePhone(phoneValue, out error))
            {
                errProvider.SetError(txtPhone, error);
                valid = false;
            }

            return valid;
        }

        // Create Account button
        // Ref: UC AC-01 Steps 6-10
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string email = GetFieldValue(txtEmail, "Email");
            // GetFieldValue нужен чтобы не взять placeholder "Email" вместо реального значения
            // Если поле серое → вернёт "" → ValidateForm поймает ошибку
            // Если поле чёрное → вернёт реальный email

            try
            {
                // Ref: UC AC-01 Step 6 — Email must not already exist
                if (Account.EmailExists(email))
                {
                    MessageBox.Show("This email is already registered. Please use a different email.",
                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Ref: UC AC-01 Steps 7-8 — Assign defaults and save
                Account.RegisterAccount(
                    GetFieldValue(txtFirstName, "First Name"),
                    GetFieldValue(txtLastName, "Last Name"),
                    email,
                    GetFieldValue(txtPhone, "Phone (Optional)"),
                    txtPassword.Text,
                    cboRole.Text);

                // Ref: UC AC-01 Step 9 — Confirmation message
                MessageBox.Show("Account has been created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ref: UC AC-01 Step 10 — Reset UI
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating account: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "First Name";
            txtLastName.Text = "Last Name";
            txtEmail.Text = "Email";
            txtPhone.Text = "Phone";
            txtPassword.Text = "Password";
            txtConfirmPassword.Text = "Confirm Password";

            txtFirstName.ForeColor = PlaceholderColor;
            txtLastName.ForeColor = PlaceholderColor;
            txtEmail.ForeColor = PlaceholderColor;
            txtPhone.ForeColor = PlaceholderColor;
            txtPassword.ForeColor = PlaceholderColor;
            txtConfirmPassword.ForeColor = PlaceholderColor;

            txtPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.UseSystemPasswordChar = false;

            cboRole.SelectedIndex = -1;
            errProvider.Clear();
        }

        // ==== Cancel button ====
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
