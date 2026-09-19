
// CurrentUser.cs — Holds the currently logged-in user session

using System;

namespace HolidayHomeRentalSystem
{
    internal static class CurrentUser
    {
        public static int AccountId { get; set; }
        public static string FirstName { get; set; }
        public static string Role { get; set; }
        public static string Email { get; set; }

       
        public static bool IsLoggedIn
        {
            get { return AccountId > 0; }
        }

       
        public static void Clear()
        {
            AccountId = 0;
            FirstName = "";
            Role = "";
            Email = "";
        }
    }
}
