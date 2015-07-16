using HealthCareSystem.dbAccess;
using HealthCareSystem.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareSystem.controller
{
    class AppointmentController
    {
        /// <summary>
        /// Adds an appointment to the db.
        /// </summary>
        /// <param name="newAppointment">The appointment to add</param>
        /// <returns>The id of the new appointment</returns>
        public static int AddAppointment(Appointment newAppointment)
        {
            int appointmentID = -1;

            try
            {
                appointmentID = AppointmentDB.AddAppointment(newAppointment);
                if (appointmentID == -1)
                {
                    throw new Exception("Error adding the appointment to the Database");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            return appointmentID;
        }

        public static List<Appointment> GetAppointmentsWithoutDiagnosis()
        {
            List<Appointment> undiagnosedAppList = new List<Appointment>();

            try
            {
                undiagnosedAppList = AppointmentDB.GetAppointmentsWithoutDiagnosis();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            return undiagnosedAppList;
        }

        public static Appointment GetAppointmentInfo(int appointmentID)
        {
            Appointment returnAppt = new Appointment();

            try
            {
                returnAppt = AppointmentDB.GetAppointmentInfo(appointmentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return returnAppt;
        }

        public static List<Appointment> GetUndiagnosedAppointmentListByAppointmentID(int appointmentID)
        {
            List<Appointment> appList = new List<Appointment>();

            try
            {
                appList = AppointmentDB.GetUndiagnosedAppointmentListByAppointmentID(appointmentID);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return appList;
        }

        public static bool UpdateAppointmentDiagnosis(Appointment oldAppointment, Appointment newAppointment)
        {
            Boolean success = false;

            try
            {
                success = AppointmentDB.UpdateAppointmentDiagnosis(oldAppointment, newAppointment);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);

            }
            return success;
        }

        public static List<Appointment> GetAppointmentsWithoutVitals()
        {
            List<Appointment> noVitalsList = new List<Appointment>();
            try
            {
                noVitalsList = AppointmentDB.GetAppointmentsWithoutVitals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return noVitalsList;
        }

        public static List<Appointment> GetAllAppointments()
        {
            List<Appointment> allAppointmentList = new List<Appointment>();
            try
            {
                allAppointmentList = AppointmentDB.GetAllAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return allAppointmentList;
        }

        public static List<AppointmentInfo> GetAppointmentAndPersonInfoWithoutDiagnosis()
        {
            List<AppointmentInfo> undiagnosedAppList = new List<AppointmentInfo>();

            try
            {
                undiagnosedAppList = AppointmentDB.GetAppointmentInfoWithoutDiagnosis();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            return undiagnosedAppList;
        }

    }
}
