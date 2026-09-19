

// Rental.cs — Business object for the Rentals entity
// Ref: UC P2.2 Create Booking, P2.3 Cancel Reservation

using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HolidayHomeRentalSystem
{
 
    public class Rental
    {
        public int RentalId { get; set; }
        public int PropertyId { get; set; }
        public int RenterAccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Guests { get; set; }
        public decimal  TotalPrice { get; set; }
        public string   Status { get; set; }
        public DateTime CreatedDate { get; set; }

        //No-argument constructor
        public Rental() : this(0, 0, 0, DateTime.Today, DateTime.Today.AddDays(1), 1, 0m, "Booked", DateTime.Now)
        {
        }

        // Multi-argument constructor 
        public Rental(int rentalId, int propertyId, int renterAccountId,
                      DateTime startDate, DateTime endDate, int guests,
                      decimal totalPrice, string status, DateTime createdDate)
        {
            RentalId = rentalId;
            PropertyId = propertyId;
            RenterAccountId = renterAccountId;
            StartDate = startDate;
            EndDate= endDate;
            Guests= guests;
            TotalPrice = totalPrice;
            Status = status;
            CreatedDate = createdDate;
        }

        //ToString 
        public override string ToString()
        {
            return "RentalID: " + RentalId +
                   "\tProperty: " + PropertyId +
                   "\tDates: " + StartDate.ToShortDateString() + " – " + EndDate.ToShortDateString() +
                   "\tTotal: " + TotalPrice.ToString("C");
        }

        public static DataTable GetBookingsByRenter(int renterAccountId)
        {
            string sql = @"
                SELECT r.RentalID, r.PropertyID, p.Title, p.Country,
                       r.StartDate, r.EndDate, r.Guests, r.TotalPrice, r.Status
                FROM Rentals r
                JOIN Properties p ON p.PropertyID = r.PropertyID
                WHERE r.RenterAccountID = :rid
                  AND r.Status = 'Booked'
                ORDER BY r.CreatedDate DESC";

            return Database.ExecuteQuery(sql,
                new OracleParameter("rid", renterAccountId));
        }

      
        public static void CreateBooking(int propertyId, int renterAccountId,
            DateTime checkIn, DateTime checkOut, int guests, decimal totalPrice)
        {
            using (OracleConnection conn = Database.OpenConnection())
            {
                using (OracleTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlCheck = @"
                            SELECT AvailabilityID
                            FROM Availabilities
                            WHERE PropertyID = :pid
                              AND Status = 'Open'
                              AND StartDate <= :cin
                              AND EndDate >= :cout
                            FETCH FIRST 1 ROW ONLY";

                        int availabilityId = 0;

                        using (OracleCommand cmdCheck = new OracleCommand(sqlCheck, conn)) // OracleCommand — создаём SQL команду привязанную к нашему соединению conn
                                                                                           // Нельзя использовать Database.ExecuteQuery — он открывает своё соединение
                                                                                           // Транзакция требует одно соединение для всех операций
                                                                                           // cmd.Parameters.Add() делает то же самое что new OracleParameter()
                        {
                            cmdCheck.Transaction = tx;
                            cmdCheck.BindByName  = true;
                            cmdCheck.Parameters.Add("pid", propertyId);
                            cmdCheck.Parameters.Add("cin", checkIn);
                            cmdCheck.Parameters.Add("cout", checkOut);

                            object result = cmdCheck.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                                throw new Exception("Property is no longer available for these dates.");

                            availabilityId = Convert.ToInt32(result);
                        }

                      
                        string sqlMax = "SELECT MaxGuests FROM Properties WHERE PropertyID = :pid";
                        using (OracleCommand cmdMax = new OracleCommand(sqlMax, conn))
                        {
                            cmdMax.Transaction = tx;
                            cmdMax.BindByName  = true;
                            cmdMax.Parameters.Add("pid", propertyId);

                            int maxGuests = Convert.ToInt32(cmdMax.ExecuteScalar());
                            if (guests > maxGuests)
                                throw new Exception("Number of guests exceeds the maximum (" + maxGuests + ").");
                        }

                 
                        string sqlInsert = @"
                            INSERT INTO Rentals
                                (RentalID, PropertyID, RenterAccountID, StartDate, EndDate,
                                 Guests, TotalPrice, Status, CreatedDate)
                            VALUES
                                (SEQ_RENTALS.NEXTVAL, :pid, :renterId, :cin, :cout,
                                 :guests, :total, 'Booked', SYSDATE)";

                        using (OracleCommand cmdIns = new OracleCommand(sqlInsert, conn))
                        {
                            cmdIns.Transaction = tx;
                            cmdIns.BindByName  = true;
                            cmdIns.Parameters.Add("pid", propertyId);
                            cmdIns.Parameters.Add("renterId", renterAccountId);
                            cmdIns.Parameters.Add("cin", checkIn);
                            cmdIns.Parameters.Add("cout", checkOut);
                            cmdIns.Parameters.Add("guests", guests);
                            cmdIns.Parameters.Add("total", totalPrice);

                            cmdIns.ExecuteNonQuery();
                        }

                        string sqlUpd = @"
                            UPDATE Availabilities
                            SET Status = 'Closed'
                            WHERE AvailabilityID = :aid";

                        using (OracleCommand cmdUpd = new OracleCommand(sqlUpd, conn))
                        {
                            cmdUpd.Transaction = tx;
                            cmdUpd.BindByName  = true;
                            cmdUpd.Parameters.Add("aid", availabilityId);
                            cmdUpd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

     
        public static void CancelBooking(int rentalId, int renterAccountId,
            int propertyId, DateTime startDate, DateTime endDate)
        {

            // OracleTransaction — ensures both INSERT and UPDATE succeed or fail together
            // Ref: Oracle.ManagedDataAccess Documentation — Database Transactions
            using (OracleConnection conn = Database.OpenConnection())
            {
                using (OracleTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                      
                        string sqlCancel = @"
                            UPDATE Rentals
                            SET Status = 'Cancelled'
                            WHERE RentalID = :rid
                              AND RenterAccountID = :accId
                              AND Status = 'Booked'";

                        using (OracleCommand cmd = new OracleCommand(sqlCancel, conn))
                        {
                            cmd.Transaction = tx;
                            cmd.BindByName  = true;
                            cmd.Parameters.Add("rid",   rentalId);
                            cmd.Parameters.Add("accId", renterAccountId);
                            cmd.ExecuteNonQuery();
                        }

                     
                        string sqlReopen = @"
                            UPDATE Availabilities
                            SET Status = 'Open'
                            WHERE PropertyID = :pid
                              AND StartDate= :sdate
                              AND EndDate = :edate";

                        using (OracleCommand cmd2 = new OracleCommand(sqlReopen, conn))
                        {
                            cmd2.Transaction = tx;
                            cmd2.BindByName  = true;
                            cmd2.Parameters.Add("pid",   propertyId);
                            cmd2.Parameters.Add("sdate", startDate);
                            cmd2.Parameters.Add("edate", endDate);
                            cmd2.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public static DataTable GetYearlyRevenue(int year)
        {
            string sql = @"
                SELECT TO_CHAR(r.StartDate, 'MM') AS Month,
                       COUNT(*) AS TotalBookings,
                       SUM(r.TotalPrice) AS TotalRevenue
                FROM Rentals r
                WHERE EXTRACT(YEAR FROM r.StartDate) = :yr
                  AND r.Status = 'Booked'
                GROUP BY TO_CHAR(r.StartDate, 'MM')
                ORDER BY TO_CHAR(r.StartDate, 'MM')";

            return Database.ExecuteQuery(sql,
                new OracleParameter("yr", year));
        }

      
        public static DataTable GetYearlyBookings(int year)
        {
            string sql = @"
                SELECT TO_CHAR(r.StartDate, 'MM') AS Month,
                       COUNT(*) AS TotalBookings,
                       SUM(r.Guests) AS TotalGuests,
                       SUM(r.TotalPrice) AS Revenue
                FROM Rentals r
                WHERE EXTRACT(YEAR FROM r.StartDate) = :yr
                GROUP BY TO_CHAR(r.StartDate, 'MM')
                ORDER BY TO_CHAR(r.StartDate, 'MM')";

            return Database.ExecuteQuery(sql,
                new OracleParameter("yr", year));
        }

     
       
    }
}
