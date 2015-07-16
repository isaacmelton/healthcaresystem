using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Model of a result.
    /// </summary>
   public class Result
    {
        private int testID;
        private int appointmentID;
        private String testResult;
        private DateTime resultDate;

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int TestId
        {
            get { return testID; }
            set { testID = value; }
        }

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
        public string TestResult
        {
            get { return testResult; }
            set { testResult = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public DateTime ResultDate
        {
            get { return resultDate; }
            set { resultDate = value; }
        }
    }

    /*  
    Database reference
    SELECT TOP 1000 [testID]
      ,[appointmentID]
      ,[result]
      ,[resultDate]
    FROM [ CS6232_G6].[dbo].[Results]
     */
}
