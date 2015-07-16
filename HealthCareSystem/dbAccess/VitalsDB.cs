using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareSystem.model;

namespace HealthCareSystem.dbAccess
{
    /// <summary>
    /// DB layer for Vitals object.
    /// </summary>
    class VitalsDB
    {
        /// <summary>
        /// Adds a vitals record to the db.
        /// </summary>
        /// <param name="vitals">The vitals record to add</param>
        /// <returns>The vitals ID</returns>
        public static int AddVitals(Vitals vitals)
        {
            int vitalsID = -1;
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement =
                        "INSERT Vitals " +
                        "(appointmentID, bloodPressure, bodyTemperature, pulse) " +
                        "VALUES (@AppointmentID, @BloodPressure, @BodyTemperature, @Pulse)";
                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@AppointmentID", vitals.AppointmentId);
                        insertCommand.Parameters.AddWithValue("@BloodPressure", vitals.BloodPressure);
                        insertCommand.Parameters.AddWithValue("@BodyTemperature", vitals.BodyTemperature);
                        insertCommand.Parameters.AddWithValue("@Pulse", vitals.Pulse);

                        connection.Open();
                        insertCommand.ExecuteNonQuery();

                        vitalsID = vitals.AppointmentId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            return vitalsID;
        }
    }
}
