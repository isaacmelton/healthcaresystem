using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Model of an appointment.
    /// </summary>
    class Appointment
    {
        private int appointmentID;
        private int personID;
        private int nurseID;
        private int doctorID;
        private DateTime appointmentDate;
        private String diagnosis;
        private String symptom;

        /*
        Database reference
        SELECT TOP 1000 [appointmentID]
          ,[personID]
          ,[nurseID]
          ,[doctorID]
          ,[appointmentDate]
          ,[diagnosis]
          ,[symptom]
        FROM [ CS6232_G6].[dbo].[Appointment]
        */

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int AppointmentId
        {
            get { return appointmentID; }
            set { appointmentID = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int PersonId
        {
            get { return personID; }
            set { personID = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int NurseId
        {
            get { return nurseID; }
            set { nurseID = value; }
        }


        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int DoctorId
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string Symptom
        {
            get { return symptom; }
            set { symptom = value; }
        }

        public string IDAndDate
        {
            get { return appointmentID.ToString() + ": " + appointmentDate.Date.ToString(); }
        }
    }
}
