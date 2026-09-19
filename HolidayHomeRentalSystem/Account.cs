
// Account.cs — Business object for the Accounts entity
// Ref: UC AC-01 Register, AC-02 Update, AC-03 Unregister

using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HolidayHomeRentalSystem
{
    public class Account
    {
        public int  AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime DateRegistered { get; set; }

        //No-argument constructor
        public Account() : this(0, "", "", "", "", "", "Renter", "Active", DateTime.Now)
        {
        }

        //Multi-argument constructor
        public Account(int accountId, string firstName, string lastName,
                       string email, string phone, string password,
                       string role, string status, DateTime dateRegistered)
        {
            AccountId = accountId;
            FirstName = firstName;
            LastName= lastName;
            Email= email;
            Phone= phone;
            Password= password;
            Role= role;
            Status= status;
            DateRegistered = dateRegistered;
        }

      
      
        public override string ToString()
        {
            return "Account ID: " + AccountId +
                   "\tName: " + FirstName + " " + LastName +
                   "\tEmail: " + Email +
                   "\tRole: " + Role +
                   "\tStatus: " + Status;
        }


        //  VALIDATION METHODS  (Ref: UC AC-01 Step 6)

        // 'out' parameter allows method to return both bool result AND error message
        // Ref: C# Book Section 3.3 "Passing Parameters"
        public static bool ValidateName(string name, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name is required.";
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '\'')
                {
                    error = "Name must contain only letters, spaces, hyphens or apostrophes.";
                    return false;
                }
            }

            if (name.Length > 30)
            {
                error = "Name must not exceed 30 characters.";
                return false;
            }

            return true;
        }

        public static bool ValidateEmail(string email, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(email))
            {
                error = "Email is required.";
                return false;
            }

            int atIndex = email.IndexOf('@');
            if (atIndex <= 0 || atIndex >= email.Length - 1)
            {
                error = "Email must contain '@' with text before and after it.";
                return false;
            }

            string domainPart = email.Substring(atIndex + 1);
            if (!domainPart.Contains("."))
            {
                error = "Email domain must contain a '.' (e.g. example.com).";
                return false;
            }

            if (email.Length > 40)
            {
                error = "Email must not exceed 40 characters.";
                return false;
            }

            return true;
        }


        /// Validates password strength (Ref: UC AC-01 Business Rules).
        /// At least 8 chars, 1 uppercase, 1 digit, 1 underscore.

        public static bool ValidatePassword(string password, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(password))
            {
                error = "Password is required.";
                return false;
            }

            string issues = "";

            if (password.Length < 8)
                issues += "- at least 8 characters\n";

            // Ref: C# Book Section 4.11.8 — char.IsUpper, char.IsLetter, char.IsDigit
            bool hasUpper = false;
            bool hasLetter = false;
            bool hasDigit = false;
            bool hasUnderscore = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLetter(c)) hasLetter = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (c == '_') hasUnderscore = true;
            }

            if (!hasUpper)
                issues += "- at least 1 uppercase letter (A-Z)\n";

            if (!hasLetter)
                issues += "- at least 1 letter\n";

            if (!hasDigit)
                issues += "- at least 1 digit (0-9)\n";

            if (!hasUnderscore)
                issues += "- at least 1 underscore (_)\n";

            if (issues != "")
            {
                error = "Password must contain:\n" + issues;
                return false;
            }

            return true;
        }

        ///Validates phone number — digits only, optional.
        public static bool ValidatePhone(string phone, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(phone))
                return true; // phone is optional

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    error = "Phone must contain only digits.";
                    return false;
                }
            }

            if (phone.Length > 30)
            {
                error = "Phone must not exceed 30 characters.";
                return false;
            }

            return true;
        }
       
        /// Checks whether an email already exists in the Accounts table.
        /// Ref: UC AC-01 Step 6 — "Email must not already exist".

        public static bool EmailExists(string email)
        {
            string sql = "SELECT COUNT(*) FROM Accounts WHERE LOWER(Email) = LOWER(:em)";
            object result = Database.ExecuteScalar(sql,
                new OracleParameter("em", email.Trim()));

            return Convert.ToInt32(result) > 0;
        }

   
        /// Registers a new account.
        /// Ref: UC AC-01 — Register Account.
      
        public static int RegisterAccount(string firstName, string lastName,
            string email, string phone, string password, string role)
        {
            string sql = @"
                INSERT INTO Accounts
                    (Account_ID, First_Name, Last_Name, Email, Phone, Password,
                     Role, Status, Date_Registered)
                VALUES
                    (SEQ_ACCOUNTS.NEXTVAL, :fn, :ln, :em, :ph, :pw,
                     :rl, 'Active', SYSDATE)";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("fn", firstName.Trim()),
                new OracleParameter("ln", lastName.Trim()),
                new OracleParameter("em", email.Trim()),
                new OracleParameter("ph", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone.Trim()),
                new OracleParameter("pw", password),
                new OracleParameter("rl", role));
        }

       
        /// Loads account data for a given Account_ID.
        /// Ref: UC AC-02 — Update Account (load step).
       
        public static DataTable GetAccountById(int accountId)
        {
            string sql = @"
                SELECT Account_ID, First_Name, Last_Name, Email, Phone,
                       Role, Status, Date_Registered
                FROM Accounts
                WHERE Account_ID = :aid";

            return Database.ExecuteQuery(sql,
                new OracleParameter("aid", accountId));
        }

   
        /// Updates the profile fields of an account (name, phone, email).
        /// Ref: UC AC-02 — Update Account.

        public static int UpdateAccount(int accountId, string firstName, string lastName,
            string email, string phone)
        {
            string sql = @"
                UPDATE Accounts
                SET First_Name = :fn,
                    Last_Name = :ln,
                    Email = :em,
                    Phone = :ph
                WHERE Account_ID = :aid";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("fn",  firstName.Trim()),
                new OracleParameter("ln",  lastName.Trim()),
                new OracleParameter("em",  email.Trim()),
                new OracleParameter("ph",  string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone.Trim()),
                new OracleParameter("aid", accountId));
        }

      
        /// Deactivates an account (sets Status to 'Inactive').
        /// Ref: UC AC-03 — Unregister Account.
       
        public static int UnregisterAccount(int accountId)
        {
            string sql = @"
                UPDATE Accounts
                SET Status = 'Inactive'
                WHERE Account_ID = :aid";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("aid", accountId));
        }

        /// Returns all accounts (for Admin — Manage Accounts).
        /// Ref: UC P5.1 — Manage Accounts.
       
        public static DataTable GetAllAccounts()
        {
            string sql = @"
                SELECT Account_ID, First_Name, Last_Name, Email, Phone,
                       Role, Status, Date_Registered
                FROM Accounts
                ORDER BY Account_ID";

            return Database.ExecuteQuery(sql);
        }

       
        /// Admin updates role and status for a given account.
        /// Ref: UC P5.1 — Manage Accounts (Admin).
     
        public static int AdminUpdateAccount(int accountId, string role, string status)
        {
            string sql = @"
                UPDATE Accounts
                SET Role = :rl,
                    Status = :st
                WHERE Account_ID = :aid";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("rl", role.Trim()),
                new OracleParameter("st", status.Trim()),
                new OracleParameter("aid", accountId));
        }

        
        /// Checks email + password for login. Returns a DataTable with
        /// Account_ID, Role, Status, First_Name if credentials match.
       
        public static DataTable Login(string email, string password)
        {
            string sql = @"
                SELECT Account_ID, First_Name, Role, Status
                FROM Accounts
                WHERE Email = :em AND Password = :pw";

            return Database.ExecuteQuery(sql,
                new OracleParameter("em", email.Trim()),
                new OracleParameter("pw", password));
        }

        
        /// Checks if an email belongs to a different account (for update uniqueness check).
       
        public static bool EmailExistsForOther(string email, int excludeAccountId)
        {
            string sql = @"
                SELECT COUNT(*) FROM Accounts
                WHERE LOWER(Email) = LOWER(:em) AND Account_ID <> :aid";

            object result = Database.ExecuteScalar(sql,
                new OracleParameter("em",  email.Trim()),
                new OracleParameter("aid", excludeAccountId));

            return Convert.ToInt32(result) > 0;
        }
    }
}
