using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareSystem.dbAccess;
using HealthCareSystem.model;

namespace HealthCareSystem.controller
{
    /// <summary>
    /// PatientController controls the flow of patient data.
    /// </summary>
    class PatientController
    {
        /// <summary>
        /// Creates a patient object from the given data.
        /// </summary>
        /// <param name="last">Patient's last name</param>
        /// <param name="middle">Patient's middle initial</param>
        /// <param name="first">Patient's first name</param>
        /// <param name="birthdate">Patient's birthdate</param>
        /// <param name="gender">Patient's gender</param>
        /// <param name="ssn">Patient's ssn</param>
        /// <param name="addr">Patient's address</param>
        /// <param name="city">Patient's city</param>
        /// <param name="state">Patient's state</param>
        /// <param name="zip">Patient's zip</param>
        /// <param name="phone">Patient's phone</param>
        /// <returns>A patient object with the specified information upon creation, otherwise null</returns>
        public static Patient CreatePatient(string last, char middle, string first, string birthdate, char gender, string ssn, string addr, string city, string state, string zip, string phone)
        {
            Patient newPatient = new Patient();
            try
            {
                newPatient.LastName = last;
                newPatient.MiddleInitial = middle;
                newPatient.FirstName = first;
                newPatient.DateOfBirth = DateTime.Parse(birthdate);
                newPatient.Gender = gender;
                newPatient.Ssn = ssn;
                newPatient.Address = addr;
                newPatient.City = city;
                newPatient.State = state;
                newPatient.Zip = zip;
                newPatient.Phone = phone;

                return newPatient;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            return null;
        }

        /// <summary>
        /// Adds a patient to the database.
        /// </summary>
        /// <param name="newPatient">The new patient to add</param>
        /// <returns>The new patient ID</returns>
        public static int AddPatient(Patient newPatient)
        {
            int patientID = -1;
            try
            {
                patientID = PatientDB.AddPatient(newPatient);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return patientID;
        }

        /// <summary>
        /// Gets all patients in the db.
        /// </summary>
        /// <returns>A list of all patients</returns>
        public static List<Patient> GetAllPatients()
        {
            return PatientDB.GetAllPatients();
        }

        /// <summary>
        /// Gets the patient object by patient ID.
        /// </summary>
        /// <param name="patientID">The ID of the patient to retreive</param>
        /// <returns>The patient with that ID</returns>
        public static Patient GetPatientByID(int patientID)
        {
            return PatientDB.GetPatientByID(patientID);
        }

        /// <summary>
        /// Updates a patient's info.
        /// </summary>
        /// <param name="oldPatient">The patient to update</param>
        /// <param name="newPatient">The new patient information</param>
        /// <returns>True IFF the patient information was updated</returns>
        public static bool UpdatePatient(Patient oldPatient, Patient newPatient)
        {
            return PersonDB.UpdatePerson((Person) oldPatient, (Person) newPatient);
        }

        /// <summary>
        /// Searches for a patient by first and last name.
        /// </summary>
        /// <param name="lastName">The last name of the patient</param>
        /// <param name="firstName">The first name of the patient</param>
        /// <returns>A list of patients that match the search criteria</returns>
        public static List<Patient> SearchPatient(String lastName, String firstName)
        {
            return PatientDB.GetPatientByLastNameFirstName(lastName, firstName);
        }

        /// <summary>
        /// Searches for a patient by DOB and last name.
        /// </summary>
        /// <param name="dateOfBirth">The DOB of the patient</param>
        /// <param name="lastName">The last name of the patient</param>
        /// <returns>A list of patients that match the search criteria</returns>
        public static List<Patient> SearchPatient(DateTime dateOfBirth, String lastName)
        {
            return PatientDB.GetPatientByDateOfBirthLastName(dateOfBirth, lastName);
        }

        /// <summary>
        /// Searches for a patient by DOB.
        /// </summary>
        /// <param name="dateOfBirth">The DOB of the patient</param>
        /// <returns>A list of patients that match the search criteria</returns>
        public static List<Patient> SearchPatient(DateTime dateOfBirth)
        {
            return PatientDB.GetPatientByDateOfBirth(dateOfBirth);
        }
    }
}
