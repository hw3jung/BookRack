using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using BRApplication.Models; 

namespace BRApplication.Handlers
{
    public class DemoHandler
    {
        public bool InsertStatus(DemoModel Status)
        {
            bool Success = true;
            try
            {
                string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BookRack"].ToString();
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO TransactionStatus VALUES (@param)";
                    command.Parameters.AddWithValue("@param", Status.StatusName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                Success = false;
            }

            return Success; 
        }
    }
}