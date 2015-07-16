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
    /// DB layer for Doctor object.
    /// </summary>
    class DoctorDB
    {
        public static bool AddDoctor(int personID, User doctor)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement = "INSERT Doctor (personID, password) VALUES (@ID, @PASSWORD)";

                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@PASSWORD", doctor.GetPasswordHash());
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
                    string updateStatement = "UPDATE Doctor SET password=@PASSWORD WHERE personID=@ID";

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
                    string updateStatement = "SELECT password FROM Doctor WHERE personID=@ID";

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

        internal static List<User> GetAllDoctors()
        {
            List<User> doctorList = new List<User>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person pe " +
                        "JOIN Doctor d ON pe.personID = d.personID ";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User doctor = new User();

                                doctor.PersonId = (int)reader["personID"];
                                doctor.Ssn = reader["ssn"].ToString();
                                doctor.FirstName = reader["firstName"].ToString();
                                doctor.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                doctor.LastName = reader["lastName"].ToString();
                                doctor.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                doctor.Gender = Convert.ToChar(reader["gender"].ToString());
                                doctor.Address = reader["address"].ToString();
                                doctor.City = reader["city"].ToString();
                                doctor.State = reader["state"].ToString();
                                doctor.Zip = reader["zip"].ToString();
                                doctor.Phone = reader["phone"].ToString();
                                doctor.UserName = reader["userName"].ToString();
                                doctor.SetPassword((byte[])reader["password"]);

                                doctorList.Add(doctor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return doctorList;
        }

        internal static bool DeleteDoctor(int id)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string deleteStatement = "DELETE FROM Doctor WHERE personID=@ID";

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

        internal static User GetDoctorByID(int id)
        {
            User theUser = new User();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement = "SELECT d.password, p.* FROM Doctor d INNER JOIN Person p on d.personID = p.personID WHERE d.personID=@ID";

                    using (SqlCommand selectCommand = new SqlCommand(updateStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                theUser.UserName = reader["userName"].ToString();
                                theUser.UserRole = reader["userRole"].ToString();

                                theUser.PersonId = (int)reader["personID"];
                                theUser.Ssn = reader["ssn"].ToString();
                                theUser.FirstName = reader["firstName"].ToString();
                                theUser.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                theUser.LastName = reader["lastName"].ToString();
                                theUser.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                theUser.Gender = Convert.ToChar(reader["gender"].ToString());
                                theUser.Address = reader["address"].ToString();
                                theUser.City = reader["city"].ToString();
                                theUser.State = reader["state"].ToString();
                                theUser.Zip = reader["zip"].ToString();
                                theUser.Phone = reader["phone"].ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return theUser;
        }

        /// <summary>
        /// Gets a doctor by their doctor ID.
        /// </summary>
        /// <param name="nurseID">The ID of the doctor</param>
        /// <returns>The doctor with the specified ID</returns>
        public static Doctor GetDoctorInfoByID(int nurseID)
        {
            Doctor doc = new Doctor();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person " +
                        "JOIN Doctor ON Person.personID = Doctor.personID " +
                        "WHERE Doctor.personID = @personID";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@personID", nurseID);
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doc.PersonId = (int)reader["personID"];
                                doc.Ssn = reader["ssn"].ToString();
                                doc.FirstName = reader["firstName"].ToString();
                                doc.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                doc.LastName = reader["lastName"].ToString();
                                doc.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                doc.Gender = Convert.ToChar(reader["gender"].ToString());
                                doc.Address = reader["address"].ToString();
                                doc.City = reader["city"].ToString();
                                doc.State = reader["state"].ToString();
                                doc.Zip = reader["zip"].ToString();
                                doc.Phone = reader["phone"].ToString();

                                doc.UserName = reader["userName"].ToString();
                                doc.UserRole = reader["userRole"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return doc;
        }

    }
}
