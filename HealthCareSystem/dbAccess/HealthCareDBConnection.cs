using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.dbAccess
{
    /// <summary>
    /// DB connection information.
    /// </summary>
    public static class HealthCareDBConnection
    {
        /// <summary>
        /// Gets a connection to the db.
        /// </summary>
        /// <returns>The connection</returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                //"Data Source=localhost;Initial Catalog=CS6232-g6;Integrated Security=true;";
                string connectionString = "Data Source=localhost;Initial Catalog=CS6232-g6;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
