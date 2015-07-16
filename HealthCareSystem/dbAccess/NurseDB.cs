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
    /// DB layer for Nurse object.
    /// </summary>
    class NurseDB
    {
        public static bool AddNurse(int personID, User nurse)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement = "INSERT Nurse (personID, password) VALUES (@ID, @PASSWORD)";

                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@PASSWORD", nurse.GetPasswordHash());
                        insertCommand.Parameters.AddWithValue("@ID", personID);

                        connection.Open();
                        insertCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Changes the user's password.
        /// </summary>
        /// <param name="id">The user's ID</param>
        /// <param name="password">The new password</param>
        public static void ChangePassword(int id, byte[] password)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement = "UPDATE Nurse SET password=@PASSWORD WHERE personID=@ID";

                    using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@PASSWORD", password);
                        updateCommand.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the hashed password for the user.
        /// </summary>
        /// <param name="userName">The username to look up</param>
        /// <returns>The hashed password for the user</returns>
        public static byte[] GetPasswordForUser(int id)
        {
            byte[] arr = new byte[64];

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement = "SELECT password FROM Nurse WHERE personID=@ID";

                    using (SqlCommand selectCommand = new SqlCommand(updateStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                arr = (byte[])reader["password"];
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return arr;
        }

        internal static List<User> GetAllNurses()
        {
            List<User> nurseList = new List<User>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person pe " +
                        "JOIN Nurse nu ON pe.personID = nu.personID ";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User nurse = new User();

                                nurse.PersonId = (int)reader["personID"];
                                nurse.Ssn = reader["ssn"].ToString();
                                nurse.FirstName = reader["firstName"].ToString();
                                nurse.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                nurse.LastName = reader["lastName"].ToString();
                                nurse.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                nurse.Gender = Convert.ToChar(reader["gender"].ToString());
                                nurse.Address = reader["address"].ToString();
                                nurse.City = reader["city"].ToString();
                                nurse.State = reader["state"].ToString();
                                nurse.Zip = reader["zip"].ToString();
                                nurse.Phone = reader["phone"].ToString();
                                nurse.UserName = reader["userName"].ToString();
                                nurse.SetPassword((byte[]) reader["password"]);

                                nurseList.Add(nurse);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return nurseList;
        }

        internal static bool DeleteNurse(int id)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string deleteStatement = "DELETE FROM Nurse WHERE personID=@ID";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ID", id);

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



        /// <summary>
        /// Gets a nurse by their nurse ID.
        /// </summary>
        /// <param name="nurseID">The ID of the nurse</param>
        /// <returns>The nurse with the specified ID</returns>
        public static Nurse GetNurseByID(int nurseID)
        {
            Nurse nurse = new Nurse();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person " +
                        "JOIN Nurse ON Person.personID = Nurse.personID " +
                        "WHERE Nurse.personID = @personID";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@personID", nurseID);
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nurse.PersonId = (int)reader["personID"];
                                nurse.Ssn = reader["ssn"].ToString();
                                nurse.FirstName = reader["firstName"].ToString();
                                nurse.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                nurse.LastName = reader["lastName"].ToString();
                                nurse.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                nurse.Gender = Convert.ToChar(reader["gender"].ToString());
                                nurse.Address = reader["address"].ToString();
                                nurse.City = reader["city"].ToString();
                                nurse.State = reader["state"].ToString();
                                nurse.Zip = reader["zip"].ToString();
                                nurse.Phone = reader["phone"].ToString();

                                nurse.UserName = reader["userName"].ToString();
                                nurse.UserRole = reader["userRole"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return nurse;
        }
    }
}
