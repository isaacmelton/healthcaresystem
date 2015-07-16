using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using HealthCareSystem.model;

namespace HealthCareSystem.dbAccess
{
    /// <summary>
    /// DB layer for LabTest object.
    /// </summary>
    class LabTestDB
    {
        /// <summary>
        /// Use to retrieve the list of available lab tests.
        /// </summary>
        /// <returns>All available lab tests</returns>
        public static List<LabTest> GetAllLabTests()
        {
            List<LabTest> labTestList = new List<LabTest>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                            "SELECT * from LabTest";
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LabTest labTest = new LabTest();
                                labTest.TestId = (int) reader["testID"];
                                labTest.TestType = reader["testType"].ToString();
                                labTestList.Add(labTest);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return labTestList;
        }

        /// <summary>
        /// Use to retrieve a specific lab tests.
        /// </summary>
        /// <returns>the lab test with the given id</returns>
        public static LabTest GetLabTestByID(int id)
        {
            LabTest test = new LabTest();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                            "SELECT * from LabTest where testID = @TESTID";
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@TESTID", id);
                        connection.Open();

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                test.TestId = (int)reader["testID"];
                                test.TestType = reader["testType"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return test;
        }

        public static bool DeleteLabTest(int labTestId)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string deleteStatement = "DELETE FROM LabTest WHERE testID=@ID";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ID", labTestId);

                        connection.Open();
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static int InsertLabTest(LabTest labTest)
        {
            int testID = -1;
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement =
                        "INSERT LabTest " +
                        "(testType) " +
                        "VALUES (@TestType)";
                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@TestType", labTest.TestType);

                        connection.Open();
                        insertCommand.ExecuteNonQuery();

                        string selectStatement =
                            "SELECT IDENT_CURRENT('LabTest') FROM LabTest";

                        using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                        {
                            testID = Convert.ToInt32(selectCommand.ExecuteScalar());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            return testID;
        
        }

        public static bool UpdateLabTest(LabTest oldLabTest, LabTest newLabTest)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement =
                          "UPDATE LabTest SET " +
                            "testType = @NewTestType " +
                          "WHERE testID = @OldTestID " +
                            "AND testType = @OldTestType";

                    using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@NewTestType", newLabTest.TestType);
                        updateCommand.Parameters.AddWithValue("@OldTestID", oldLabTest.TestId);
                        updateCommand.Parameters.AddWithValue("@OldTestType", oldLabTest.TestType);

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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return success;
        }
    }
}
