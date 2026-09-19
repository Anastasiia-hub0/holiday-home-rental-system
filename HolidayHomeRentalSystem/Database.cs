

using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HolidayHomeRentalSystem
{
    internal class Database
    {
       
        public const string connectionString =
            "Data Source=localhost/orclpdb; User Id=holidayhome; Password=holidayhome;";

        //Open a new Oracle connection
        public static OracleConnection OpenConnection()
        {

            // 'using' statement ensures connection is closed automatically
            // Ref: C# Book Section 3.6 "Using Files" — resource management
            OracleConnection conn = new OracleConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static DataSet ExecuteMultiRowQuery(string query)

        // Ref: C# Book Section 3.6 — 'using' automatically closes connection when block ends
        {
            using (OracleConnection conn = OpenConnection())
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

     
        public static DataTable ExecuteQuery(string query, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = OpenConnection())
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.BindByName = true;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// Executes INSERT / UPDATE / DELETE and returns affected row count.
     
        public static int ExecuteNonQuery(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = OpenConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.BindByName = true;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

      
        /// Executes a query that returns a single scalar value
        /// (e.g. SELECT MAX(...), SELECT COUNT(...), etc.).
       
        public static object ExecuteScalar(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = OpenConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.BindByName = true;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        }
    }
