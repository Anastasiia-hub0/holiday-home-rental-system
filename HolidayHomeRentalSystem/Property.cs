
// Property.cs — Business object for the Properties entity
// Ref: UC P3.1 Register, P3.2 Edit, P3.3 View, P3.4 Remove

using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HolidayHomeRentalSystem
{
 
    public class Property
    {
        // ---- Auto-properties ----
        public int PropertyId  { get; set; }
        public int OwnerId  { get; set; }
        public string  Title { get; set; }
        public string  Description { get; set; }
        public string  Address { get; set; }
        public string  Country { get; set; }
        public int MaxGuests { get; set; }
        public decimal Price { get; set; }
        public string  Status { get; set; }

        // ---- No-argument constructor ----
        public Property() : this(0, 0, "", "", "", "", 1, 0m, "Active")
        {
        }

        // ---- Multi-argument constructor ----
        public Property(int propertyId, int ownerId, string title,
                        string description, string address, string country,
                        int maxGuests, decimal price, string status)
        {
            PropertyId = propertyId;
            OwnerId = ownerId;
            Title = title;
            Description = description;
            Address= address;
            Country= country;
            MaxGuests = maxGuests;
            Price = price;
            Status = status;
        }

        // ---- ToString ----
        public override string ToString()
        {
            return "PropertyID: " + PropertyId +
                   "\tTitle: " + Title +
                   "\tCountry: " + Country +
                   "\tPrice: " + Price +
                   "\tGuests: " + MaxGuests;
        }

       
        //  VALIDATION METHODS  (Ref: UC P3.1 — Register Property)
        
     
        public static bool ValidateTitle(string title, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(title))
            {
                error = "Title is required.";
                return false;
            }

            if (title.Length > 60)
            {
                error = "Title must not exceed 60 characters.";
                return false;
            }

            return true;
        }

        public static bool ValidateAddress(string address, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(address))
            {
                error = "Address is required.";
                return false;
            }

            if (address.Length > 100)
            {
                error = "Address must not exceed 100 characters.";
                return false;
            }

            return true;
        }

       
        public static bool ValidateCountry(string country, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(country))
            {
                error = "Country is required.";
                return false;
            }

            return true;
        }

        public static int AddProperty(int ownerId, string title, string description,
            string address, string country, decimal price, int maxGuests)
        {
            string sql = @"
                INSERT INTO Properties
                    (PropertyID, OwnerID, Title, Description, Address, Country, Price, MaxGuests, Status)
                VALUES
                    (SEQ_PROPERTIES.NEXTVAL, :oid, :title, :descr, :addr, :country, :price, :maxg, 'Active')";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("oid", ownerId),
                new OracleParameter("title", title.Trim()),
                new OracleParameter("descr", string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description.Trim()),
                new OracleParameter("addr",address.Trim()),
                new OracleParameter("country", country.Trim()),
                new OracleParameter("price", price),
                new OracleParameter("maxg", maxGuests));
        }

     
        public static int UpdateProperty(int propertyId, int ownerId, string title,
            string description, string address, string country, decimal price, int maxGuests)
        {
            string sql = @"
                UPDATE Properties
                SET Title = :title,
                    Description = :descr,
                    Address = :addr,
                    Country = :country,
                    Price = :price,
                    MaxGuests = :maxg
                WHERE PropertyID = :pid
                  AND OwnerID = :aid";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("title", title.Trim()),
                new OracleParameter("descr", string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description.Trim()),
                new OracleParameter("addr", address.Trim()),
                new OracleParameter("country", country.Trim()),
                new OracleParameter("price", price),
                new OracleParameter("maxg", maxGuests),
                new OracleParameter("pid", propertyId),
                new OracleParameter("aid", ownerId));
        }

        
        public static int RemoveProperty(int propertyId, int ownerId)
        {
            string sql = @"
                UPDATE Properties
                SET Status = 'Inactive'
                WHERE PropertyID = :pid AND OwnerID = :aid";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("pid", propertyId),
                new OracleParameter("aid", ownerId));
        }

     
        public static DataTable GetPropertyById(int propertyId)
        {
            string sql = @"
                SELECT PropertyID, OwnerID, Title, Description, Address,
                       Country, MaxGuests, Price, Status
                FROM Properties
                WHERE PropertyID = :pid";

            return Database.ExecuteQuery(sql,
                new OracleParameter("pid", propertyId));
        }

        
        public static DataTable GetPropertiesByOwner(int ownerId)
        {
            string sql = @"
                SELECT PropertyID, Title, Country, Price, MaxGuests, Status
                FROM Properties
                WHERE OwnerID = :aid
                ORDER BY PropertyID";

            return Database.ExecuteQuery(sql,
                new OracleParameter("aid", ownerId));
        }

     
        public static DataTable SearchAvailable(string location, DateTime checkIn,
            DateTime checkOut, int guests)
        {
            string sql = @"
                SELECT p.PropertyID, p.Title, p.Country, p.MaxGuests, p.Price
                FROM Properties p
                JOIN Availabilities a ON a.PropertyID = p.PropertyID
                WHERE p.Status = 'Active'
                  AND a.Status = 'Open'
                  AND LOWER(p.Country) LIKE LOWER(:country)
                  AND p.MaxGuests >= :guests
                  AND a.StartDate <= :checkIn
                  AND a.EndDate  >= :checkOut
                ORDER BY p.Price";

            return Database.ExecuteQuery(sql,
                new OracleParameter("country", "%" + location.Trim() + "%"),
                new OracleParameter("guests", guests),
                new OracleParameter("checkIn", checkIn),
                new OracleParameter("checkOut", checkOut));
        }
    }
}
