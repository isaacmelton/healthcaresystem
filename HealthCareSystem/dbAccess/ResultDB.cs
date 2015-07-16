using HealthCareSystem.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareSystem.dbAccess
{
    /// <summary>
    /// DB layer for Result object.
    /// </summary>
    class ResultDB
    {
        public static int AddTest(Result newResult)
        {
            int testID = -1;
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement =
                        "INSERT Results " +
                        "(appointmentID, testID) " +
                        "VALUES (@AppointmentID, @TestID)";
                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@AppointmentID", newResult.AppointmentId);
                        insertCommand.Parameters.AddWithValue("@TestID", newResult.TestId );

                        connection.Open();
                        insertCommand.ExecuteNonQuery();

                        testID = newResult.AppointmentId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            return testID;
        }

        public static List<Result> GetOpenTestsByAppointment()
        {
            List<Result> openResultList = new List<Result>();

            string selectStatement = "SELECT Results.AppointmentID " +
                "FROM Results WHERE Results.TestResult IS NULL GROUP BY Results.AppointmentID";

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Result openTest = new Result();

                            openTest.AppointmentId = (int)reader["AppointmentID"];

                            openResultList.Add(openTest);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return openResultList;

        }

        public static List<Result> GetAllResultsByAppointment()
        {
            List<Result> openResultList = new List<Result>();

            string selectStatement = "SELECT appointmentID " +
                "FROM Results GROUP BY appointmentID";

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Result openTest = new Result();

                            openTest.AppointmentId = (int)reader["AppointmentID"];

                            openResultList.Add(openTest);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return openResultList;

        }

        public static Result GetTestInfo(int appointmentID)
        {
            Result openResult = new Result();

            string selectStatement = "SELECT Results.AppointmentID, Results.TestID " +
                "FROM Results WHERE Results.AppointmentID = @appointmentID";

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {

                        selectCommand.Parameters.AddWithValue("@appointmentID", appointmentID);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Result aResult = new Result();

                                aResult.AppointmentId = (int) reader["AppointmentID"];

                                aResult.TestId = (int) reader["TestID"];

                                openResult = aResult;
                            }
                            connection.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return openResult;

        }

        public static List<Result> GetOpenTestList(int appointmentID)
        {
            List<Result> openResultList = new List<Result>();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement = "SELECT Results.AppointmentID, Results.TestID " +
                                             "FROM Results WHERE Results.testResult IS NULL AND Results.AppointmentID = @appointmentID";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@appointmentID", appointmentID);
                        try
                        {
                            connection.Open();
                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Result aResult = new Result();

                                aResult.AppointmentId = (int) reader["AppointmentID"];

                                aResult.TestId = (int) reader["TestID"];

                                openResultList.Add(aResult);
                            }
                            connection.Close();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return openResultList;

        }

        /// <summary>
        /// Edit a Result record and fail if the record has been updated since the last access.
        /// </summary>
        /// <param name="oldPerson">The old result object to update</param>
        /// <param name="newPerson">The new result with new data</param>
        /// <returns>True IFF the result is updated</returns>
        public static bool UpdateTestResult(Result oldResult, Result newResult)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement =
                          "UPDATE Results SET " +
                            "testResult = @NewTestResult, " +
                           "resultDate = @NewResultDate " +
                          "WHERE appointmentID = @OldAppointmentID " +
                            "AND testID = @OldTestID"; 
                            

                    using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                    {
                      
                        updateCommand.Parameters.AddWithValue("@NewAppointmentID", newResult.AppointmentId);
                        updateCommand.Parameters.AddWithValue("@NewTestID", newResult.TestId);
                        updateCommand.Parameters.AddWithValue("@NewTestResult", newResult.TestResult);
                        updateCommand.Parameters.AddWithValue("@NewResultDate", DateTime.Now);

                        updateCommand.Parameters.AddWithValue("@OldAppointmentID", oldResult.AppointmentId);
                        updateCommand.Parameters.AddWithValue("@OldTestID", oldResult.TestId);

                        connection.Open();
                        int count = updateCommand.ExecuteNonQuery();
                        if (count > 0)
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        public static List<Result> GetTestsForAppointment(int appointmentID)
        {
            List<Result> openResultList = new List<Result>();

            string selectStatement = "SELECT Results.AppointmentID, Results.TestID, LabTest.TestType, Results.TestResult, Results.ResultDate " +
                "FROM Results JOIN LabTest ON Results.TestID = LabTest.TestID WHERE Results.AppointmentID = " + appointmentID;

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Result aResult = new Result();

                            aResult.AppointmentId = (int)reader["AppointmentID"];

                            aResult.TestId = (int)reader["TestID"];
                            if (!DBNull.Value.Equals(reader["TestResult"]))
                            {
                                aResult.TestResult = reader["TestResult"].ToString();
                                aResult.ResultDate = (DateTime)reader["ResultDate"];
                            }
                            

                            openResultList.Add(aResult);
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return openResultList;

        }
    }
}