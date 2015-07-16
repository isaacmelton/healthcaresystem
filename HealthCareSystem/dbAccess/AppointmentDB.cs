using HealthCareSystem.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HealthCareSystem.dbAccess
{
    /// <summary>
    /// DB layer for Appointment object.
    /// </summary>
    class AppointmentDB
    {
        /// <summary>
        /// Adds a appointment record to the db.
        /// </summary>
        /// <param name="appointment">The appointment record to add</param>
        /// <returns>The appointment ID</returns>
        public static int AddAppointment(Appointment appointment)
        {
            int appointmentID = -1;
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string insertStatement =
                        "INSERT Appointment " +
                        "(PersonId, NurseId, DoctorId, AppointmentDate, Symptom) " +
                        "VALUES (@PersonID, @NurseID, @DoctorId, @AppointmentDate, @Symptom)";
                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@PersonID", appointment.PersonId);
                        insertCommand.Parameters.AddWithValue("@NurseID", appointment.NurseId);
                        insertCommand.Parameters.AddWithValue("@DoctorID", appointment.DoctorId);
                        insertCommand.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                        insertCommand.Parameters.AddWithValue("@Symptom", appointment.Symptom);

                        connection.Open();
                        insertCommand.ExecuteNonQuery();
                        string selectStatement =
                            "SELECT IDENT_CURRENT('Appointment') FROM Appointment";

                        using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                        {
                            appointmentID = Convert.ToInt32(selectCommand.ExecuteScalar());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return appointmentID;
        }

        public static List<Appointment> GetAppointmentsWithoutDiagnosis()
        {
            List<Appointment> undiagnosedAppointmentList = new List<Appointment>();

            string selectStatement = "SELECT * FROM Appointment WHERE diagnosis IS NULL";
            
            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Appointment undiagnosedAppointment = new Appointment();
                                
                                undiagnosedAppointment.AppointmentId = (int)reader["appointmentID"];
                                
                                undiagnosedAppointmentList.Add(undiagnosedAppointment);
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

            return undiagnosedAppointmentList;

        }

        public static Appointment GetAppointmentInfo(int appointmentID)
        {
            Appointment appointment = new Appointment();

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string selectStatement = "SELECT * FROM Appointment WHERE appointmentID = @appointmentID";

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@appointmentID", appointmentID);

                        connection.Open();
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Appointment anAppointment = new Appointment();

                                anAppointment.AppointmentId = (int)reader["appointmentID"];
                                anAppointment.PersonId = (int)reader["personID"];
                                anAppointment.NurseId = (int)reader["nurseID"];
                                anAppointment.DoctorId = (int)reader["doctorID"];
                                anAppointment.AppointmentDate = (DateTime)reader["appointmentDate"];
                                anAppointment.Symptom = (String)reader["symptom"];
                                anAppointment.Diagnosis = !DBNull.Value.Equals(reader["diagnosis"]) ? (String)reader["diagnosis"] : null;

                                appointment = anAppointment;
                            }

                            return appointment;
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Appointment> GetUndiagnosedAppointmentListByAppointmentID(int appointmentID)
        {
            List<Appointment> openApptList = new List<Appointment>();

            string selectStatement = "SELECT * " +
                "FROM Appointment WHERE Appointment.Diagnosis IS NULL AND Appointment.AppointmentID = " + appointmentID;

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
                            Appointment aResult = new Appointment();

                            aResult.AppointmentId = (int)reader["AppointmentID"];

                            aResult.AppointmentDate = (DateTime)reader["AppointmentDate"];


                            openApptList.Add(aResult);
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

            return openApptList;

        }

        public static List<Appointment> GetAppointmentsWithoutVitals()
        {
            List<Appointment> appointmentsWithoutVitals = new List<Appointment>();

            string selectStatement = "SELECT * FROM Appointment WHERE Appointment.AppointmentId NOT IN (SELECT appointmentID FROM Vitals)";

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Appointment appt = new Appointment();
                                appt.AppointmentId = (int)reader["AppointmentID"];
                                appointmentsWithoutVitals.Add(appt);
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

            return appointmentsWithoutVitals;

        }

        public static bool UpdateAppointmentDiagnosis(Appointment oldAppointment, Appointment newAppointment)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = HealthCareDBConnection.GetConnection())
                {
                    string updateStatement =
                          "UPDATE Appointment SET " +
                            "diagnosis = @NewDiagnosis " +
                          "WHERE appointmentID = @OldAppointmentID " +
                            "AND personID = @OldPersonID " +
                            "AND nurseID = @OldNurseID " +
                            "AND doctorID = @OldDoctorID " +
                            "AND symptom = @OldSymptom";

                    connection.Open();

                    using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                    {

                        //updateCommand.Parameters.AddWithValue("@NewAppointmentID", newAppointment.AppointmentId);
                        //updateCommand.Parameters.AddWithValue("@NewPersonID", newAppointment.PersonId);
                        //updateCommand.Parameters.AddWithValue("@NewNurseID", newAppointment.NurseId);
                        updateCommand.Parameters.AddWithValue("@NewDiagnosis", newAppointment.Diagnosis);
                        //updateCommand.Parameters.AddWithValue("@NewSymptom", newAppointment.Symptom);


                        updateCommand.Parameters.AddWithValue("@OldAppointmentID", oldAppointment.AppointmentId);
                        updateCommand.Parameters.AddWithValue("@OldPersonID", oldAppointment.PersonId);
                        updateCommand.Parameters.AddWithValue("@OldNurseID", oldAppointment.NurseId);
                        updateCommand.Parameters.AddWithValue("@OldDoctorID", oldAppointment.DoctorId);
                        updateCommand.Parameters.AddWithValue("@OldSymptom", oldAppointment.Symptom);

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


        public static List<Appointment> GetAllAppointments()
        {
            List<Appointment> apptList = new List<Appointment>();

            string selectStatement = "SELECT appointmentID " +
                "FROM Appointment GROUP BY appointmentID";

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
                            Appointment aResult = new Appointment();

                            aResult.AppointmentId = (int)reader["AppointmentID"];


                            apptList.Add(aResult);
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

            return apptList;

        }

        internal static List<AppointmentInfo> GetAppointmentInfoWithoutDiagnosis()
        {
            List<AppointmentInfo> undiagnosedAppointmentList = new List<AppointmentInfo>();

            string selectStatement = "select * from Appointment join Person on Appointment.personID = Person.personID where diagnosis is null;";
            
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
                            AppointmentInfo undiagnosedAppointment = new AppointmentInfo();

                            Person undiagnosedPerson = new Person();

                            undiagnosedAppointment.AppointmentId = (int)reader["appointmentID"];
                            undiagnosedAppointment.Symptom = reader["symptom"].ToString();
                            undiagnosedAppointment.AppointmentDate = (DateTime)reader["appointmentDate"];
                            undiagnosedPerson.PersonId = (int)reader["personID"];
                            undiagnosedPerson.Ssn = reader["ssn"].ToString();
                            undiagnosedPerson.FirstName = reader["firstName"].ToString();
                            undiagnosedPerson.MiddleInitial = !DBNull.Value.Equals(reader["middleInitial"]) ? Convert.ToChar(reader["middleInitial"].ToString()) : Convert.ToChar(" ");
                            undiagnosedPerson.LastName = reader["lastName"].ToString();
                            undiagnosedPerson.DateOfBirth = (DateTime)reader["dateOfBirth"];
                            undiagnosedPerson.Gender = Convert.ToChar(reader["gender"].ToString());
                            undiagnosedAppointment.Person = undiagnosedPerson;
                            undiagnosedAppointmentList.Add(undiagnosedAppointment);

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

            return undiagnosedAppointmentList;

        }
    }
}
