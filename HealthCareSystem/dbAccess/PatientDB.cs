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
    /// DB layer for Patient object.
    /// </summary>
    class PatientDB
    {
        /// <summary>
        /// Adds a patient using a current person.
        /// </summary>
        /// <param name="personID">The person to convert to a patient</param>
        /// <returns>The patient ID</returns>
        public static int AddPatient(Person person)
        {
            int newPatientID = -1;
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlTransaction tran = connection.BeginTransaction())
                    {
                        string insertPersonStatement =
                        "INSERT Person (ssn, lastName, middleInitial, firstName, dateOfBirth, gender, address, city, state, zip, phone) " +
                        "VALUES (@Ssn, @LastName, @MiddleInitial, @FirstName, @DateOfBirth, @Gender, @Address, @City, @State, @Zip, @Phone)";

                        string insertPatientStatement = "INSERT Patient (personID) VALUES (@PatientID)";

                        using (SqlCommand insertPersonCommand = new SqlCommand(insertPersonStatement, connection))
                        {
                            insertPersonCommand.Transaction = tran;
                            insertPersonCommand.Parameters.AddWithValue("@Ssn", person.Ssn);
                            insertPersonCommand.Parameters.AddWithValue("@LastName", person.LastName);

                            if (person.MiddleInitial.Equals(null))
                                insertPersonCommand.Parameters.AddWithValue("@MiddleInitial", DBNull.Value);
                            else
                                insertPersonCommand.Parameters.AddWithValue("@MiddleInitial", person.MiddleInitial);

                            insertPersonCommand.Parameters.AddWithValue("@FirstName", person.FirstName);
                            insertPersonCommand.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth.Date);
                            insertPersonCommand.Parameters.AddWithValue("@Gender", person.Gender);
                            insertPersonCommand.Parameters.AddWithValue("@Address", person.Address);
                            insertPersonCommand.Parameters.AddWithValue("@City", person.City);
                            insertPersonCommand.Parameters.AddWithValue("@State", person.State);
                            insertPersonCommand.Parameters.AddWithValue("@Zip", person.Zip);
                            insertPersonCommand.Parameters.AddWithValue("@Phone", person.Phone);

                            insertPersonCommand.ExecuteNonQuery();
                            string selectStatement =
                                "SELECT IDENT_CURRENT('Person') FROM Person";

                            using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                            {
                                selectCommand.Transaction = tran;
                                newPatientID = Convert.ToInt32(selectCommand.ExecuteScalar());
                            }
                        }

                        using (SqlCommand insertPatientCommand = new SqlCommand(insertPatientStatement, connection))
                        {
                            insertPatientCommand.Transaction = tran;
                            insertPatientCommand.Parameters.AddWithValue("@PatientID", newPatientID);
                            insertPatientCommand.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            return newPatientID;
        }

        /// <summary>
        /// Gets a patient by their patient ID.
        /// </summary>
        /// <param name="patientID">The ID of the patient</param>
        /// <returns>The patient with the specified ID</returns>
        public static Patient GetPatientByID(int patientID)
        {
            Patient patient = new Patient();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person " +
                        "JOIN Patient ON Person.personID = Patient.personID " +
                        "WHERE Patient.personID = @personID";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@personID", patientID);
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patient.PersonId = (int)reader["personID"];
                                patient.Ssn = reader["ssn"].ToString();
                                patient.FirstName = reader["firstName"].ToString();
                                //patient.MiddleInitial = DBNull.Value.Equals(reader["middleInitial"]) ? null : Convert.ToChar(reader["middleInitial"].ToString());
                                if (DBNull.Value.Equals(reader["middleInitial"]))
                                    patient.MiddleInitial = null;
                                else
                                    patient.MiddleInitial = Convert.ToChar(reader["middleInitial"].ToString());
                                patient.LastName = reader["lastName"].ToString();
                                patient.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                patient.Gender = Convert.ToChar(reader["gender"].ToString());
                                patient.Address = reader["address"].ToString();
                                patient.City = reader["city"].ToString();
                                patient.State = reader["state"].ToString();
                                patient.Zip = reader["zip"].ToString();
                                patient.Phone = reader["phone"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return patient;
        }

        /// <summary>
        /// Gets a list of all patients.
        /// </summary>
        /// <returns>A list of patients</returns>
        public static List<Patient> GetAllPatients()
        {
            List<Patient> patList = new List<Patient>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person pe " +
                        "JOIN Patient pa ON pe.personID = pa.personID ";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient patient = new Patient();

                                patient.PersonId = (int)reader["personID"];
                                patient.Ssn = reader["ssn"].ToString();
                                patient.FirstName = reader["firstName"].ToString();
                                patient.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                patient.LastName = reader["lastName"].ToString();
                                patient.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                patient.Gender = Convert.ToChar(reader["gender"].ToString());
                                patient.Address = reader["address"].ToString();
                                patient.City = reader["city"].ToString();
                                patient.State = reader["state"].ToString();
                                patient.Zip = reader["zip"].ToString();
                                patient.Phone = reader["phone"].ToString();

                                patList.Add(patient);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return patList;
        }

        /// <summary>
        /// Gets a list of patients with the specified last and first name.
        /// </summary>
        /// <param name="lastName">The last name of the patient</param>
        /// <param name="firstName">The first name of the patient</param>
        /// <returns>A list of patients that match the search criteria</returns>
        public static List<Patient> GetPatientByLastNameFirstName(String lastName, String firstName)
        {
            List<Patient> patList = new List<Patient>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person pe " +
                        "JOIN Patient pa ON pe.personID = pa.personID " +
                        "WHERE pe.lastName = @lastName " +
                        "AND pe.firstName = @firstName";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@lastName", lastName);
                        selectCommand.Parameters.AddWithValue("@firstName", firstName);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient patient = new Patient();

                                patient.PersonId = (int)reader["personID"];
                                patient.Ssn = reader["ssn"].ToString();
                                patient.FirstName = reader["firstName"].ToString();
                                patient.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                patient.LastName = reader["lastName"].ToString();
                                patient.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                patient.Gender = Convert.ToChar(reader["gender"].ToString());
                                patient.Address = reader["address"].ToString();
                                patient.City = reader["city"].ToString();
                                patient.State = reader["state"].ToString();
                                patient.Zip = reader["zip"].ToString();
                                patient.Phone = reader["phone"].ToString();

                                patList.Add(patient);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return patList;
        }

        /// <summary>
        /// Gets a list of patients with the specified DOB and last name.
        /// </summary>
        /// <param name="dateOfBirth">The DOB of the patient</param>
        /// <param name="lastName">The last name of the patient</param>
        /// <returns>A list of patients that match the search criteria</returns>
        public static List<Patient> GetPatientByDateOfBirthLastName(DateTime dateOfBirth, String lastName)
        {
            List<Patient> patList = new List<Patient>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person pe " +
                        "JOIN Patient pa ON pe.personID = pa.personID " +
                        "WHERE pe.lastName = @lastName " +
                        "AND cast(pe.dateOfBirth as date) = @dateOfBirth";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@lastName", lastName);
                        selectCommand.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient patient = new Patient();

                                patient.PersonId = (int)reader["personID"];
                                patient.Ssn = reader["ssn"].ToString();
                                patient.FirstName = reader["firstName"].ToString();
                                patient.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                patient.LastName = reader["lastName"].ToString();
                                patient.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                patient.Gender = Convert.ToChar(reader["gender"].ToString());
                                patient.Address = reader["address"].ToString();
                                patient.City = reader["city"].ToString();
                                patient.State = reader["state"].ToString();
                                patient.Zip = reader["zip"].ToString();
                                patient.Phone = reader["phone"].ToString();

                                patList.Add(patient);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return patList;
        }

        /// <summary>
        /// Gets a list of patients with the specified DOB.
        /// </summary>
        /// <param name="dateOfBirth">The DOB of the patient</param>
        /// <returns>A list of patients that match the search criteria</returns>
        public static List<Patient> GetPatientByDateOfBirth(DateTime dateOfBirth)
        {
            List<Patient> patList = new List<Patient>();
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement =
                        "SELECT * from Person pe " +
                        "JOIN Patient pa ON pe.personID = pa.personID " +
                        "WHERE cast(pe.dateOfBirth as date) = @dateOfBirth";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient patient = new Patient();

                                patient.PersonId = (int)reader["personID"];
                                patient.Ssn = reader["ssn"].ToString();
                                patient.FirstName = reader["firstName"].ToString();
                                patient.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                                patient.LastName = reader["lastName"].ToString();
                                patient.DateOfBirth = (DateTime)reader["dateOfBirth"];
                                patient.Gender = Convert.ToChar(reader["gender"].ToString());
                                patient.Address = reader["address"].ToString();
                                patient.City = reader["city"].ToString();
                                patient.State = reader["state"].ToString();
                                patient.Zip = reader["zip"].ToString();
                                patient.Phone = reader["phone"].ToString();

                                patList.Add(patient);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return patList;
        }

        /// <summary>
        /// Updates a patient.
        /// </summary>
        /// <param name="oldPatient">The original patient</param>
        /// <param name="newPatient">The new patient with new data</param>
        /// <returns>True IFF the old patient was updated</returns>
        public static bool UpdatePatient(Person oldPatient, Person newPatient) 
        {
            SqlConnection connection = HealthCareDBConnection.GetConnection();
            string updateStatement = "UPDATE Person "
                + "SET Ssn = @NewSsn, "
                + "LastName = @NewLastName, "
                + "MiddleInitial = @NewMiddleInitial, "
                + "FirstName = @NewFirstName, "
                + "DateOfBirth = @NewDateOfBirth, "
                + "Gender = @NewGender, "
                + "Address = @NewAddress, "
                + "City = @NewCity, "
                + "State = @NewState, "
                + "Zip = @NewZip, "
                + "Phone = @NewPhone "
                + "WHERE PersonId = @OldPersonId "
                + "AND Ssn = @OldSsn "
                + "AND LastName = @OldLastName "
                + "AND (MiddleInitial = @OldMiddleInitial OR (MiddleInitial IS NULL AND @OldMiddleInitial IS NULL)) "
                + "AND FirstName = @OldFirstName "
                + "AND DateOfBirth = @OldDateOfBirth "
                + "AND Gender = @OldGender "
                + "AND Address = @OldAddress "
                + "AND City = @OldCity "
                + "AND State = @OldState "
                + "AND Zip = @OldZip "
                + "AND Phone = @OldPhone";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewSsn", newPatient.Ssn);
            updateCommand.Parameters.AddWithValue("@NewLastName", newPatient.LastName);
            if (newPatient.MiddleInitial.Equals(""))
                updateCommand.Parameters.AddWithValue("@OldMiddleInitial", DBNull.Value);
            else updateCommand.Parameters.AddWithValue("@NewMiddleInitial", newPatient.MiddleInitial);
            updateCommand.Parameters.AddWithValue("@NewFirstName", newPatient.FirstName);
            updateCommand.Parameters.AddWithValue("@NewDateOfBirth", newPatient.DateOfBirth);
            updateCommand.Parameters.AddWithValue("@NewGender", newPatient.Gender);
            updateCommand.Parameters.AddWithValue("@NewAddress", newPatient.Address);
            updateCommand.Parameters.AddWithValue("@NewCity", newPatient.City);
            updateCommand.Parameters.AddWithValue("@NewState", newPatient.State);
            updateCommand.Parameters.AddWithValue("@NewZip", newPatient.Zip);
            updateCommand.Parameters.AddWithValue("@NewPhone", newPatient.Phone);

            try 
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        internal static bool DeletePatient(int id)
        {
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string deleteStatement = "DELETE FROM Patient WHERE personID=@ID";

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
