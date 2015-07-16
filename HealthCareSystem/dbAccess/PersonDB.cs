using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareSystem.model;
using System.Text.RegularExpressions;

namespace HealthCareSystem.dbAccess
{
    /// <summary>
    /// DB layer for Person object.
    /// </summary>
    class PersonDB
    {
        /// <summary>
        /// Adds a Person to the database.
        /// </summary>
        /// <param name="person">The person to add</param>
        /// <returns>The ID of the Person IFF successful</returns>
        public static int AddPerson(Person person)
        {
            int personID = -1;
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement =
                        "INSERT Person " +
                        "(ssn, lastName, middleInitial, firstName, dateOfBirth, gender, address, " +
                        "city, state, zip, phone) " +
                        "VALUES (@Ssn, @LastName, @MiddleInitial, @FirstName, @DateOfBirth, @Gender, " +
                        "@Address, @City, @State, @Zip, @Phone)";
                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        
                        insertCommand.Parameters.AddWithValue("@Ssn", person.Ssn);
                        
                        insertCommand.Parameters.AddWithValue("@LastName", person.LastName);
                        if (person.MiddleInitial.Equals(null))
                        {
                            insertCommand.Parameters.AddWithValue("@MiddleInitial", DBNull.Value);
                        }
                        else
                        {
                            insertCommand.Parameters.AddWithValue("@MiddleInitial", person.MiddleInitial);
                        }
                        insertCommand.Parameters.AddWithValue("@FirstName", person.FirstName);
                        insertCommand.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth.Date);
                        insertCommand.Parameters.AddWithValue("@Gender", person.Gender);
                        insertCommand.Parameters.AddWithValue("@Address", person.Address);
                        insertCommand.Parameters.AddWithValue("@City", person.City);
                        insertCommand.Parameters.AddWithValue("@State", person.State);
                        insertCommand.Parameters.AddWithValue("@Zip", person.Zip);
                        insertCommand.Parameters.AddWithValue("@Phone", person.Phone);
                         
                         connection.Open();
                        insertCommand.ExecuteNonQuery();
                        string selectStatement =
                            "SELECT IDENT_CURRENT('Person') FROM Person";

                        using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                        {
                            personID = Convert.ToInt32(selectCommand.ExecuteScalar());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return personID;
        }

        /// <summary>
        /// Edit a person record and fail if the record has been updated since the last access.
        /// </summary>
        /// <param name="oldPerson">The old person object to update</param>
        /// <param name="newPerson">The new person with new data</param>
        /// <returns>True IFF the person is updated</returns>
        public static bool UpdatePerson(Person oldPerson, Person newPerson)
        {
            bool success = false;
            int i = 0;

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement =
                          "UPDATE Person SET " +
                            "ssn = @NewSsn, " +
                            "lastName = @NewLastName, " +
                            "middleInitial = @NewMiddleInitial, " +
                            "firstName = @NewFirstName, " +
                            "dateOfBirth = @NewDateOfBirth, " +
                            "gender = @NewGender, " +
                            "address = @NewAddress, " +
                            "city = @NewCity, " +
                            "state = @NewState, " +
                            "phone = @NewPhone " +
                          "WHERE personID = @OldPersonID " +
                            "AND ssn = @OldSsn " +
                            "AND lastName = @OldLastName " +
                            "AND (middleInitial = @OldMiddleInitial " +
                                "OR (middleInitial IS NULL AND @OldMiddleInitial IS NULL)) " +
                            "AND firstName = @OldFirstName " +
                            "AND cast(dateOfBirth as date) = @OldDateOfBirth " +
                            "AND gender = @OldGender " +
                            "AND address = @OldAddress " +
                            "AND city = @OldCity " +
                            "AND state = @OldState " +
                            "AND zip = @OldZip " +
                            "AND phone = @OldPhone";

                    using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                    {
                        if (newPerson.Ssn.Length == 9)
                            updateCommand.Parameters.AddWithValue("@NewSsn", newPerson.Ssn);
                        else 
                            return false;

                        updateCommand.Parameters.AddWithValue("@NewLastName", newPerson.LastName);

                        if (newPerson.MiddleInitial.Equals(null))
                            updateCommand.Parameters.AddWithValue("@NewMiddleInitial", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@NewMiddleInitial", newPerson.MiddleInitial);

                        updateCommand.Parameters.AddWithValue("@NewFirstName", newPerson.FirstName);
                        updateCommand.Parameters.AddWithValue("@NewDateOfBirth", newPerson.DateOfBirth);
                        updateCommand.Parameters.AddWithValue("@NewGender", newPerson.Gender);
                        updateCommand.Parameters.AddWithValue("@NewAddress", newPerson.Address);
                        updateCommand.Parameters.AddWithValue("@NewCity", newPerson.City);
                        updateCommand.Parameters.AddWithValue("@NewState", newPerson.State);

                        if (newPerson.Zip.Length == 5 && (int.TryParse(newPerson.Zip, out i) == true))
                            updateCommand.Parameters.AddWithValue("@NewZip", newPerson.Zip);
                        else
                            return false;

                        updateCommand.Parameters.AddWithValue("@NewPhone", newPerson.Phone);

                        updateCommand.Parameters.AddWithValue("@OldPersonID", oldPerson.PersonId);
                        updateCommand.Parameters.AddWithValue("@OldSsn", oldPerson.Ssn);
                        updateCommand.Parameters.AddWithValue("@OldLastName", oldPerson.LastName);

                        if (oldPerson.MiddleInitial.Equals(null))
                            updateCommand.Parameters.AddWithValue("@OldMiddleInitial", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@OldMiddleInitial", oldPerson.MiddleInitial);

                        updateCommand.Parameters.AddWithValue("@OldFirstName", oldPerson.FirstName);
                        updateCommand.Parameters.AddWithValue("@OldDateOfBirth", oldPerson.DateOfBirth.Date);
                        updateCommand.Parameters.AddWithValue("@OldGender", oldPerson.Gender);
                        updateCommand.Parameters.AddWithValue("@OldAddress", oldPerson.Address);
                        updateCommand.Parameters.AddWithValue("@OldCity", oldPerson.City);
                        updateCommand.Parameters.AddWithValue("@OldState", oldPerson.State);
                        updateCommand.Parameters.AddWithValue("@OldZip", oldPerson.Zip);
                        updateCommand.Parameters.AddWithValue("@OldPhone", oldPerson.Phone);

                        connection.Open();
                        int count = updateCommand.ExecuteNonQuery();

                        if (count > 0)
                            success = true;
                        else
                            success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return success;
        }

        public static bool UpdateUser(User oldPerson, User newPerson)
        {
            bool success = false;
            int i = 0;

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement =
                          "UPDATE Person SET " +
                            "ssn = @NewSsn, " +
                            "lastName = @NewLastName, " +
                            "middleInitial = @NewMiddleInitial, " +
                            "firstName = @NewFirstName, " +
                            "dateOfBirth = @NewDateOfBirth, " +
                            "gender = @NewGender, " +
                            "address = @NewAddress, " +
                            "city = @NewCity, " +
                            "state = @NewState, " +
                            "phone = @NewPhone " +
                            "userName = @NewUserName " +
                            "userRole = @NewUserRole " +
                          "WHERE personID = @OldPersonID " +
                            "AND ssn = @OldSsn " +
                            "AND lastName = @OldLastName " +
                            "AND (middleInitial = @OldMiddleInitial " +
                                "OR (middleInitial IS NULL AND @OldMiddleInitial IS NULL)) " +
                            "AND firstName = @OldFirstName " +
                            "AND dateOfBirth = @OldDateOfBirth " +
                            "AND gender = @OldGender " +
                            "AND address = @OldAddress " +
                            "AND city = @OldCity " +
                            "AND state = @OldState " +
                            "AND zip = @OldZip " +
                            "AND phone = @OldPhone" +
                            "AND (userName = @OldUserName " +
                                "OR (userName IS NULL AND @OldUserName IS NULL)) " +
                            "AND (userRole = @OldUserRole " +
                                "OR (userRole IS NULL AND @OldUserRole IS NULL)) ";

                    using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                    {
                        if (newPerson.Ssn.Length == 9)
                            updateCommand.Parameters.AddWithValue("@NewSsn", newPerson.Ssn);
                        else 
                            return false;

                        updateCommand.Parameters.AddWithValue("@NewLastName", newPerson.LastName);

                        if (newPerson.MiddleInitial.Equals(null))
                            updateCommand.Parameters.AddWithValue("@NewMiddleInitial", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@NewMiddleInitial", newPerson.MiddleInitial);

                        updateCommand.Parameters.AddWithValue("@NewFirstName", newPerson.FirstName);
                        updateCommand.Parameters.AddWithValue("@NewDateOfBirth", newPerson.DateOfBirth);
                        updateCommand.Parameters.AddWithValue("@NewGender", newPerson.Gender);
                        updateCommand.Parameters.AddWithValue("@NewAddress", newPerson.Address);
                        updateCommand.Parameters.AddWithValue("@NewCity", newPerson.City);
                        updateCommand.Parameters.AddWithValue("@NewState", newPerson.State);

                        if (newPerson.Zip.Length == 5 && (int.TryParse(newPerson.Zip, out i) == true))
                            updateCommand.Parameters.AddWithValue("@NewZip", newPerson.Zip);
                        else
                            return false;

                        updateCommand.Parameters.AddWithValue("@NewPhone", newPerson.Phone);

                        if (newPerson.UserName == null)
                            updateCommand.Parameters.AddWithValue("@NewUserName", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@NewUserName", newPerson.UserName);

                        if (newPerson.UserRole == null)
                            updateCommand.Parameters.AddWithValue("@NewUserRole", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@NewUserRole", newPerson.UserRole);

                        updateCommand.Parameters.AddWithValue("@OldPersonID", oldPerson.PersonId);
                        updateCommand.Parameters.AddWithValue("@OldSsn", oldPerson.Ssn);
                        updateCommand.Parameters.AddWithValue("@OldLastName", oldPerson.LastName);

                        if (oldPerson.MiddleInitial.Equals(null))
                            updateCommand.Parameters.AddWithValue("@OldMiddleInitial", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@OldMiddleInitial", oldPerson.MiddleInitial);

                        updateCommand.Parameters.AddWithValue("@OldFirstName", oldPerson.FirstName);
                        updateCommand.Parameters.AddWithValue("@OldDateOfBirth", oldPerson.DateOfBirth);
                        updateCommand.Parameters.AddWithValue("@OldGender", oldPerson.Gender);
                        updateCommand.Parameters.AddWithValue("@OldAddress", oldPerson.Address);
                        updateCommand.Parameters.AddWithValue("@OldCity", oldPerson.City);
                        updateCommand.Parameters.AddWithValue("@OldState", oldPerson.State);
                        updateCommand.Parameters.AddWithValue("@OldZip", oldPerson.Zip);
                        updateCommand.Parameters.AddWithValue("@OldPhone", oldPerson.Phone);

                        if (oldPerson.UserName == null)
                            updateCommand.Parameters.AddWithValue("@OldUserName", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@OldUserName", oldPerson.UserName);

                        if (oldPerson.UserRole == null)
                            updateCommand.Parameters.AddWithValue("@OldUserRole", DBNull.Value);
                        else
                            updateCommand.Parameters.AddWithValue("@OldUserRole", oldPerson.UserRole);

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

        /// <summary>
        /// Gets a person's role and ID.
        /// </summary>
        /// <param name="userName">The username to look up</param>
        /// <returns>A dictionary containing the user ID and user role</returns>
        public static Dictionary<int,String> GetPersonRoleAndID(String userName)
        {
            Dictionary<int, String> info = new Dictionary<int, string>();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement = "SELECT personID, userRole FROM Person WHERE userName=@USERNAME";

                    using (SqlCommand selectCommand = new SqlCommand(updateStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@USERNAME", userName);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                info.Add((int)reader["personID"], reader["userRole"].ToString());
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return info;
        }

        /// <summary>
        /// Gets a person's role.
        /// </summary>
        /// <param name="userID">The userID to look up</param>
        /// <returns>A string containing the user role</returns>
        public static String GetPersonRole(int userID)
        {
            String info = "";

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement = "SELECT userRole FROM Person WHERE personID=@USERID";

                    using (SqlCommand selectCommand = new SqlCommand(updateStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@USERID", userID);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                info = reader["userRole"].ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return info;
        }

        internal static bool DeletePerson(int id)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string deleteStatement = "DELETE FROM Person WHERE personID=@ID";

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
    }

    }

