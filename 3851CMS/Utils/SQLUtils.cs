using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _3851CMS.Utils
{
    public class SQLUtils
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString;
        public static bool SQLHandler(string SQLString, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, conn))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    try
                    {
                        conn.Open();
                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows == 0)
                        {
                            Console.WriteLine("Warning: No rows were affected by the SQL command.");
                            return false;
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or rethrow it.
                        throw;
                    }
                }
            }
        }


        public static DataTable GetTable(string SQLString)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }
        }
        public static DataTable GetTable(string SQLString, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, conn))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public static DataSet GetDataSet(string SQLString)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            sda.Fill(ds);
                            return ds;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }
        }

    }
}