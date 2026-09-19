
// Availability.cs — Business object for the Availabilities entity
// Ref: UC P4.1 Add Availability, P4.2 Remove Availability

using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HolidayHomeRentalSystem
{
    /// Represents an availability slot for a property.

    public class Availability
    {
        // Auto-properties
        public int      AvailabilityId { get; set; }
        public int      PropertyId     { get; set; }
        public DateTime StartDate      { get; set; }
        public DateTime EndDate        { get; set; }
        public string   Status         { get; set; }

        //No-argument constructor 
        public Availability() : this(0, 0, DateTime.Today, DateTime.Today.AddDays(1), "Open")
        {
        }

        // Multi-argument constructor
        public Availability(int availabilityId, int propertyId,
                            DateTime startDate, DateTime endDate, string status)
        {
            AvailabilityId = availabilityId;
            PropertyId = propertyId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        //  ToString
        public override string ToString()
        {
            return "AvailabilityID: " + AvailabilityId +
                   "\tProperty: " + PropertyId +
                   "\t" + StartDate.ToShortDateString() + " – " + EndDate.ToShortDateString() +
                   "\tStatus: " + Status;
        }

      
        /// Returns all availability slots for a property.
        /// Ref: UC P4.1/P4.2 — Manage Availability.
     
        public static DataTable GetByProperty(int propertyId)
        {
            string sql = @"
                SELECT AvailabilityID, StartDate, EndDate, Status
                FROM Availabilities
                WHERE PropertyID = :pid
                ORDER BY StartDate";

            return Database.ExecuteQuery(sql,
                new OracleParameter("pid", propertyId));
        }
        /// Adds a new availability period. Ref: UC P4.1 — Add Availability.
     
        public static int AddAvailability(int propertyId, DateTime startDate, DateTime endDate)
        {
            string sql = @"
                INSERT INTO Availabilities
                    (AvailabilityID, PropertyID, StartDate, EndDate, Status)
                VALUES
                    (SEQ_AVAILABILITIES.NEXTVAL, :pid, :sdate, :edate, 'Open')";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("pid",   propertyId),
                new OracleParameter("sdate", startDate),
                new OracleParameter("edate", endDate));
        }

    
        /// Closes an availability slot. Ref: UC P4.2 — Remove Availability.
   
        public static int RemoveAvailability(int availabilityId)
        {
            string sql = @"
                UPDATE Availabilities
                SET Status = 'Closed'
                WHERE AvailabilityID = :aid";

            return Database.ExecuteNonQuery(sql,
                new OracleParameter("aid", availabilityId));
        }
    }
}
