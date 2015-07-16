using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Model of vital records.
    /// </summary>
    class Vitals
    {
        private int appointmentID;
        private string bloodPressure;
        private decimal bodyTemperature;
        private decimal pulse;

        /* 
        Database reference
        SELECT TOP 1000 [appointmentID]
            ,[bloodPressure]
            ,[bodyTemperature]
            ,[pulse]
        FROM [ CS6232_G6].[dbo].[Vitals]
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
        public string BloodPressure
        {
            get { return bloodPressure; }
            set { bloodPressure = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public decimal BodyTemperature
        {
            get { return bodyTemperature; }
            set { bodyTemperature = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public decimal Pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }
    }
}
