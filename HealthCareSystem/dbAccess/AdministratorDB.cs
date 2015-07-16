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
    /// DB layer for Administrator object.
    /// </summary>
    class AdministratorDB
    {
        public static bool AddAdministrator(int personID, User admin)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement = "INSERT Administrator (personID, password) VALUES (@ID, @PASSWORD)";

                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@PASSWORD", admin.GetPasswordHash());
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
                    string updateStatement = "UPDATE Administrator SET password=@PASSWORD WHERE personID=@ID";

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
                    string updateStatement = "SELECT password FROM Administrator WHERE personID=@ID";

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

        internal static List<User> GetAllAdministrators()
        {
            List<User> adminList = new List<User>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person pe " +
                        "JOIN Administrator ad ON pe.personID = ad.personID ";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User admin = new User();

                                admin.PersonId = (int)reader["personID"];
                                admin.Ssn = reader["ssn"].ToString();
                                admin.FirstName = reader["firstName"].ToString();
                                admin.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                admin.LastName = reader["lastName"].ToString();
                                admin.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                admin.Gender = Convert.ToChar(reader["gender"].ToString());
                                admin.Address = reader["address"].ToString();
                                admin.City = reader["city"].ToString();
                                admin.State = reader["state"].ToString();
                                admin.Zip = reader["zip"].ToString();
                                admin.Phone = reader["phone"].ToString();
                                admin.UserName = reader["userName"].ToString();
                                admin.SetPassword((byte[]) reader["password"]);

                                adminList.Add(admin);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return adminList;
        }

        public bool UpdateAdministrator(User oldAdmin, User newAdmin)
        {
            return PersonDB.UpdateUser(oldAdmin, newAdmin);
        }

        internal static bool DeleteAdministrator(int id)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string deleteStatement = "DELETE FROM Administrator WHERE personID=@ID";

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

        internal static User GetAdministratorByID(int id)
        {
            User theUser = new User();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement = "SELECT d.password, p.* FROM Administrator d INNER JOIN Person p on d.personID = p.personID WHERE d.personID=@ID";

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
    }
}
