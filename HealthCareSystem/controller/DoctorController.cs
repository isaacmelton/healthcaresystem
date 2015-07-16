using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HealthCareSystem.dbAccess;
using HealthCareSystem.model;

namespace HealthCareSystem.controller
{
    /// <summary>
    /// DoctorController controls the flow of doctor data.
    /// </summary>
    class DoctorController
    {
        public static List<User> GetDoctorsList()
        {List<User> doctors = new List<User>();
            try
            {
                doctors = DoctorDB.GetAllDoctors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return doctors;
        }
       
        internal static int AddDoctor(User doctor)
        {
            int doctorId = -1;
            try
            {
                doctorId = PersonDB.AddPerson((Person) doctor);

                if (doctorId == -1)
                {
                    throw new Exception("Error adding the doctor to the Database");
                }
                else
                {
                    DoctorDB.AddDoctor(doctorId, doctor);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            return doctorId;
        }

        public bool UpdateDoctor(User oldDoctor, User newDoctor)
        {
            return PersonDB.UpdateUser(oldDoctor, newDoctor);
        }

        public static bool DeleteDoctorByID(int id)
        {
            try
            {
                bool userDel = DoctorDB.DeleteDoctor(id);
                return userDel;
            }
            catch 
            {
                throw;
            }
           
        }

        public static Doctor GetDoctorByID(int personID) {
            return DoctorDB.GetDoctorInfoByID(personID);

        }
    }
}
